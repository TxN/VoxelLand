Shader "Hidden/DitzelGames/TextureOverlay"
{
	HLSLINCLUDE

#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

	TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
	sampler2D _Image;
	uniform float4 _Image_TexelSize;
	float2  _Tiling;
	float2  _Offset;
	int _KeepAspectRatio;
	int _AlphaIsTransparent;
	/*
	int _ColorCutout;
	float4 _ColorCutoutColor;
	float _ColorCutoutThreshold;*/

	float4 Frag(VaryingsDefault i) : SV_Target
	{
		float4 colorMain = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);


		if (_KeepAspectRatio == 1) {
			_Tiling.y = _Tiling.x / _Image_TexelSize.x * _Image_TexelSize.y / _ScreenParams.x * _ScreenParams.y;
		}

		//check for bounds
		float2 coord = i.texcoord * _Tiling + _Offset;
		if (coord.x <= 0 || coord.y <= 0 || coord.x >= 1 || coord.y >= 1)
			return colorMain;

		//get the color
		float4 colorOverlay = tex2D(_Image, coord);

		//lerp with settings
		if (_AlphaIsTransparent == 0) {
			//alpha
			colorOverlay.a = 1;
		}

		/*
		if(_ColorCutout == 1)
		{
			//color cut out
			if ((colorOverlay.r - _ColorCutoutColor.r) * (colorOverlay.r - _ColorCutoutColor.r) +
				(colorOverlay.g - _ColorCutoutColor.g) * (colorOverlay.g - _ColorCutoutColor.g) +
				(colorOverlay.b - _ColorCutoutColor.b) * (colorOverlay.b - _ColorCutoutColor.b) > _ColorCutoutThreshold * _ColorCutoutThreshold)
				colorOverlay.a = 0;
		}*/

		colorMain.rgb = lerp(colorMain.rgb, colorOverlay.rgb, colorOverlay.a);
		return colorMain;
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