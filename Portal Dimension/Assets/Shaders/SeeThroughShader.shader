Shader "Unlit/SeeThroughShader"
{
	// Shader written imported from https://discussions.unity.com/t/invisible-depth-mask/467806/2

		SubShader
	{
		Tags{ "Queue" = "Geometry-1"}
		Lighting Off
		Pass
		{
			ZWrite On
			ZTest LEqual
			ColorMask 0
		}
	}
}
