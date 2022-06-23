#if defined(SHADERGRAPH_PREVIEW)
#else
#pragma multi_compile _ _MAIN_LIGHT_SHADOWS
#pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE
#endif

void ToonShading_float(in float3 Normal, in float ToonRampSmoothness, in float3 ClipSpacePos, in float3 WorldPos, in float4 ToonRampTinting, in float ToonRampOffset, out float3 ToonRampOutput, out float3 Direction)
{
	#if defined(SHADERGRAPH_PREVIEW)
		Direction = float3(0.5, 0.5, 0);
		ToonRampOutput = float3(0.5, 0.5, 0);
	#else
		#if SHADOWS_SCREEN
			float4 shadowCoord = ComputeScreenPos(ClipSpacePos);
		#else
			float4 shadowCoord = TransformWorldToShadowCoord(WorldPos);
		#endif 

		#if _MAIN_LIGHT_SHADOWS_CASCADE || _MAIN_LIGHT_SHADOWS
			Light light = GetMainLight(shadowCoord);
		#else
			Light light = GetMainLight();
		#endif

		float d = dot(Normal, light.direction) * 0.5 + 0.5;
		float toonRamp = smoothstep(ToonRampOffset, ToonRampOffset+ ToonRampSmoothness, d);

		toonRamp *= light.shadowAttenuation;
		ToonRampOutput = light.color * (toonRamp + ToonRampTinting);
		Direction = light.direction;
	#endif
}
