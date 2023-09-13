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
    /// cylinder Geometry
    /// </summary>
    [Serializable]
    public class ArenaCylinderJson
    {
        public const string componentName = "cylinder";

        // cylinder member-fields

        private static float defHeight = 1f;
        [JsonProperty(PropertyName = "height")]
        [Tooltip("height")]
        public float Height = defHeight;
        public bool ShouldSerializeHeight()
        {
            return true; // required in json schema
        }

        private static bool defOpenEnded = false;
        [JsonProperty(PropertyName = "openEnded")]
        [Tooltip("open ended")]
        public bool OpenEnded = defOpenEnded;
        public bool ShouldSerializeOpenEnded()
        {
            if (_token != null && _token.SelectToken("openEnded") != null) return true;
            return (OpenEnded != defOpenEnded);
        }

        private static float defRadius = 1f;
        [JsonProperty(PropertyName = "radius")]
        [Tooltip("radius")]
        public float Radius = defRadius;
        public bool ShouldSerializeRadius()
        {
            return true; // required in json schema
        }

        private static int defSegmentsHeight = 18;
        [JsonProperty(PropertyName = "segmentsHeight")]
        [Tooltip("segments height")]
        public int SegmentsHeight = defSegmentsHeight;
        public bool ShouldSerializeSegmentsHeight()
        {
            if (_token != null && _token.SelectToken("segmentsHeight") != null) return true;
            return (SegmentsHeight != defSegmentsHeight);
        }

        private static int defSegmentsRadial = 36;
        [JsonProperty(PropertyName = "segmentsRadial")]
        [Tooltip("segments radial")]
        public int SegmentsRadial = defSegmentsRadial;
        public bool ShouldSerializeSegmentsRadial()
        {
            if (_token != null && _token.SelectToken("segmentsRadial") != null) return true;
            return (SegmentsRadial != defSegmentsRadial);
        }

        private static float defThetaLength = 360f;
        [JsonProperty(PropertyName = "thetaLength")]
        [Tooltip("theta length")]
        public float ThetaLength = defThetaLength;
        public bool ShouldSerializeThetaLength()
        {
            if (_token != null && _token.SelectToken("thetaLength") != null) return true;
            return (ThetaLength != defThetaLength);
        }

        private static float defThetaStart = 0f;
        [JsonProperty(PropertyName = "thetaStart")]
        [Tooltip("theta start")]
        public float ThetaStart = defThetaStart;
        public bool ShouldSerializeThetaStart()
        {
            if (_token != null && _token.SelectToken("thetaStart") != null) return true;
            return (ThetaStart != defThetaStart);
        }

        // General json object management

        [JsonExtensionData]
        private IDictionary<string, JToken> _additionalData;

        private static JToken _token;

        public string SaveToString()
        {
            return Regex.Unescape(JsonConvert.SerializeObject(this));
        }

        public static ArenaCylinderJson CreateFromJSON(string jsonString, JToken token)
        {
            _token = token; // save updated wire json
            ArenaCylinderJson json = null;
            try {
                json = JsonConvert.DeserializeObject<ArenaCylinderJson>(Regex.Unescape(jsonString));
            } catch (JsonReaderException e)
            {
                Debug.LogWarning($"{e.Message}: {jsonString}");
            }
            return json;
        }
    }
}
