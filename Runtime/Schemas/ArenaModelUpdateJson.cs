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
    /// The GLTF-specific `modelUpdate` attribute is an object with child component names as keys. The top-level keys are the names of the child components to be updated. The values of each are nested `position` and `rotation` attributes to set as new values, respectively. Either `position` or `rotation` can be omitted if unchanged.
    /// </summary>
    [Serializable]
    public class ArenaModelUpdateJson
    {
        [JsonIgnore]
        public readonly string componentName = "modelUpdate";

        // modelUpdate member-fields

        private static object defAZaZaZaZ09 = JsonConvert.DeserializeObject("");
        [JsonProperty(PropertyName = "^[A-Za-z][A-Za-z0-9_-]*$")]
        [Tooltip("One of this model's named child components.")]
        public object AZaZaZaZ09 = defAZaZaZaZ09;
        public bool ShouldSerializeAZaZaZaZ09()
        {
            // ^[A-Za-z][A-Za-z0-9_-]*$
            return (AZaZaZaZ09 != defAZaZaZaZ09);
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
