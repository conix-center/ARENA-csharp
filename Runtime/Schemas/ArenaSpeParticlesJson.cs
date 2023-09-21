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
    /// GPU based particle systems in A-Frame. More properties at <a href='https://github.com/harlyq/aframe-spe-particles-component'>https://github.com/harlyq/aframe-spe-particles-component</a>
    /// </summary>
    [Serializable]
    public class ArenaSpeParticlesJson
    {
        [JsonIgnore]
        public readonly string componentName = "spe-particles";

        // spe-particles member-fields

        private static object defAcceleration = JsonConvert.DeserializeObject("{x: 0, y: 0, z: 0}");
        [JsonProperty(PropertyName = "acceleration")]
        [Tooltip("for sphere and disc distributions, only the x axis is used")]
        public object Acceleration = defAcceleration;
        public bool ShouldSerializeAcceleration()
        {
            // acceleration
            return (Acceleration != defAcceleration);
        }

        public enum AccelerationDistributionType
        {
            [EnumMember(Value = "none")]
            None,
            [EnumMember(Value = "box")]
            Box,
            [EnumMember(Value = "sphere")]
            Sphere,
            [EnumMember(Value = "disc")]
            Disc,
        }
        private static AccelerationDistributionType defAccelerationDistribution = AccelerationDistributionType.None;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "accelerationDistribution")]
        [Tooltip("distribution of particle acceleration, for disc and sphere, only the x component will be used. if set to NONE use the 'distribution' attribute for accelerationDistribution")]
        public AccelerationDistributionType AccelerationDistribution = defAccelerationDistribution;
        public bool ShouldSerializeAccelerationDistribution()
        {
            // accelerationDistribution
            return (AccelerationDistribution != defAccelerationDistribution);
        }

        private static object defAccelerationSpread = JsonConvert.DeserializeObject("{x: 0, y: 0, z: 0}");
        [JsonProperty(PropertyName = "accelerationSpread")]
        [Tooltip("spread of the particle's acceleration. for sphere and disc distributions, only the x axis is used")]
        public object AccelerationSpread = defAccelerationSpread;
        public bool ShouldSerializeAccelerationSpread()
        {
            // accelerationSpread
            return (AccelerationSpread != defAccelerationSpread);
        }

        private static float defActiveMultiplier = 1f;
        [JsonProperty(PropertyName = "activeMultiplier")]
        [Tooltip("multiply the rate of particles emission, if larger than 1 then the particles will be emitted in bursts. note, very large numbers will emit all particles at once")]
        public float ActiveMultiplier = defActiveMultiplier;
        public bool ShouldSerializeActiveMultiplier()
        {
            // activeMultiplier
            return (ActiveMultiplier != defActiveMultiplier);
        }

        private static bool defAffectedByFog = true;
        [JsonProperty(PropertyName = "affectedByFog")]
        [Tooltip("if true, the particles are affected by THREE js fog")]
        public bool AffectedByFog = defAffectedByFog;
        public bool ShouldSerializeAffectedByFog()
        {
            // affectedByFog
            return (AffectedByFog != defAffectedByFog);
        }

        private static float defAlphaTest = 0f;
        [JsonProperty(PropertyName = "alphaTest")]
        [Tooltip("alpha values below the alphaTest threshold are considered invisible")]
        public float AlphaTest = defAlphaTest;
        public bool ShouldSerializeAlphaTest()
        {
            // alphaTest
            return (AlphaTest != defAlphaTest);
        }

        private static float[] defAngle = {0};
        [JsonProperty(PropertyName = "angle")]
        [Tooltip("2D rotation of the particle over the particle's lifetime, max 4 elements")]
        public float[] Angle = defAngle;
        public bool ShouldSerializeAngle()
        {
            // angle
            return (Angle != defAngle);
        }

        private static float[] defAngleSpread = {0};
        [JsonProperty(PropertyName = "angleSpread")]
        [Tooltip("spread in angle over the particle's lifetime, max 4 elements")]
        public float[] AngleSpread = defAngleSpread;
        public bool ShouldSerializeAngleSpread()
        {
            // angleSpread
            return (AngleSpread != defAngleSpread);
        }

        public enum BlendingType
        {
            [EnumMember(Value = "no")]
            No,
            [EnumMember(Value = "normal")]
            Normal,
            [EnumMember(Value = "additive")]
            Additive,
            [EnumMember(Value = "subtractive")]
            Subtractive,
            [EnumMember(Value = "multiply")]
            Multiply,
            [EnumMember(Value = "custom")]
            Custom,
        }
        private static BlendingType defBlending = BlendingType.Normal;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "blending")]
        [Tooltip("blending mode, when drawing particles")]
        public BlendingType Blending = defBlending;
        public bool ShouldSerializeBlending()
        {
            // blending
            return (Blending != defBlending);
        }

        private static string[] defColor = {"#fff"};
        [JsonProperty(PropertyName = "color")]
        [Tooltip("array of colors over the particle's lifetime, max 4 elements")]
        public string[] Color = defColor;
        public bool ShouldSerializeColor()
        {
            // color
            return (Color != defColor);
        }

        private static string[] defColorSpread = { };
        [JsonProperty(PropertyName = "colorSpread")]
        [Tooltip("spread to apply to colors, spread an array of vec3 (r g b) with 0 for no spread. note the spread will be re-applied through-out the lifetime of the particle")]
        public string[] ColorSpread = defColorSpread;
        public bool ShouldSerializeColorSpread()
        {
            // colorSpread
            return (ColorSpread != defColorSpread);
        }

        private static bool defDepthTest = true;
        [JsonProperty(PropertyName = "depthTest")]
        [Tooltip("if true, don't render a particle's pixels if something is closer in the depth buffer")]
        public bool DepthTest = defDepthTest;
        public bool ShouldSerializeDepthTest()
        {
            // depthTest
            return (DepthTest != defDepthTest);
        }

        private static bool defDepthWrite = false;
        [JsonProperty(PropertyName = "depthWrite")]
        [Tooltip("if true, particles write their depth into the depth buffer. this should be false if we use transparent particles")]
        public bool DepthWrite = defDepthWrite;
        public bool ShouldSerializeDepthWrite()
        {
            // depthWrite
            return (DepthWrite != defDepthWrite);
        }

        public enum DirectionType
        {
            [EnumMember(Value = "forward")]
            Forward,
            [EnumMember(Value = "backward")]
            Backward,
        }
        private static DirectionType defDirection = DirectionType.Forward;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "direction")]
        [Tooltip("make the emitter operate forward or backward in time")]
        public DirectionType Direction = defDirection;
        public bool ShouldSerializeDirection()
        {
            // direction
            return (Direction != defDirection);
        }

        public enum DistributionType
        {
            [EnumMember(Value = "box")]
            Box,
            [EnumMember(Value = "sphere")]
            Sphere,
            [EnumMember(Value = "disc")]
            Disc,
        }
        private static DistributionType defDistribution = DistributionType.Box;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "distribution")]
        [Tooltip("distribution for particle positions, velocities and acceleration. will be overriden by specific '...Distribution' attributes")]
        public DistributionType Distribution = defDistribution;
        public bool ShouldSerializeDistribution()
        {
            // distribution
            return (Distribution != defDistribution);
        }

        private static float defDrag = 0f;
        [JsonProperty(PropertyName = "drag")]
        [Tooltip("apply resistance to moving the particle, 0 is no resistance, 1 is full resistance, particle will stop moving at half of it's maxAge")]
        public float Drag = defDrag;
        public bool ShouldSerializeDrag()
        {
            // drag
            return (Drag != defDrag);
        }

        private static float defDragSpread = 0f;
        [JsonProperty(PropertyName = "dragSpread")]
        [Tooltip("spread to apply to the drag attribute")]
        public float DragSpread = defDragSpread;
        public bool ShouldSerializeDragSpread()
        {
            // dragSpread
            return (DragSpread != defDragSpread);
        }

        private static float defDuration = -1f;
        [JsonProperty(PropertyName = "duration")]
        [Tooltip("duration of the emitter (seconds), if less than 0 then continuously emit particles")]
        public float Duration = defDuration;
        public bool ShouldSerializeDuration()
        {
            // duration
            return (Duration != defDuration);
        }

        private static float defEmitterScale = 100f;
        [JsonProperty(PropertyName = "emitterScale")]
        [Tooltip("global scaling factor for all particles from the emitter")]
        public float EmitterScale = defEmitterScale;
        public bool ShouldSerializeEmitterScale()
        {
            // emitterScale
            return (EmitterScale != defEmitterScale);
        }

        private static bool defEnableInEditor = false;
        [JsonProperty(PropertyName = "enableInEditor")]
        [Tooltip("enable the emitter while the editor is active (i.e. while scene is paused)")]
        public bool EnableInEditor = defEnableInEditor;
        public bool ShouldSerializeEnableInEditor()
        {
            // enableInEditor
            return (EnableInEditor != defEnableInEditor);
        }

        private static bool defEnabled = true;
        [JsonProperty(PropertyName = "enabled")]
        [Tooltip("enable/disable the emitter")]
        public bool Enabled = defEnabled;
        public bool ShouldSerializeEnabled()
        {
            // enabled
            return (Enabled != defEnabled);
        }

        private static bool defFrustumCulled = false;
        [JsonProperty(PropertyName = "frustumCulled")]
        [Tooltip("enable/disable frustum culling")]
        public bool FrustumCulled = defFrustumCulled;
        public bool ShouldSerializeFrustumCulled()
        {
            // frustumCulled
            return (FrustumCulled != defFrustumCulled);
        }

        private static bool defHasPerspective = true;
        [JsonProperty(PropertyName = "hasPerspective")]
        [Tooltip("if true, particles will be larger the closer they are to the camera")]
        public bool HasPerspective = defHasPerspective;
        public bool ShouldSerializeHasPerspective()
        {
            // hasPerspective
            return (HasPerspective != defHasPerspective);
        }

        private static float defMaxAge = 1f;
        [JsonProperty(PropertyName = "maxAge")]
        [Tooltip("maximum age of a particle before reusing")]
        public float MaxAge = defMaxAge;
        public bool ShouldSerializeMaxAge()
        {
            // maxAge
            return (MaxAge != defMaxAge);
        }

        private static float defMaxAgeSpread = 0f;
        [JsonProperty(PropertyName = "maxAgeSpread")]
        [Tooltip("variance for the 'maxAge' attribute")]
        public float MaxAgeSpread = defMaxAgeSpread;
        public bool ShouldSerializeMaxAgeSpread()
        {
            // maxAgeSpread
            return (MaxAgeSpread != defMaxAgeSpread);
        }

        private static float[] defOpacity = {1};
        [JsonProperty(PropertyName = "opacity")]
        [Tooltip("opacity over the particle's lifetime, max 4 elements")]
        public float[] Opacity = defOpacity;
        public bool ShouldSerializeOpacity()
        {
            // opacity
            return (Opacity != defOpacity);
        }

        private static float[] defOpacitySpread = {0};
        [JsonProperty(PropertyName = "opacitySpread")]
        [Tooltip("spread in opacity over the particle's lifetime, max 4 elements")]
        public float[] OpacitySpread = defOpacitySpread;
        public bool ShouldSerializeOpacitySpread()
        {
            // opacitySpread
            return (OpacitySpread != defOpacitySpread);
        }

        private static int defParticleCount = 100;
        [JsonProperty(PropertyName = "particleCount")]
        [Tooltip("maximum number of particles for this emitter")]
        public int ParticleCount = defParticleCount;
        public bool ShouldSerializeParticleCount()
        {
            // particleCount
            return (ParticleCount != defParticleCount);
        }

        public enum PositionDistributionType
        {
            [EnumMember(Value = "none")]
            None,
            [EnumMember(Value = "box")]
            Box,
            [EnumMember(Value = "sphere")]
            Sphere,
            [EnumMember(Value = "disc")]
            Disc,
        }
        private static PositionDistributionType defPositionDistribution = PositionDistributionType.None;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "positionDistribution")]
        [Tooltip("distribution of particle positions, disc and sphere will use the radius attributes. For box particles emit at 0,0,0, for sphere they emit on the surface of the sphere and for disc on the edge of a 2D disc on the XY plane")]
        public PositionDistributionType PositionDistribution = defPositionDistribution;
        public bool ShouldSerializePositionDistribution()
        {
            // positionDistribution
            return (PositionDistribution != defPositionDistribution);
        }

        private static object defPositionOffset = JsonConvert.DeserializeObject("{x: 0, y: 0, z: 0}");
        [JsonProperty(PropertyName = "positionOffset")]
        [Tooltip("fixed offset to the apply to the emitter relative to its parent entity")]
        public object PositionOffset = defPositionOffset;
        public bool ShouldSerializePositionOffset()
        {
            // positionOffset
            return (PositionOffset != defPositionOffset);
        }

        private static object defPositionSpread = JsonConvert.DeserializeObject("{x: 0, y: 0, z: 0}");
        [JsonProperty(PropertyName = "positionSpread")]
        [Tooltip("particles are positioned within +- of these local bounds. for sphere and disc distributions only the x axis is used")]
        public object PositionSpread = defPositionSpread;
        public bool ShouldSerializePositionSpread()
        {
            // positionSpread
            return (PositionSpread != defPositionSpread);
        }

        private static float defRadius = 1f;
        [JsonProperty(PropertyName = "radius")]
        [Tooltip("radius of the disc or sphere emitter (ignored for box). note radius of 0 will prevent velocity and acceleration if they use a sphere or disc distribution")]
        public float Radius = defRadius;
        public bool ShouldSerializeRadius()
        {
            // radius
            return (Radius != defRadius);
        }

        private static object defRadiusScale = JsonConvert.DeserializeObject("{x: 1, y: 1, z: 1}");
        [JsonProperty(PropertyName = "radiusScale")]
        [Tooltip("scales the emitter for sphere and disc shapes to form oblongs and ellipses")]
        public object RadiusScale = defRadiusScale;
        public bool ShouldSerializeRadiusScale()
        {
            // radiusScale
            return (RadiusScale != defRadiusScale);
        }

        private static bool defRandomizeAcceleration = false;
        [JsonProperty(PropertyName = "randomizeAcceleration")]
        [Tooltip("if true, re-randomize acceleration when re-spawning a particle, can incur a performance hit")]
        public bool RandomizeAcceleration = defRandomizeAcceleration;
        public bool ShouldSerializeRandomizeAcceleration()
        {
            // randomizeAcceleration
            return (RandomizeAcceleration != defRandomizeAcceleration);
        }

        private static bool defRandomizeAngle = false;
        [JsonProperty(PropertyName = "randomizeAngle")]
        [Tooltip("if true, re-randomize angle when re-spawning a particle, can incur a performance hit")]
        public bool RandomizeAngle = defRandomizeAngle;
        public bool ShouldSerializeRandomizeAngle()
        {
            // randomizeAngle
            return (RandomizeAngle != defRandomizeAngle);
        }

        private static bool defRandomizeColor = false;
        [JsonProperty(PropertyName = "randomizeColor")]
        [Tooltip("if true, re-randomize colour when re-spawning a particle, can incur a performance hit")]
        public bool RandomizeColor = defRandomizeColor;
        public bool ShouldSerializeRandomizeColor()
        {
            // randomizeColor
            return (RandomizeColor != defRandomizeColor);
        }

        private static bool defRandomizeDrag = false;
        [JsonProperty(PropertyName = "randomizeDrag")]
        [Tooltip("if true, re-randomize drag when re-spawning a particle, can incur a performance hit")]
        public bool RandomizeDrag = defRandomizeDrag;
        public bool ShouldSerializeRandomizeDrag()
        {
            // randomizeDrag
            return (RandomizeDrag != defRandomizeDrag);
        }

        private static bool defRandomizeOpacity = false;
        [JsonProperty(PropertyName = "randomizeOpacity")]
        [Tooltip("if true, re-randomize opacity when re-spawning a particle, can incur a performance hit")]
        public bool RandomizeOpacity = defRandomizeOpacity;
        public bool ShouldSerializeRandomizeOpacity()
        {
            // randomizeOpacity
            return (RandomizeOpacity != defRandomizeOpacity);
        }

        private static bool defRandomizePosition = false;
        [JsonProperty(PropertyName = "randomizePosition")]
        [Tooltip("if true, re-randomize position when re-spawning a particle, can incur a performance hit")]
        public bool RandomizePosition = defRandomizePosition;
        public bool ShouldSerializeRandomizePosition()
        {
            // randomizePosition
            return (RandomizePosition != defRandomizePosition);
        }

        private static bool defRandomizeRotation = false;
        [JsonProperty(PropertyName = "randomizeRotation")]
        [Tooltip("if true, re-randomize rotation when re-spawning a particle, can incur a performance hit")]
        public bool RandomizeRotation = defRandomizeRotation;
        public bool ShouldSerializeRandomizeRotation()
        {
            // randomizeRotation
            return (RandomizeRotation != defRandomizeRotation);
        }

        private static bool defRandomizeSize = false;
        [JsonProperty(PropertyName = "randomizeSize")]
        [Tooltip("if true, re-randomize size when re-spawning a particle, can incur a performance hit")]
        public bool RandomizeSize = defRandomizeSize;
        public bool ShouldSerializeRandomizeSize()
        {
            // randomizeSize
            return (RandomizeSize != defRandomizeSize);
        }

        private static bool defRandomizeVelocity = false;
        [JsonProperty(PropertyName = "randomizeVelocity")]
        [Tooltip("if true, re-randomize velocity when re-spawning a particle, can incur a performance hit")]
        public bool RandomizeVelocity = defRandomizeVelocity;
        public bool ShouldSerializeRandomizeVelocity()
        {
            // randomizeVelocity
            return (RandomizeVelocity != defRandomizeVelocity);
        }

        public enum RelativeType
        {
            [EnumMember(Value = "local")]
            Local,
            [EnumMember(Value = "world")]
            World,
        }
        private static RelativeType defRelative = RelativeType.Local;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "relative")]
        [Tooltip("world relative particles move relative to the world, while local particles move relative to the emitter (i.e. if the emitter moves, all particles move with it)")]
        public RelativeType Relative = defRelative;
        public bool ShouldSerializeRelative()
        {
            // relative
            return (Relative != defRelative);
        }

        private static float defRotation = 0f;
        [JsonProperty(PropertyName = "rotation")]
        [Tooltip("rotation in degrees")]
        public float Rotation = defRotation;
        public bool ShouldSerializeRotation()
        {
            // rotation
            return (Rotation != defRotation);
        }

        private static object defRotationAxis = JsonConvert.DeserializeObject("{x: 0, y: 0, z: 0}");
        [JsonProperty(PropertyName = "rotationAxis")]
        [Tooltip("local axis when using rotation")]
        public object RotationAxis = defRotationAxis;
        public bool ShouldSerializeRotationAxis()
        {
            // rotationAxis
            return (RotationAxis != defRotationAxis);
        }

        private static object defRotationAxisSpread = JsonConvert.DeserializeObject("{x: 0, y: 0, z: 0}");
        [JsonProperty(PropertyName = "rotationAxisSpread")]
        [Tooltip("variance in the axis of rotation")]
        public object RotationAxisSpread = defRotationAxisSpread;
        public bool ShouldSerializeRotationAxisSpread()
        {
            // rotationAxisSpread
            return (RotationAxisSpread != defRotationAxisSpread);
        }

        private static float defRotationSpread = 0f;
        [JsonProperty(PropertyName = "rotationSpread")]
        [Tooltip("rotation variance in degrees")]
        public float RotationSpread = defRotationSpread;
        public bool ShouldSerializeRotationSpread()
        {
            // rotationSpread
            return (RotationSpread != defRotationSpread);
        }

        private static bool defRotationStatic = false;
        [JsonProperty(PropertyName = "rotationStatic")]
        [Tooltip("if true, the particles are fixed at their initial rotation value. if false, the particle will rotate from 0 to the 'rotation' value")]
        public bool RotationStatic = defRotationStatic;
        public bool ShouldSerializeRotationStatic()
        {
            // rotationStatic
            return (RotationStatic != defRotationStatic);
        }

        private static float[] defSize = {1};
        [JsonProperty(PropertyName = "size")]
        [Tooltip("array of sizes over the particle's lifetime, max 4 elements")]
        public float[] Size = defSize;
        public bool ShouldSerializeSize()
        {
            // size
            return (Size != defSize);
        }

        private static float[] defSizeSpread = {0};
        [JsonProperty(PropertyName = "sizeSpread")]
        [Tooltip("spread in size over the particle's lifetime, max 4 elements")]
        public float[] SizeSpread = defSizeSpread;
        public bool ShouldSerializeSizeSpread()
        {
            // sizeSpread
            return (SizeSpread != defSizeSpread);
        }

        private static string defTexture = "";
        [JsonProperty(PropertyName = "texture")]
        [Tooltip("texture to be used for each particle, may be a spritesheet.  Examples: [blob.png, fog.png, square.png, explosion_sheet.png, fireworks_sheet.png], like path 'static/images/textures/blob.png'")]
        public string Texture = defTexture;
        public bool ShouldSerializeTexture()
        {
            // texture
            return (Texture != defTexture);
        }

        private static int defTextureFrameCount = -1;
        [JsonProperty(PropertyName = "textureFrameCount")]
        [Tooltip("number of frames in the spritesheet, negative numbers default to textureFrames.x * textureFrames.y")]
        public int TextureFrameCount = defTextureFrameCount;
        public bool ShouldSerializeTextureFrameCount()
        {
            // textureFrameCount
            return (TextureFrameCount != defTextureFrameCount);
        }

        private static int defTextureFrameLoop = 1;
        [JsonProperty(PropertyName = "textureFrameLoop")]
        [Tooltip("number of times the spritesheet should be looped over the lifetime of a particle")]
        public int TextureFrameLoop = defTextureFrameLoop;
        public bool ShouldSerializeTextureFrameLoop()
        {
            // textureFrameLoop
            return (TextureFrameLoop != defTextureFrameLoop);
        }

        private static object defTextureFrames = JsonConvert.DeserializeObject("{x: 1, y: 1}");
        [JsonProperty(PropertyName = "textureFrames")]
        [Tooltip("x and y frames for a spritesheet. each particle will transition through every frame of the spritesheet over its lifetime (see textureFramesLoop)")]
        public object TextureFrames = defTextureFrames;
        public bool ShouldSerializeTextureFrames()
        {
            // textureFrames
            return (TextureFrames != defTextureFrames);
        }

        private static bool defUseTransparency = true;
        [JsonProperty(PropertyName = "useTransparency")]
        [Tooltip("should the particles be rendered with transparency?")]
        public bool UseTransparency = defUseTransparency;
        public bool ShouldSerializeUseTransparency()
        {
            // useTransparency
            return (UseTransparency != defUseTransparency);
        }

        private static object defVelocity = JsonConvert.DeserializeObject("{x: 0, y: 0, z: 0}");
        [JsonProperty(PropertyName = "velocity")]
        [Tooltip("for sphere and disc distributions, only the x axis is used")]
        public object Velocity = defVelocity;
        public bool ShouldSerializeVelocity()
        {
            // velocity
            return (Velocity != defVelocity);
        }

        public enum VelocityDistributionType
        {
            [EnumMember(Value = "none")]
            None,
            [EnumMember(Value = "box")]
            Box,
            [EnumMember(Value = "sphere")]
            Sphere,
            [EnumMember(Value = "disc")]
            Disc,
        }
        private static VelocityDistributionType defVelocityDistribution = VelocityDistributionType.None;
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "velocityDistribution")]
        [Tooltip("distribution of particle velocities, for disc and sphere, only the x component will be used. if set to NONE use the 'distribution' attribute for velocityDistribution")]
        public VelocityDistributionType VelocityDistribution = defVelocityDistribution;
        public bool ShouldSerializeVelocityDistribution()
        {
            // velocityDistribution
            return (VelocityDistribution != defVelocityDistribution);
        }

        private static object defVelocitySpread = JsonConvert.DeserializeObject("{x: 0, y: 0, z: 0}");
        [JsonProperty(PropertyName = "velocitySpread")]
        [Tooltip("variance for the velocity")]
        public object VelocitySpread = defVelocitySpread;
        public bool ShouldSerializeVelocitySpread()
        {
            // velocitySpread
            return (VelocitySpread != defVelocitySpread);
        }

        private static float defWiggle = 0f;
        [JsonProperty(PropertyName = "wiggle")]
        [Tooltip("extra distance the particle moves over its lifetime")]
        public float Wiggle = defWiggle;
        public bool ShouldSerializeWiggle()
        {
            // wiggle
            return (Wiggle != defWiggle);
        }

        private static float defWiggleSpread = 0f;
        [JsonProperty(PropertyName = "wiggleSpread")]
        [Tooltip("+- spread for the wiggle attribute")]
        public float WiggleSpread = defWiggleSpread;
        public bool ShouldSerializeWiggleSpread()
        {
            // wiggleSpread
            return (WiggleSpread != defWiggleSpread);
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
