﻿using UnityEngine;

namespace Assets.Kanau.AFrameScene.Materials {
    public abstract class BaseAFrameShader {
        public abstract void FillProperty(KeyValueProperty p);

        protected void Add(KeyValueProperty p, string key, Color color) {
            p.Add(key, "#" + Three.UnityColorToHexColor(color));
        }
        protected void Add(KeyValueProperty p, string key, Vector2 vec) {
            var repeat = string.Format("{0} {1}", vec.x, vec.y);
            p.Add(key, repeat);
        }
        protected void AddTextureSrc(KeyValueProperty p, string key, string src) {
            var attr = string.Format("url({0})", src);
            p.Add(key, attr);
        }
    }

    /// <summary>
    /// https://aframe.io/docs/master/core/shaders.html#properties
    /// </summary>
    public class StandardAFrameShader : BaseAFrameShader {
        readonly Color DefaultColor = new Color(1, 1, 1);
        // TODO height
        const bool DefaultFog = true;
        const float DefaultMetalness = 0.5f;
        readonly Vector2 DefaultRepeat = new Vector2(1, 1);
        const float DefaultRoughness = 0.5f;
        // TODO width

        public Color Color { get; set; }
        public bool Fog { get; set; }
        public float Metalness { get; set; }
        public Vector2 Repeat { get; set; }
        public float Roughness { get; set; }
        public string Src { get; set; }

        public StandardAFrameShader() {
            this.Color = DefaultColor;
            this.Fog = DefaultFog;
            this.Metalness = DefaultMetalness;
            this.Repeat = DefaultRepeat;
            this.Roughness = DefaultRoughness;
        }

        public override void FillProperty(KeyValueProperty p) {
            p.Add("shader", "standard");

            if (Color != DefaultColor) { Add(p, "color", Color); }
            if (Fog != DefaultFog) { p.Add("fog", Fog); }
            if (Metalness != DefaultMetalness) { p.Add("metalness", Metalness); }
            if (Repeat != DefaultRepeat) { Add(p, "repeat", Repeat); }
            if (Roughness != DefaultRoughness) { p.Add("roughness", Roughness); }
            if (Src != "") { AddTextureSrc(p, "src", Src); }
        }
    }

    /// <summary>
    /// https://aframe.io/docs/master/core/shaders.html#properties-1
    /// </summary>
    public class FlatAFrameShader : BaseAFrameShader {
        readonly Color DefaultColor = new Color(1, 1, 1);
        const bool DefaultFog = true;
        // TODO height
        readonly Vector2 DefaultRepeat = new Vector2(1, 1);
        // TODO width

        public Color Color { get; set; }
        public bool Fog { get; set; }
        public Vector2 Repeat { get; set; }
        public string Src { get; set; }

        public FlatAFrameShader() {
            this.Color = DefaultColor;
            this.Fog = DefaultFog;
            this.Repeat = DefaultRepeat;
        }

        public override void FillProperty(KeyValueProperty p) {
            p.Add("shader", "flat");

            if (Color != DefaultColor) { Add(p, "color", Color); }
            if (Fog != DefaultFog) { p.Add("fog", Fog); }
            if (Repeat != DefaultRepeat) { Add(p, "repeat", Repeat); }
            if (Src != "") { AddTextureSrc(p, "src", Src); }
        }
    }
}
