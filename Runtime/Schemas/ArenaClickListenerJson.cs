/**
 * Open source software under the terms in /LICENSE
 * Copyright (c) 2021-2023, Carnegie Mellon University. All rights reserved.
 */

// CAUTION: This file is autogenerated from https://github.com/arenaxr/arena-schemas. Changes made here may be overwritten.

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace ArenaUnity.Schemas
{
    /// <summary>
    /// Object will listen for clicks
    /// </summary>
    [Serializable]
    public class ArenaClickListenerJson
    {
        public const string componentName = "click-listener";

        // click-listener member-fields

        private static bool defEnabled = true;
        [JsonProperty(PropertyName = "enabled")]
        [Tooltip("Publish events, set false to disable")]
        public bool Enabled = defEnabled;
        public bool ShouldSerializeEnabled()
        {
            return true; // required in json schema
        }

        private static bool defBubble = true;
        [JsonProperty(PropertyName = "bubble")]
        [Tooltip("Set false to prevent click events from bubbling up to parent objects. See https://developer.mozilla.org/en-US/docs/Learn/JavaScript/Building_blocks/Events#event_bubbling")]
        public bool Bubble = defBubble;
        public bool ShouldSerializeBubble()
        {
            return true; // required in json schema
        }

        // General json object management

        [JsonExtensionData]
        private IDictionary<string, JToken> _additionalData;

        private static JToken _token;

        public string SaveToString()
        {
            return Regex.Unescape(JsonConvert.SerializeObject(this));
        }

        public static ArenaClickListenerJson CreateFromJSON(string jsonString, JToken token)
        {
            _token = token; // save updated wire json
            ArenaClickListenerJson json = null;
            try {
                json = JsonConvert.DeserializeObject<ArenaClickListenerJson>(Regex.Unescape(jsonString));
            } catch (JsonReaderException e)
            {
                Debug.LogWarning($"{e.Message}: {jsonString}");
            }
            return json;
        }
    }
}
