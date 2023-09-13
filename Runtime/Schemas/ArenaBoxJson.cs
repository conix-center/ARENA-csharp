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
    /// Box Geometry
    /// </summary>
    [Serializable]
    public class ArenaBoxJson
    {
        public const string componentName = "box";

        // box member-fields

        private static float defDepth = 1f;
        [JsonProperty(PropertyName = "depth")]
        [Tooltip("depth")]
        public float Depth = defDepth;
        public bool ShouldSerializeDepth()
        {
            return true; // required in json schema
        }

        private static float defHeight = 1f;
        [JsonProperty(PropertyName = "height")]
        [Tooltip("height")]
        public float Height = defHeight;
        public bool ShouldSerializeHeight()
        {
            return true; // required in json schema
        }

        private static int defSegmentsDepth = 1;
        [JsonProperty(PropertyName = "segmentsDepth")]
        [Tooltip("segments depth")]
        public int SegmentsDepth = defSegmentsDepth;
        public bool ShouldSerializeSegmentsDepth()
        {
            if (_token != null && _token.SelectToken("segmentsDepth") != null) return true;
            return (SegmentsDepth != defSegmentsDepth);
        }

        private static int defSegmentsHeight = 1;
        [JsonProperty(PropertyName = "segmentsHeight")]
        [Tooltip("segments height")]
        public int SegmentsHeight = defSegmentsHeight;
        public bool ShouldSerializeSegmentsHeight()
        {
            if (_token != null && _token.SelectToken("segmentsHeight") != null) return true;
            return (SegmentsHeight != defSegmentsHeight);
        }

        private static int defSegmentsWidth = 1;
        [JsonProperty(PropertyName = "segmentsWidth")]
        [Tooltip("segments width")]
        public int SegmentsWidth = defSegmentsWidth;
        public bool ShouldSerializeSegmentsWidth()
        {
            if (_token != null && _token.SelectToken("segmentsWidth") != null) return true;
            return (SegmentsWidth != defSegmentsWidth);
        }

        private static float defWidth = 1f;
        [JsonProperty(PropertyName = "width")]
        [Tooltip("width")]
        public float Width = defWidth;
        public bool ShouldSerializeWidth()
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

        public static ArenaBoxJson CreateFromJSON(string jsonString, JToken token)
        {
            _token = token; // save updated wire json
            ArenaBoxJson json = null;
            try {
                json = JsonConvert.DeserializeObject<ArenaBoxJson>(Regex.Unescape(jsonString));
            } catch (JsonReaderException e)
            {
                Debug.LogWarning($"{e.Message}: {jsonString}");
            }
            return json;
        }
    }
}
