using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


namespace DitzelGames.PostProcessingTextureOverlay
{
    [Serializable]
    [PostProcess(typeof(TextureOverlayRenderer), PostProcessEvent.AfterStack, "DitzelGames/TextureOverlay", false)]
    public sealed class TextureOverlay : PostProcessEffectSettings
    {
        [Header("Texture")]
        [Tooltip("Texture Overlay")]
        public TextureParameter texture = new TextureParameter { value = null };
        [Tooltip("Tiling")]
        public Vector2Parameter tiling = new Vector2Parameter { value = new Vector2(1, 1) };
        [Tooltip("Offset")]
        public Vector2Parameter offset = new Vector2Parameter { value = new Vector2(0, 0) };
        [Tooltip("Keep Aspect Ratio")]
        public BoolParameter keepAspectRatio = new BoolParameter { value = false };

        [Header("Alpha Cutout")]
        [Tooltip("Active")]
        public BoolParameter alphaIsTransparent = new BoolParameter { value = true };
        /*
        [Header("Color Cutout")]
        [Tooltip("Active")]
        public BoolParameter colorCutout = new BoolParameter { value = false };
        [Tooltip("Color")]
        public ColorParameter colorCutoutColor = new ColorParameter { value = Color.magenta };
        [Range(0f, 10f), Tooltip("Threshold")]
        public FloatParameter colorCutoutThreshold = new FloatParameter { value = 0.01f };
        */

    }

    public sealed class TextureOverlayRenderer : PostProcessEffectRenderer<TextureOverlay>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/DitzelGames/TextureOverlay"));

            var imageTexture = settings.texture.value == null
                    ? RuntimeUtilities.transparentTexture
                    : settings.texture.value;

            sheet.properties.SetTexture("_Image", imageTexture);
            sheet.properties.SetVector("_Tiling", settings.tiling);
            sheet.properties.SetVector("_Offset", settings.offset);
            sheet.properties.SetInt("_KeepAspectRatio", BoolToInt(settings.keepAspectRatio));
            sheet.properties.SetInt("_AlphaIsTransparent", BoolToInt(settings.alphaIsTransparent));
            /*
            sheet.properties.SetInt("_ColorCutout", BoolToInt(settings.colorCutout));
            sheet.properties.SetVector("_ColorCutoutTColor", settings.colorCutoutColor);
            sheet.properties.SetFloat("_ColorCutoutThreshold", settings.colorCutoutThreshold);
            */
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }

        private int BoolToInt(bool b)
        {
            return b ? 1 : 0;
        }
    }

}