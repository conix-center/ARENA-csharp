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
    /// Torus Knot Geometry
    /// </summary>
    [Serializable]
    public class ArenaTorusKnotJson
    {
        public readonly string object_type = "torusKnot";

        // torusKnot member-fields

        private static float defP = 2f;
        [JsonProperty(PropertyName = "p")]
        [Tooltip("P")]
        public float P = defP;
        public bool ShouldSerializeP()
        {
            // p
            return (P != defP);
        }

        private static float defQ = 3f;
        [JsonProperty(PropertyName = "q")]
        [Tooltip("Q")]
        public float Q = defQ;
        public bool ShouldSerializeQ()
        {
            // q
            return (Q != defQ);
        }

        private static float defRadius = 1f;
        [JsonProperty(PropertyName = "radius")]
        [Tooltip("radius")]
        public float Radius = defRadius;
        public bool ShouldSerializeRadius()
        {
            return true; // required in json schema
        }

        private static float defRadiusTubular = 0.2f;
        [JsonProperty(PropertyName = "radiusTubular")]
        [Tooltip("radius tubular")]
        public float RadiusTubular = defRadiusTubular;
        public bool ShouldSerializeRadiusTubular()
        {
            // radiusTubular
            return (RadiusTubular != defRadiusTubular);
        }

        private static int defSegmentsRadial = 8;
        [JsonProperty(PropertyName = "segmentsRadial")]
        [Tooltip("segments radial")]
        public int SegmentsRadial = defSegmentsRadial;
        public bool ShouldSerializeSegmentsRadial()
        {
            // segmentsRadial
            return (SegmentsRadial != defSegmentsRadial);
        }

        private static int defSegmentsTubular = 100;
        [JsonProperty(PropertyName = "segmentsTubular")]
        [Tooltip("segments tubular")]
        public int SegmentsTubular = defSegmentsTubular;
        public bool ShouldSerializeSegmentsTubular()
        {
            // segmentsTubular
            return (SegmentsTubular != defSegmentsTubular);
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
    }
}
