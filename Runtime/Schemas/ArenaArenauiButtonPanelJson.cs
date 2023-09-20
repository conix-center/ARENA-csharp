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
    /// ARENAUI element which displays a vertical or horizontal panel of buttons.
    /// </summary>
    [Serializable]
    public class ArenaArenauiButtonPanelJson
    {
        public readonly string object_type = "arenaui-button-panel";

        // arenaui-button-panel member-fields

        private static object[] defButtons = {JsonConvert.DeserializeObject("{'name': 'Option 1'}"), JsonConvert.DeserializeObject("{'name': 'Option 2'}")};
        [JsonProperty(PropertyName = "buttons")]
        [Tooltip("Buttons")]
        public object[] Buttons = defButtons;
        public bool ShouldSerializeButtons()
        {
            return true; // required in json schema
        }

        private static string defTitle = "";
        [JsonProperty(PropertyName = "title")]
        [Tooltip("Title to display above buttons (optional).")]
        public string Title = defTitle;
        public bool ShouldSerializeTitle()
        {
            return true; // required in json schema
        }

        private static bool defVertical = false;
        [JsonProperty(PropertyName = "vertical")]
        [Tooltip("Vertical button layout")]
        public bool Vertical = defVertical;
        public bool ShouldSerializeVertical()
        {
            return true; // required in json schema
        }

        public enum FontType
        {
            [EnumMember(Value = "Roboto")]
            Roboto,
            [EnumMember(Value = "Roboto-Mono")]
            RobotoMono,
        }
        private static FontType defFont = FontType.Roboto;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "font")]
        [Tooltip("Font to use for button text")]
        public FontType Font = defFont;
        public bool ShouldSerializeFont()
        {
            // font
            return (Font != defFont);
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

        public static ArenaArenauiButtonPanelJson CreateFromJSON(string jsonString, JToken token)
        {
            ArenaArenauiButtonPanelJson json = null;
            try {
                json = JsonConvert.DeserializeObject<ArenaArenauiButtonPanelJson>(Regex.Unescape(jsonString));
            } catch (JsonReaderException e)
            {
                Debug.LogWarning($"{e.Message}: {jsonString}");
            }
            return json;
        }
    }
}
