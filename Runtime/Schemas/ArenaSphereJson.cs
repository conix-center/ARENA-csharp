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
    /// Sphere Geometry
    /// </summary>
    [Serializable]
    public class ArenaSphereJson
    {
        public const string componentName = "sphere";

        // sphere member-fields

        private static float defPhiLength = 360f;
        [JsonProperty(PropertyName = "phiLength")]
        [Tooltip("phi length")]
        public float PhiLength = defPhiLength;
        public bool ShouldSerializePhiLength()
        {
            if (_token != null && _token.SelectToken("phiLength") != null) return true;
            return (PhiLength != defPhiLength);
        }

        private static float defPhiStart = 0f;
        [JsonProperty(PropertyName = "phiStart")]
        [Tooltip("phi start")]
        public float PhiStart = defPhiStart;
        public bool ShouldSerializePhiStart()
        {
            if (_token != null && _token.SelectToken("phiStart") != null) return true;
            return (PhiStart != defPhiStart);
        }

        private static float defRadius = 1f;
        [JsonProperty(PropertyName = "radius")]
        [Tooltip("radius")]
        public float Radius = defRadius;
        public bool ShouldSerializeRadius()
        {
            if (_token != null && _token.SelectToken("radius") != null) return true;
            return (Radius != defRadius);
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

        private static int defSegmentsWidth = 36;
        [JsonProperty(PropertyName = "segmentsWidth")]
        [Tooltip("segments width")]
        public int SegmentsWidth = defSegmentsWidth;
        public bool ShouldSerializeSegmentsWidth()
        {
            if (_token != null && _token.SelectToken("segmentsWidth") != null) return true;
            return (SegmentsWidth != defSegmentsWidth);
        }

        private static float defThetaLength = 180f;
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

        public static ArenaSphereJson CreateFromJSON(string jsonString, JToken token)
        {
            _token = token; // save updated wire json
            ArenaSphereJson json = null;
            try {
                json = JsonConvert.DeserializeObject<ArenaSphereJson>(Regex.Unescape(jsonString));
            } catch (JsonReaderException e)
            {
                Debug.LogWarning($"{e.Message}: {jsonString}");
            }
            return json;
        }
    }
}
