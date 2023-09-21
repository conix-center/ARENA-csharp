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
    /// Attribution Component. Saves attribution data in any entity.
    /// </summary>
    [Serializable]
    public class ArenaAttributionJson
    {
        [JsonIgnore]
        public readonly string componentName = "attribution";

        // attribution member-fields

        private static string defAuthor = "Unknown";
        [JsonProperty(PropertyName = "author")]
        [Tooltip("Author name; e.g. “Vaptor-Studio”")]
        public string Author = defAuthor;
        public bool ShouldSerializeAuthor()
        {
            // author
            return (Author != defAuthor);
        }

        private static string defAuthorURL = "";
        [JsonProperty(PropertyName = "authorURL")]
        [Tooltip("Author homepage/profile; e.g. https://sketchfab.com/VapTor")]
        public string AuthorURL = defAuthorURL;
        public bool ShouldSerializeAuthorURL()
        {
            // authorURL
            return (AuthorURL != defAuthorURL);
        }

        private static string defLicense = "Unknown";
        [JsonProperty(PropertyName = "license")]
        [Tooltip("License summary/short name; e.g. “CC-BY-4.0”.")]
        public string License = defLicense;
        public bool ShouldSerializeLicense()
        {
            // license
            return (License != defLicense);
        }

        private static string defLicenseURL = "";
        [JsonProperty(PropertyName = "licenseURL")]
        [Tooltip("License URL; e.g. http://creativecommons.org/licenses/by/4.0/")]
        public string LicenseURL = defLicenseURL;
        public bool ShouldSerializeLicenseURL()
        {
            // licenseURL
            return (LicenseURL != defLicenseURL);
        }

        private static string defSource = "Unknown";
        [JsonProperty(PropertyName = "source")]
        [Tooltip("Model source e.g. “Sketchfab”.")]
        public string Source = defSource;
        public bool ShouldSerializeSource()
        {
            // source
            return (Source != defSource);
        }

        private static string defSourceURL = "";
        [JsonProperty(PropertyName = "sourceURL")]
        [Tooltip("Model source URL; e.g. https://sketchfab.com/models/2135501583704537907645bf723685e7")]
        public string SourceURL = defSourceURL;
        public bool ShouldSerializeSourceURL()
        {
            // sourceURL
            return (SourceURL != defSourceURL);
        }

        private static string defTitle = "No Title";
        [JsonProperty(PropertyName = "title")]
        [Tooltip("Model title; e.g. “Spinosaurus”.")]
        public string Title = defTitle;
        public bool ShouldSerializeTitle()
        {
            // title
            return (Title != defTitle);
        }

        private static bool defExtractAssetExtras = true;
        [JsonProperty(PropertyName = "extractAssetExtras")]
        [Tooltip("Extract attribution info from asset extras; will override attribution info given (default: true)")]
        public bool ExtractAssetExtras = defExtractAssetExtras;
        public bool ShouldSerializeExtractAssetExtras()
        {
            // extractAssetExtras
            return (ExtractAssetExtras != defExtractAssetExtras);
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
