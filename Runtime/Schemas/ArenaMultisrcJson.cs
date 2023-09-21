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
    /// Define multiple visual sources applied to an object.
    /// </summary>
    [Serializable]
    public class ArenaMultisrcJson
    {
        [JsonIgnore]
        public readonly string componentName = "multisrc";

        // multisrc member-fields

        private static string defSrcs = "";
        [JsonProperty(PropertyName = "srcs")]
        [Tooltip("A comma-delimited list if URIs, e.g. “side1.png, side2.png, side3.png, side4.png, side5.png, side6.png” (required).")]
        public string Srcs = defSrcs;
        public bool ShouldSerializeSrcs()
        {
            return true; // required in json schema
        }

        private static string defSrcspath = "";
        [JsonProperty(PropertyName = "srcspath")]
        [Tooltip("URI, relative or full path of a directory containing srcs, e.g. “store/users/wiselab/images/dice/” (required).")]
        public string Srcspath = defSrcspath;
        public bool ShouldSerializeSrcspath()
        {
            return true; // required in json schema
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
