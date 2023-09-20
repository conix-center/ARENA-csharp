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
    /// ARENAUI element which displays text and optionally an image.
    /// </summary>
    [Serializable]
    public class ArenaArenauiCardJson
    {
        public readonly string object_type = "arenaui-card";

        // arenaui-card member-fields

        private static string defTitle = "";
        [JsonProperty(PropertyName = "title")]
        [Tooltip("Title")]
        public string Title = defTitle;
        public bool ShouldSerializeTitle()
        {
            return true; // required in json schema
        }

        private static string defBody = "";
        [JsonProperty(PropertyName = "body")]
        [Tooltip("This is the text body of the card.")]
        public string Body = defBody;
        public bool ShouldSerializeBody()
        {
            return true; // required in json schema
        }

        public enum BodyAlignType
        {
            [EnumMember(Value = "left")]
            Left,
            [EnumMember(Value = "center")]
            Center,
            [EnumMember(Value = "right")]
            Right,
            [EnumMember(Value = "justify")]
            Justify,
        }
        private static BodyAlignType defBodyAlign = BodyAlignType.Left;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "bodyAlign")]
        [Tooltip("Body Text Alignment")]
        public BodyAlignType BodyAlign = defBodyAlign;
        public bool ShouldSerializeBodyAlign()
        {
            // bodyAlign
            return (BodyAlign != defBodyAlign);
        }

        private static string defImg = "";
        [JsonProperty(PropertyName = "img")]
        [Tooltip("This image will be embedded alongside the body text")]
        public string Img = defImg;
        public bool ShouldSerializeImg()
        {
            return true; // required in json schema
        }

        private static string defImgCaption = "";
        [JsonProperty(PropertyName = "imgCaption")]
        [Tooltip("This will caption the image")]
        public string ImgCaption = defImgCaption;
        public bool ShouldSerializeImgCaption()
        {
            // imgCaption
            return (ImgCaption != defImgCaption);
        }

        public enum ImgDirectionType
        {
            [EnumMember(Value = "left")]
            Left,
            [EnumMember(Value = "right")]
            Right,
        }
        private static ImgDirectionType defImgDirection = ImgDirectionType.Right;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "imgDirection")]
        [Tooltip("Image Direction")]
        public ImgDirectionType ImgDirection = defImgDirection;
        public bool ShouldSerializeImgDirection()
        {
            // imgDirection
            return (ImgDirection != defImgDirection);
        }

        public enum ImgSizeType
        {
            [EnumMember(Value = "cover")]
            Cover,
            [EnumMember(Value = "contain")]
            Contain,
            [EnumMember(Value = "stretch")]
            Stretch,
        }
        private static ImgSizeType defImgSize = ImgSizeType.Cover;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "imgSize")]
        [Tooltip("Image sizing")]
        public ImgSizeType ImgSize = defImgSize;
        public bool ShouldSerializeImgSize()
        {
            // imgSize
            return (ImgSize != defImgSize);
        }

        private static float defFontSize = 0.035f;
        [JsonProperty(PropertyName = "fontSize")]
        [Tooltip("Font Size")]
        public float FontSize = defFontSize;
        public bool ShouldSerializeFontSize()
        {
            // fontSize
            return (FontSize != defFontSize);
        }

        private static float defWidthScale = 1f;
        [JsonProperty(PropertyName = "widthScale")]
        [Tooltip("Width scale multiplier")]
        public float WidthScale = defWidthScale;
        public bool ShouldSerializeWidthScale()
        {
            // widthScale
            return (WidthScale != defWidthScale);
        }

        private static bool defCloseButton = true;
        [JsonProperty(PropertyName = "closeButton")]
        [Tooltip("Show close button")]
        public bool CloseButton = defCloseButton;
        public bool ShouldSerializeCloseButton()
        {
            // closeButton
            return (CloseButton != defCloseButton);
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

        public static ArenaArenauiCardJson CreateFromJSON(string jsonString, JToken token)
        {
            ArenaArenauiCardJson json = null;
            try {
                json = JsonConvert.DeserializeObject<ArenaArenauiCardJson>(Regex.Unescape(jsonString));
            } catch (JsonReaderException e)
            {
                Debug.LogWarning($"{e.Message}: {jsonString}");
            }
            return json;
        }
    }
}
