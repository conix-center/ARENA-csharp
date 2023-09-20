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
using Newtonsoft.Json.Serialization;
using UnityEngine;

namespace ArenaUnity.Schemas
{
    /// <summary>
    /// Circle Geometry
    /// </summary>
    [Serializable]
    public class ArenaCircleJson
    {
        public readonly string object_type = "circle";

        // circle member-fields

        private static float defRadius = 1f;
        [JsonProperty(PropertyName = "radius")]
        [Tooltip("radius")]
        public float Radius = defRadius;
        public bool ShouldSerializeRadius()
        {
            return true; // required in json schema
        }

        private static int defSegments = 32;
        [JsonProperty(PropertyName = "segments")]
        [Tooltip("segments")]
        public int Segments = defSegments;
        public bool ShouldSerializeSegments()
        {
            // segments
            return (Segments != defSegments);
        }

        private static float defThetaLength = 360f;
        [JsonProperty(PropertyName = "thetaLength")]
        [Tooltip("theta length")]
        public float ThetaLength = defThetaLength;
        public bool ShouldSerializeThetaLength()
        {
            // thetaLength
            return (ThetaLength != defThetaLength);
        }

        private static float defThetaStart = 0f;
        [JsonProperty(PropertyName = "thetaStart")]
        [Tooltip("theta start")]
        public float ThetaStart = defThetaStart;
        public bool ShouldSerializeThetaStart()
        {
            // thetaStart
            return (ThetaStart != defThetaStart);
        }

        // General json object management
        [OnError]
        internal void OnError(StreamingContext context, ErrorContext errorContext)
        {
            Debug.LogWarning($"{errorContext.Error.Message}: {errorContext.OriginalObject}");
            errorContext.Handled = true;
        }

        [JsonExtensionData]
        private IDictionary<string, JToken> _additionalData;

        public string SaveToString()
        {
            return Regex.Unescape(JsonConvert.SerializeObject(this));
        }

        public static ArenaCircleJson CreateFromJSON(string jsonString, JToken token)
        {
            ArenaCircleJson json = null;
            try {
                json = JsonConvert.DeserializeObject<ArenaCircleJson>(Regex.Unescape(jsonString));
            } catch (JsonReaderException e)
            {
                Debug.LogWarning($"{e.Message}: {jsonString}");
            }
            return json;
        }
    }
}
