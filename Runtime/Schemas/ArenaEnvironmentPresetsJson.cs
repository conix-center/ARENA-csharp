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
    /// A-Frame Environment presets. More properties at <a href='https://github.com/supermedium/aframe-environment-component'>https://github.com/supermedium/aframe-environment-component</a>
    /// </summary>
    [Serializable]
    public class ArenaEnvironmentPresetsJson
    {
        [JsonIgnore]
        public readonly string componentName = "environment-presets";

        // environment-presets member-fields

        private static bool defActive = true;
        [JsonProperty(PropertyName = "active")]
        [Tooltip("Show/hides the environment presets component. Use this instead of using the visible attribute.")]
        public bool Active = defActive;
        public bool ShouldSerializeActive()
        {
            return true; // required in json schema
        }

        public enum DressingType
        {
            [EnumMember(Value = "apparatus")]
            Apparatus,
            [EnumMember(Value = "arches")]
            Arches,
            [EnumMember(Value = "cubes")]
            Cubes,
            [EnumMember(Value = "cylinders")]
            Cylinders,
            [EnumMember(Value = "hexagons")]
            Hexagons,
            [EnumMember(Value = "mushrooms")]
            Mushrooms,
            [EnumMember(Value = "none")]
            None,
            [EnumMember(Value = "pyramids")]
            Pyramids,
            [EnumMember(Value = "stones")]
            Stones,
            [EnumMember(Value = "torii")]
            Torii,
            [EnumMember(Value = "towers")]
            Towers,
            [EnumMember(Value = "trees")]
            Trees,
        }
        private static DressingType defDressing = DressingType.None;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "dressing")]
        [Tooltip("Dressing is the term we use here for the set of additional objects that are put on the ground for decoration.")]
        public DressingType Dressing = defDressing;
        public bool ShouldSerializeDressing()
        {
            // dressing
            return (Dressing != defDressing);
        }

        private static float defDressingAmount = 10f;
        [JsonProperty(PropertyName = "dressingAmount")]
        [Tooltip("Number of objects used for dressing")]
        public float DressingAmount = defDressingAmount;
        public bool ShouldSerializeDressingAmount()
        {
            // dressingAmount
            return (DressingAmount != defDressingAmount);
        }

        private static string defDressingColor = "#795449";
        [JsonProperty(PropertyName = "dressingColor")]
        [Tooltip("Base color of dressing objects.")]
        public string DressingColor = defDressingColor;
        public bool ShouldSerializeDressingColor()
        {
            // dressingColor
            return (DressingColor != defDressingColor);
        }

        private static float defDressingOnPlayArea = 0f;
        [JsonProperty(PropertyName = "dressingOnPlayArea")]
        [Tooltip("Amount of dressing on play area.")]
        public float DressingOnPlayArea = defDressingOnPlayArea;
        public bool ShouldSerializeDressingOnPlayArea()
        {
            // dressingOnPlayArea
            return (DressingOnPlayArea != defDressingOnPlayArea);
        }

        private static float defDressingScale = 5f;
        [JsonProperty(PropertyName = "dressingScale")]
        [Tooltip("Height (in meters) of dressing objects.")]
        public float DressingScale = defDressingScale;
        public bool ShouldSerializeDressingScale()
        {
            // dressingScale
            return (DressingScale != defDressingScale);
        }

        private static bool defDressingUniformScale = true;
        [JsonProperty(PropertyName = "dressingUniformScale")]
        [Tooltip("If false, a different value is used for each coordinate x, y, z in the random variance of size.")]
        public bool DressingUniformScale = defDressingUniformScale;
        public bool ShouldSerializeDressingUniformScale()
        {
            // dressingUniformScale
            return (DressingUniformScale != defDressingUniformScale);
        }

        private static object defDressingVariance = JsonConvert.DeserializeObject("{'x': 1, 'y': 1, 'z': 1}");
        [JsonProperty(PropertyName = "dressingVariance")]
        [Tooltip("Maximum x,y,z meters to randomize the size and rotation of each dressing object. Use 0 0 0 for no variation in size nor rotation.")]
        public object DressingVariance = defDressingVariance;
        public bool ShouldSerializeDressingVariance()
        {
            // dressingVariance
            return (DressingVariance != defDressingVariance);
        }

        private static bool defFlatShading = false;
        [JsonProperty(PropertyName = "flatShading")]
        [Tooltip("Whether to show everything smoothed (false) or polygonal (true).")]
        public bool FlatShading = defFlatShading;
        public bool ShouldSerializeFlatShading()
        {
            // flatShading
            return (FlatShading != defFlatShading);
        }

        private static float defFog = 0f;
        [JsonProperty(PropertyName = "fog")]
        [Tooltip("Amount of fog (0 = none, 1 = full fog). The color is estimated automatically.")]
        public float Fog = defFog;
        public bool ShouldSerializeFog()
        {
            // fog
            return (Fog != defFog);
        }

        public enum GridType
        {
            [EnumMember(Value = "1x1")]
            Onex1,
            [EnumMember(Value = "2x2")]
            Twox2,
            [EnumMember(Value = "crosses")]
            Crosses,
            [EnumMember(Value = "dots")]
            Dots,
            [EnumMember(Value = "none")]
            None,
            [EnumMember(Value = "xlines")]
            Xlines,
            [EnumMember(Value = "ylines")]
            Ylines,
        }
        private static GridType defGrid = GridType.None;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "grid")]
        [Tooltip("1x1 and 2x2 are rectangular grids of 1 and 2 meters side, respectively.")]
        public GridType Grid = defGrid;
        public bool ShouldSerializeGrid()
        {
            // grid
            return (Grid != defGrid);
        }

        private static string defGridColor = "#ccc";
        [JsonProperty(PropertyName = "gridColor")]
        [Tooltip("Color of the grid.")]
        public string GridColor = defGridColor;
        public bool ShouldSerializeGridColor()
        {
            // gridColor
            return (GridColor != defGridColor);
        }

        public enum GroundType
        {
            [EnumMember(Value = "canyon")]
            Canyon,
            [EnumMember(Value = "flat")]
            Flat,
            [EnumMember(Value = "hills")]
            Hills,
            [EnumMember(Value = "noise")]
            Noise,
            [EnumMember(Value = "none")]
            None,
            [EnumMember(Value = "spikes")]
            Spikes,
        }
        private static GroundType defGround = GroundType.Hills;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "ground")]
        [Tooltip("Orography style.")]
        public GroundType Ground = defGround;
        public bool ShouldSerializeGround()
        {
            // ground
            return (Ground != defGround);
        }

        private static string defGroundColor = "#553e35";
        [JsonProperty(PropertyName = "groundColor")]
        [Tooltip("Main color of the ground.")]
        public string GroundColor = defGroundColor;
        public bool ShouldSerializeGroundColor()
        {
            // groundColor
            return (GroundColor != defGroundColor);
        }

        private static string defGroundColor2 = "#694439";
        [JsonProperty(PropertyName = "groundColor2")]
        [Tooltip("Secondary color of the ground. Used for textures, ignored if groundTexture is none.")]
        public string GroundColor2 = defGroundColor2;
        public bool ShouldSerializeGroundColor2()
        {
            // groundColor2
            return (GroundColor2 != defGroundColor2);
        }

        private static object defGroundScale = JsonConvert.DeserializeObject("{'x': 1, 'y': 1, 'z': 1}");
        [JsonProperty(PropertyName = "groundScale")]
        [Tooltip("Ground dimensions (in meters).")]
        public object GroundScale = defGroundScale;
        public bool ShouldSerializeGroundScale()
        {
            // groundScale
            return (GroundScale != defGroundScale);
        }

        public enum GroundTextureType
        {
            [EnumMember(Value = "checkerboard")]
            Checkerboard,
            [EnumMember(Value = "none")]
            None,
            [EnumMember(Value = "squares")]
            Squares,
            [EnumMember(Value = "walkernoise")]
            Walkernoise,
        }
        private static GroundTextureType defGroundTexture = GroundTextureType.None;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "groundTexture")]
        [Tooltip("Texture applied to the ground.")]
        public GroundTextureType GroundTexture = defGroundTexture;
        public bool ShouldSerializeGroundTexture()
        {
            // groundTexture
            return (GroundTexture != defGroundTexture);
        }

        private static float defGroundYScale = 3f;
        [JsonProperty(PropertyName = "groundYScale")]
        [Tooltip("Maximum height (in meters) of ground's features (hills, mountains, peaks..).")]
        public float GroundYScale = defGroundYScale;
        public bool ShouldSerializeGroundYScale()
        {
            // groundYScale
            return (GroundYScale != defGroundYScale);
        }

        private static bool defHideInAR = true;
        [JsonProperty(PropertyName = "hideInAR")]
        [Tooltip("If true, hide the environment when entering AR.")]
        public bool HideInAR = defHideInAR;
        public bool ShouldSerializeHideInAR()
        {
            // hideInAR
            return (HideInAR != defHideInAR);
        }

        private static string defHorizonColor = "#ffa500";
        [JsonProperty(PropertyName = "horizonColor")]
        [Tooltip("Horizon Color")]
        public string HorizonColor = defHorizonColor;
        public bool ShouldSerializeHorizonColor()
        {
            // horizonColor
            return (HorizonColor != defHorizonColor);
        }

        public enum LightingType
        {
            [EnumMember(Value = "distant")]
            Distant,
            [EnumMember(Value = "none")]
            None,
            [EnumMember(Value = "point")]
            Point,
        }
        private static LightingType defLighting = LightingType.Distant;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "lighting")]
        [Tooltip("A hemisphere light and a key light (directional or point) are added to the scene automatically when using the component. Use none if you don't want this automatic lighting set being added. The color and intensity are estimated automatically.")]
        public LightingType Lighting = defLighting;
        public bool ShouldSerializeLighting()
        {
            // lighting
            return (Lighting != defLighting);
        }

        private static object defLightPosition = JsonConvert.DeserializeObject("{'x': 0, 'y': 1, 'z': -0.2}");
        [JsonProperty(PropertyName = "lightPosition")]
        [Tooltip("Position of the main light. If skyType is atmospheric, only the orientation matters (is a directional light) and it can turn the scene into night when lowered towards the horizon.")]
        public object LightPosition = defLightPosition;
        public bool ShouldSerializeLightPosition()
        {
            // lightPosition
            return (LightPosition != defLightPosition);
        }

        private static float defPlayArea = 1f;
        [JsonProperty(PropertyName = "playArea")]
        [Tooltip("Radius of the area in the center reserved for the player and the gameplay. The ground is flat in there and no objects are placed inside.")]
        public float PlayArea = defPlayArea;
        public bool ShouldSerializePlayArea()
        {
            // playArea
            return (PlayArea != defPlayArea);
        }

        public enum PresetType
        {
            [EnumMember(Value = "arches")]
            Arches,
            [EnumMember(Value = "checkerboard")]
            Checkerboard,
            [EnumMember(Value = "contact")]
            Contact,
            [EnumMember(Value = "default")]
            Default,
            [EnumMember(Value = "dream")]
            Dream,
            [EnumMember(Value = "egypt")]
            Egypt,
            [EnumMember(Value = "forest")]
            Forest,
            [EnumMember(Value = "goaland")]
            Goaland,
            [EnumMember(Value = "goldmine")]
            Goldmine,
            [EnumMember(Value = "japan")]
            Japan,
            [EnumMember(Value = "none")]
            None,
            [EnumMember(Value = "osiris")]
            Osiris,
            [EnumMember(Value = "poison")]
            Poison,
            [EnumMember(Value = "starry")]
            Starry,
            [EnumMember(Value = "threetowers")]
            Threetowers,
            [EnumMember(Value = "tron")]
            Tron,
            [EnumMember(Value = "volcano")]
            Volcano,
            [EnumMember(Value = "yavapai")]
            Yavapai,
        }
        private static PresetType defPreset = PresetType.Default;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "preset")]
        [Tooltip("An A-frame preset environment.")]
        public PresetType Preset = defPreset;
        public bool ShouldSerializePreset()
        {
            return true; // required in json schema
        }

        private static float defSeed = 1f;
        [JsonProperty(PropertyName = "seed")]
        [Tooltip("Seed for randomization. If you don't like the layout of the elements, try another value for the seed.")]
        public float Seed = defSeed;
        public bool ShouldSerializeSeed()
        {
            // seed
            return (Seed != defSeed);
        }

        private static bool defShadow = false;
        [JsonProperty(PropertyName = "shadow")]
        [Tooltip("Shadows on/off. Sky light casts shadows on the ground of all those objects with shadow component applied")]
        public bool Shadow = defShadow;
        public bool ShouldSerializeShadow()
        {
            // shadow
            return (Shadow != defShadow);
        }

        private static float defShadowSize = 10f;
        [JsonProperty(PropertyName = "shadowSize")]
        [Tooltip("Size of the shadow, if applied")]
        public float ShadowSize = defShadowSize;
        public bool ShouldSerializeShadowSize()
        {
            // shadowSize
            return (ShadowSize != defShadowSize);
        }

        private static string defSkyColor = "#ffa500";
        [JsonProperty(PropertyName = "skyColor")]
        [Tooltip("Sky Color")]
        public string SkyColor = defSkyColor;
        public bool ShouldSerializeSkyColor()
        {
            // skyColor
            return (SkyColor != defSkyColor);
        }

        public enum SkyTypeType
        {
            [EnumMember(Value = "atmosphere")]
            Atmosphere,
            [EnumMember(Value = "color")]
            Color,
            [EnumMember(Value = "gradient")]
            Gradient,
            [EnumMember(Value = "none")]
            None,
        }
        private static SkyTypeType defSkyType = SkyTypeType.Color;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "skyType")]
        [Tooltip("A sky type")]
        public SkyTypeType SkyType = defSkyType;
        public bool ShouldSerializeSkyType()
        {
            // skyType
            return (SkyType != defSkyType);
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
