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
    /// Triangle Geometry
    /// </summary>
    [Serializable]
    public class ArenaTriangleJson
    {
        public const string componentName = "triangle";

        // triangle member-fields

        private static object defVertexA = JsonConvert.DeserializeObject("{'x': 0, 'y': 0.5, 'z': 0}");
        [JsonProperty(PropertyName = "vertexA")]
        [Tooltip("vertex A")]
        public object VertexA = defVertexA;
        public bool ShouldSerializeVertexA()
        {
            return true; // required in json schema
        }

        private static object defVertexB = JsonConvert.DeserializeObject("{'x': -0.5, 'y': -0.5, 'z': 0}");
        [JsonProperty(PropertyName = "vertexB")]
        [Tooltip("vertex B")]
        public object VertexB = defVertexB;
        public bool ShouldSerializeVertexB()
        {
            return true; // required in json schema
        }

        private static object defVertexC = JsonConvert.DeserializeObject("{'x': 0.5, 'y': -0.5, 'z': 0}");
        [JsonProperty(PropertyName = "vertexC")]
        [Tooltip("vertex C")]
        public object VertexC = defVertexC;
        public bool ShouldSerializeVertexC()
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

        public static ArenaTriangleJson CreateFromJSON(string jsonString, JToken token)
        {
            _token = token; // save updated wire json
            ArenaTriangleJson json = null;
            try {
                json = JsonConvert.DeserializeObject<ArenaTriangleJson>(Regex.Unescape(jsonString));
            } catch (JsonReaderException e)
            {
                Debug.LogWarning($"{e.Message}: {jsonString}");
            }
            return json;
        }
    }
}
