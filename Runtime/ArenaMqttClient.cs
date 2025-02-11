﻿/**
* Open source software under the terms in /LICENSE
* Copyright (c) 2021-2023, Carnegie Mellon University. All rights reserved.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using M2MqttUnity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
#endif
using UnityEngine;
using UnityEngine.Networking;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ArenaUnity
{
    public class ArenaMqttClient : M2MqttUnityClient
    {
        [Header("ARENA MQTT configuration")]
        [Tooltip("Connect as Anonymous, Google authenticated, or Manual (advanced) JWT user (runtime changes ignored).")]
        public Auth authType = Auth.Google;
        [Tooltip("IP address or URL of the host running broker/auth/persist services (runtime changes ignored).")]
        public string hostAddress = "arenaxr.org";

        /// <summary>
        /// Authenticated user email account.
        /// </summary>
        public string email { get; private set; }
        /// <summary>
        /// MQTT JWT Auth Payload and Claims.
        /// </summary>
        public string permissions { get; private set; }
        /// <summary>
        /// MQTT JWT expiration epoch.
        /// </summary>
        public long mqttExpires { get; private set; }

        /// <summary>
        /// Manual request for remote render "r" rights, pending account allowances.
        /// </summary>
        public bool requestRemoteRenderRights { get; set; }
        /// <summary>
        /// Manual request for environment "e" rights, pending account allowances.
        /// </summary>
        public bool requestEnvironmentRights { get; set; }

        // internal variables
        private string idToken = null;
        protected string csrfToken = null;
        protected string fsToken = null;
        protected ArenaUserStateJson authState;
        private static UserCredential credential;

        // local paths
        const string gAuthFile = ".arena_google_auth";
        const string mqttTokenFile = ".arena_mqtt_auth";
        const string userDirArena = ".arena";
        const string userSubDirUnity = "unity";
        private const string packageNameRenderFusion = "io.conix.arena.renderfusion";

        public string appFilesPath { get; private set; }
        public string username { get; private set; }
        public string userid { get; private set; }
        public string userclient { get; private set; }
        public string camid { get; private set; }
        public string handleftid { get; private set; }
        public string handrightid { get; private set; }
        public string networkLatencyTopic { get; private set; } // network graph latency update
        static readonly int networkLatencyIntervalMs = 10000; // run network latency update every 10s

        static readonly string[] Scopes = {
            Oauth2Service.Scope.UserinfoProfile,
            Oauth2Service.Scope.UserinfoEmail,
            Oauth2Service.Scope.Openid
        };

        public enum Auth { Anonymous, Google, Manual };
        public bool IsShuttingDown { get; internal set; }

        private List<byte[]> eventMessages = new List<byte[]>();
        protected Dictionary<ushort, string> subscriptions = new Dictionary<ushort, string>();
#if UNITY_EDITOR
        private ListRequest packageListRequest;
#endif

        // MQTT methods

        protected override void Awake()
        {
            base.Awake();
            // initialize arena-specific mqtt parameters
            brokerPort = 8883;
            isEncrypted = true;
            sslProtocol = MqttSslProtocols.TLSv1_2;
            if (hostAddress == "localhost")
            {
                verifyCertificate = false;
            }
#if UNITY_EDITOR
            packageListRequest = Client.List(true); // request offline packages installed
#endif
            StartCoroutine(PublishTickLatency());
        }

        IEnumerator PublishTickLatency()
        {
            while (true)
            {
                if (mqttClientConnected && !string.IsNullOrEmpty(networkLatencyTopic))
                {
                    // publish empty message with QoS of 2 to update latency
                    client.Publish(networkLatencyTopic, new byte[] { }, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                }
                yield return new WaitForSeconds(networkLatencyIntervalMs / 1000);
            }
        }

        protected override void Update()
        {
            base.Update(); // call ProcessMqttEvents()

            if (eventMessages.Count > 0)
            {
                foreach (byte[] msg in eventMessages)
                {
                    ProcessMessage(msg);
                }
                eventMessages.Clear();
            }
        }

        protected virtual void ProcessMessage(byte[] msg)
        {
            Debug.LogFormat("Message received of length: {0}", msg.Length);
        }

        private void StoreMessage(byte[] eventMsg)
        {
            eventMessages.Add(eventMsg);
        }

        protected override void DecodeMessage(string topic, byte[] message)
        {
            StoreMessage(message);
        }

        public void Publish(string topic, byte[] payload)
        {
            if (client != null) client.Publish(topic, payload);
        }

        public void Subscribe(string topic)
        {
            if (client != null)
            {
                var mid = client.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
                subscriptions[mid] = topic;
            }
        }

        public void Unsubscribe(string[] topics)
        {
            if (client != null) { client.Unsubscribe(topics); }
        }

        protected void OnDestroy()
        {
            Disconnect();
        }

        protected override void OnApplicationQuit()
        {
            IsShuttingDown = true;
            base.OnApplicationQuit();
        }

        // Auth methods

        internal static string GetUnityAuthPath()
        {
            string userHomePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(userHomePath, userDirArena, userSubDirUnity);
        }

        protected virtual void OnEnable()
        {
            appFilesPath = Application.isMobilePlatform ? Application.persistentDataPath : "";
        }

        /// <summary>
        /// Sign into the ARENA for a specific scene, optionally using a user avatar camera, per user account.
        /// </summary>
        protected IEnumerator SigninScene(string sceneName, string namespaceName, string realm, bool camera, string latencyTopic = null)
        {
            return Signin(sceneName, namespaceName, realm, camera, latencyTopic);
        }

        /// <summary>
        /// Sign into the ARENA for any available credentials based on authType per user account.
        /// </summary>
        protected IEnumerator Signin()
        {
            return Signin(null, null, null, false, null);
        }

        private IEnumerator Signin(string sceneName, string namespaceName, string realm, bool hasArenaCamera, string latencyTopic)
        {
            networkLatencyTopic = latencyTopic;
            string sceneAuthDir = Path.Combine(GetUnityAuthPath(), hostAddress, "s");
            string userGAuthPath = sceneAuthDir;
            string userMqttPath = Path.Combine(sceneAuthDir, mqttTokenFile);
            string mqttToken = null;
            CoroutineWithData cd;
#if UNITY_EDITOR && !( UNITY_ANDROID || UNITY_IOS )
            if (!Directory.Exists(sceneAuthDir))
            {
                Directory.CreateDirectory(sceneAuthDir);
            }
#endif
            if (hostAddress == "localhost")
            {
                verifyCertificate = false;
            }

            string localMqttPath = Path.Combine(appFilesPath, mqttTokenFile);
            if (File.Exists(localMqttPath))
            {
                // check for local mqtt auth
                Debug.LogWarning("Using local MQTT token.");
                if (authType != Auth.Manual)
                {
                    Debug.LogError($"Authentication type '{authType}' when using local token may create ambiguous results. Switch to '{Auth.Manual}'.");
                    yield break;
                }
                try
                {
                    using (var sr = new StreamReader(localMqttPath))
                    {
                        mqttToken = sr.ReadToEnd();
                    }
                }
                catch (IOException e)
                {
                    Debug.LogError(e.Message);
                }
            }
            else
            {
                string tokenType = "";
                switch (authType)
                {
                    case Auth.Anonymous:
                        // prefix all anon users with "anonymous-"
                        Debug.Log("Using anonymous MQTT token.");
                        tokenType = "anonymous";
                        username = $"anonymous-unity";
                        break;
                    case Auth.Google:
                        // get oauth app credentials
                        Debug.Log("Using remote-authenticated MQTT token.");
                        cd = new CoroutineWithData(this, HttpRequestAuth($"https://{hostAddress}/conf/gauth.json"));
                        yield return cd.coroutine;
                        if (!isCrdSuccess(cd.result)) yield break;
                        string gauthId = cd.result.ToString();

                        // request user auth
                        using (var stream = ToStream(gauthId))
                        {
                            string applicationName = "ArenaClientCSharp";
                            IDataStore ds;
                            if (Application.isMobilePlatform) ds = new NullDataStore();
                            else ds = new FileDataStore(userGAuthPath, true);
                            GoogleWebAuthorizationBroker.Folder = userGAuthPath;
                            // GoogleWebAuthorizationBroker.AuthorizeAsync for "installed" creds only
                            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                                    GoogleClientSecrets.FromStream(stream).Secrets,
                                    Scopes,
                                    "user",
                                    CancellationToken.None,
                                    ds).Result;

                            var oauthService = new Oauth2Service(new BaseClientService.Initializer()
                            {
                                HttpClientInitializer = credential,
                                ApplicationName = applicationName,
                            });

                            var userInfo = oauthService.Userinfo.Get().Execute();

                            email = userInfo.Email;
                            idToken = credential.Token.IdToken;
                        }
                        tokenType = "google-installed";
                        break;
                    case Auth.Manual:
                        Debug.LogError($"Authentication type Manual missing local token file: {localMqttPath}.");
                        yield break;
                    default:
                        Debug.LogError($"Invalid ARENA authentication type: '{tokenType}'");
                        yield break;
                }

                // get arena CSRF token
                yield return HttpRequestAuth($"https://{hostAddress}/user/v2/login");

                WWWForm form = new WWWForm();
                if (idToken != null) form.AddField("id_token", idToken);

                // get arena user account state
                cd = new CoroutineWithData(this, HttpRequestAuth($"https://{hostAddress}/user/v2/user_state", csrfToken, form));
                yield return cd.coroutine;
                if (!isCrdSuccess(cd.result)) yield break;
                authState = JsonConvert.DeserializeObject<ArenaUserStateJson>(cd.result.ToString());
                if (authState.authenticated)
                {
                    username = authState.username;
                }
                if (string.IsNullOrWhiteSpace(namespaceName))
                {
                    if (authState.authenticated)
                    {
                        namespaceName = authState.username;
                    }
                    else
                    {
                        namespaceName = "public";
                    }
                }

                // get arena user mqtt token
                form.AddField("id_auth", tokenType);
                form.AddField("username", username);
                // always request user-specific context
                form.AddField("client", "unity");
                form.AddField("userid", "true");
                if (hasArenaCamera)
                {
                    form.AddField("camid", "true");
                }
                if (!string.IsNullOrWhiteSpace(realm))
                {
                    form.AddField("realm", realm);
                }
                // handle full ARENA scene
                if (!string.IsNullOrWhiteSpace(sceneName))
                {
                    form.AddField("scene", $"{namespaceName}/{sceneName}");
                }
                // manual rights requests
                if (requestRemoteRenderRights)
                {
                    form.AddField("renderfusionid", "true");
                }
                if (requestEnvironmentRights)
                {
                    form.AddField("environmentid", "true");
                }
#if UNITY_EDITOR
                // auto-test for render fusion, request permissions if so
                if (packageListRequest.IsCompleted)
                {
                    if (packageListRequest.Status == StatusCode.Success)
                        foreach (var package in packageListRequest.Result)
                            if (package.name == packageNameRenderFusion)
                            {
                                form.AddField("renderfusionid", "true");
                                requestRemoteRenderRights = true; // for display purposes
                            }
                    else if (packageListRequest.Status >= StatusCode.Failure)
                        Debug.LogWarning(packageListRequest.Error.message);
                }
                else
                {
                    Debug.LogWarning("Package Manager unable to query for render-fusion package!");
                }
#endif
                // request token endpoint
                cd = new CoroutineWithData(this, HttpRequestAuth($"https://{hostAddress}/user/v2/mqtt_auth", csrfToken, form));
                yield return cd.coroutine;
                if (!isCrdSuccess(cd.result)) yield break;
                mqttToken = cd.result.ToString();
#if UNITY_EDITOR && !( UNITY_ANDROID || UNITY_IOS )
                StreamWriter writer = new StreamWriter(userMqttPath);
                writer.Write(mqttToken);
                writer.Close();
#endif
            }

            var auth = JsonConvert.DeserializeObject<ArenaMqttAuthJson>(mqttToken);
            // validate received token
            if (auth == null || auth.username == null || auth.token == null)
            {
                Debug.LogError("Missing required jwt auth!!!!");
                yield break;
            }
            mqttUserName = auth.username;
            mqttPassword = auth.token;

            // validate userids
            if (auth.ids == null || auth.ids.userid == null || auth.ids.userclient == null)
            {
                Debug.LogError("Missing required user ids!!!!");
                yield break;
            }
            userid = auth.ids.userid;
            userclient = auth.ids.userclient;

            // publishing cam/hands? then last will is required
            if (hasArenaCamera)
            {
                if (auth.ids.camid == null)
                {
                    Debug.LogError("Missing required camid!!!! Do not 'publish camera' if this is Manual auth.");
                    yield break;
                }
                camid = auth.ids.camid;
                handleftid = auth.ids.handleftid;
                handrightid = auth.ids.handrightid;

                // will message can only remove the primary user presence
                var lwtTopic = new ArenaTopics(
                    realm: realm,
                    name_space: namespaceName,
                    scenename: sceneName,
                    userclient: userclient,
                    idtag: userid
                );
                willFlag = hasArenaCamera;
                willTopic = lwtTopic.PUB_SCENE_PRESENCE;
                ArenaObjectJson msg = new ArenaObjectJson
                {
                    object_id = userid,
                    action = "leave",
                };
                willMessage = JsonConvert.SerializeObject(msg);
                Debug.Log($"MQTT Last will: {willTopic} {willMessage}");
            }

            string payloadJson = Base64UrlDecode(auth.token.Split('.')[1]);
            JObject payload = JObject.Parse(payloadJson);
            permissions = JToken.Parse(payloadJson).ToString(Formatting.Indented);
            if (string.IsNullOrWhiteSpace(namespaceName))
            {
                namespaceName = (string)payload.SelectToken("sub");
            }
            mqttExpires = (long)payload.SelectToken("exp");
            DateTimeOffset dateTimeOffSet = DateTimeOffset.FromUnixTimeSeconds(mqttExpires);
            TimeSpan duration = dateTimeOffSet.DateTime.Subtract(DateTime.Now.ToUniversalTime());
            Debug.Log($"MQTT Token expires in {ArenaUnity.TimeSpanToString(duration)}");

            // background mqtt connect
            Connect();
            yield return namespaceName;
        }

        protected bool ConfirmGoogleAuth()
        {
            return (idToken != null);
        }

        protected IEnumerator GetFSLoginForUser()
        {
            WWWForm form = new WWWForm();
            if (idToken != null) form.AddField("id_token", idToken);

            CoroutineWithData cd = new CoroutineWithData(this, HttpRequestAuth($"https://{hostAddress}/user/v2/storelogin", csrfToken, form));
            yield return cd.coroutine;
            if (!isCrdSuccess(cd.result)) yield break;
            if (string.IsNullOrWhiteSpace(fsToken))
            {
                Debug.LogError($"Invalid file store token = {fsToken}");
                yield break;
            }
            else
            {
                yield return true;
            }
        }

        public static string Base64UrlDecode(string base64)
        {
            string base64Padded = base64.PadRight(base64.Length + (4 - base64.Length % 4) % 4, '=');
            return Encoding.UTF8.GetString(Convert.FromBase64String(base64Padded));
        }

        /// <summary>
        /// Remove ARENA authentication.
        /// </summary>
#if UNITY_EDITOR
        [MenuItem("ARENA/Signout")]
#endif
        public static void SignoutArena()
        {
#if UNITY_EDITOR
            if (Application.isPlaying)
                EditorApplication.ExitPlaymode();
#endif
            string unityAuthPath = GetUnityAuthPath();
            if (Directory.Exists(unityAuthPath))
                Directory.Delete(unityAuthPath, true);
            Debug.Log("Signed out of the ARENA.");
        }

        private static Stream ToStream(string str)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        protected IEnumerator HttpRequestAuth(string url, string csrf = null, WWWForm form = null)
        {
            UnityWebRequest www;
            if (form == null)
                www = UnityWebRequest.Get(url);
            else
                www = UnityWebRequest.Post(url, form);
            if (csrf != null)
            {
                www.SetRequestHeader("Cookie", $"csrftoken={csrf}");
                www.SetRequestHeader("X-CSRFToken", csrf);
            }
            if (mqttPassword != null)
                www.SetRequestHeader("Cookie", $"mqtt_token={mqttPassword}");
            if (!verifyCertificate)
                www.certificateHandler = new SelfSignedCertificateHandler();
            yield return www.SendWebRequest();
#if UNITY_2020_1_OR_NEWER
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
#else
            if (www.isNetworkError || www.isHttpError)
#endif
            {
                Debug.LogWarning($"{www.error}: {www.url}");
                if (!string.IsNullOrWhiteSpace(www.downloadHandler?.text))
                {
                    Debug.LogWarning(www.downloadHandler.text);
                }
                if (www.responseCode == 401 || www.responseCode == 403)
                {
                    Debug.LogWarning($"Do you have a valid ARENA account on {www.uri.Host}?");
                    Debug.LogWarning($"Create an account in a web browser at: {www.uri.Scheme}{www.uri.Host}/user");
                }
                yield break;
            }
            else
            {
                // get the csrf cookie
                string SetCookie = www.GetResponseHeader("Set-Cookie");
                if (SetCookie != null)
                {
                    if (SetCookie.Contains("csrftoken="))
                        csrfToken = GetCookie(SetCookie, "csrftoken");
                    else if (SetCookie.Contains("csrf="))
                        csrfToken = GetCookie(SetCookie, "csrf");
                    if (SetCookie.Contains("auth="))
                        fsToken = GetCookie(SetCookie, "auth");
                }
                yield return www.downloadHandler.text;
            }
        }

        protected bool isCrdSuccess(object result)
        {
            return result != null && result.ToString() != "UnityEngine.Networking.UnityWebRequestAsyncOperation";
        }

        private string GetCookie(string SetCookie, string cookieTag)
        {
            string csrfCookie = null;
            Regex rxCookie = new Regex($"(^| ){cookieTag}=([^;]+)");
            MatchCollection cookieMatches = rxCookie.Matches(SetCookie);
            if (cookieMatches.Count > 0)
                csrfCookie = cookieMatches[0].Groups[2].Value;
            return csrfCookie;
        }

        public static bool MqttTopicMatch(string allowTopic, string attemptTopic)
        {
            var allowedRegex = allowTopic.Replace(@"/", @"\/").Replace("+", @"[a-zA-Z0-9 _+.-]*").Replace("#", @"[a-zA-Z0-9 \/_#+.-]*");
            var re = new Regex(allowedRegex);
            var matches = re.Matches(attemptTopic);
            foreach (var match in matches.ToList())
            {
                if (match.Value == attemptTopic)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
