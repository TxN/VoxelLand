Shader "Hidden/DitzelGames/HardLight"
{
	HLSLINCLUDE

#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

	TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
	float _Blend;
	float _PreMultiply;

	float4 Frag(VaryingsDefault i) : SV_Target
	{
		float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);

		float4 colorEffect = color * _PreMultiply;

		float greyValue = 0.299 * color.r + 0.587 * color.g + 0.114 * color.b;
		if (greyValue < 0.5)
			colorEffect = 2 * color * colorEffect;
		else
			colorEffect = 1 - 2 * (1 - color) * (1 - colorEffect);

		color.rgb = lerp(color.rgb, colorEffect.rgb, _Blend.xxx);

		return color;
	}

		ENDHLSL

		SubShader
	{
		Cull Off ZWrite Off ZTest Always

			Pass
		{
			HLSLPROGRAM

				#pragma vertex VertDefault
				#pragma fragment Frag

			ENDHLSL
		}
	}
}