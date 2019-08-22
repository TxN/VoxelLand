using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace DitzelGames.PostProcessingTextureOverlay
{
[Serializable]
[PostProcess(typeof(HardLightRenderer), PostProcessEvent.AfterStack, "DitzelGames/HardLight")]
public sealed class HardLight : PostProcessEffectSettings
{
    [Range(0f, 1f), Tooltip("Blend Amount")]
        public FloatParameter blend = new FloatParameter { value = 0.5f };
        public FloatParameter preMultiply = new FloatParameter { value = 1f };
    }

public sealed class HardLightRenderer : PostProcessEffectRenderer<HardLight>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/DitzelGames/HardLight"));
            sheet.properties.SetFloat("_Blend", settings.blend);
            sheet.properties.SetFloat("_PreMultiply", settings.preMultiply);
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}
}