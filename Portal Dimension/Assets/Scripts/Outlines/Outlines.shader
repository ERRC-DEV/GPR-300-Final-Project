Shader "Hidden/Outlines"
{
    //Shader written by Atle Tolley, with some structural guidance taken from the Post-Processing-Acerola Unity Project's Edge Detection shader

    Properties{
        _MainTex("Texture", 2D) = "white" {}
    }

    SubShader{

        Pass {
            CGPROGRAM
            #pragma vertex vp
            #pragma fragment fp

            #include "UnityCG.cginc"

            struct VertexData {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vp(VertexData v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex, _CameraDepthTexture;
            float4 _CameraDepthTexture_TexelSize;
            float4 _OutlineColor;
            float _OutlineDist;

            fixed4 fp(v2f i) : SV_Target {
                int x, y;
                fixed4 col = tex2D(_MainTex, i.uv);
                float depth = tex2D(_CameraDepthTexture, i.uv);
                depth = Linear01Depth(depth);

                float n = Linear01Depth(tex2D(_CameraDepthTexture, i.uv + _CameraDepthTexture_TexelSize * float2(0, _OutlineDist)).r);
                float dN = Linear01Depth(tex2D(_CameraDepthTexture, i.uv + _CameraDepthTexture_TexelSize * float2(0, 2 * _OutlineDist)).r);
                float ne = Linear01Depth(tex2D(_CameraDepthTexture, i.uv + _CameraDepthTexture_TexelSize * float2(_OutlineDist, _OutlineDist)).r);
                float dNE = Linear01Depth(tex2D(_CameraDepthTexture, i.uv + _CameraDepthTexture_TexelSize * float2(2 * _OutlineDist, 2 * _OutlineDist)).r);
                float e = Linear01Depth(tex2D(_CameraDepthTexture, i.uv + _CameraDepthTexture_TexelSize * float2(_OutlineDist, 0)).r);
                float dE = Linear01Depth(tex2D(_CameraDepthTexture, i.uv + _CameraDepthTexture_TexelSize * float2(2 * _OutlineDist, 0)).r);
                float es = Linear01Depth(tex2D(_CameraDepthTexture, i.uv + _CameraDepthTexture_TexelSize * float2(_OutlineDist, -_OutlineDist)).r);
                float dES = Linear01Depth(tex2D(_CameraDepthTexture, i.uv + _CameraDepthTexture_TexelSize * float2(2 * _OutlineDist, -2 * _OutlineDist)).r);
                float s = Linear01Depth(tex2D(_CameraDepthTexture, i.uv + _CameraDepthTexture_TexelSize * float2(0, -_OutlineDist)).r);
                float dS = Linear01Depth(tex2D(_CameraDepthTexture, i.uv + _CameraDepthTexture_TexelSize * float2(0, -2 * _OutlineDist)).r);
                float sw = Linear01Depth(tex2D(_CameraDepthTexture, i.uv + _CameraDepthTexture_TexelSize * float2(-_OutlineDist, -_OutlineDist)).r);
                float dSW = Linear01Depth(tex2D(_CameraDepthTexture, i.uv + _CameraDepthTexture_TexelSize * float2(-2 * _OutlineDist, -2 * _OutlineDist)).r);
                float w = Linear01Depth(tex2D(_CameraDepthTexture, i.uv + _CameraDepthTexture_TexelSize * float2(-_OutlineDist, 0)).r);
                float dW = Linear01Depth(tex2D(_CameraDepthTexture, i.uv + _CameraDepthTexture_TexelSize * float2(-2 * _OutlineDist, 0)).r);
                float wn = Linear01Depth(tex2D(_CameraDepthTexture, i.uv + _CameraDepthTexture_TexelSize * float2(-_OutlineDist, _OutlineDist)).r);
                float dWN = Linear01Depth(tex2D(_CameraDepthTexture, i.uv + _CameraDepthTexture_TexelSize * float2(-2 * _OutlineDist, 2 * _OutlineDist)).r);

                bool dirs = false;
                if (depth - n > 0.005 && (depth - n) > (n - dN)) {
                    dirs = true;
                }
                if (depth - ne > 0.005 && (depth - ne) > (ne - dNE)) {
                    dirs = true;
                }
                if (depth - e > 0.005 && (depth - e) > (e - dE)) {
                    dirs = true;
                }
                if (depth - es > 0.005 && (depth - es) > (es - dES)) {
                    dirs = true;
                }
                if (depth - s > 0.005 && (depth - s) > (s - dS)) {
                    dirs = true;
                }
                if (depth - sw > 0.005 && (depth - sw) > (sw - dSW)) {
                    dirs = true;
                }
                if (depth - w > 0.005 && (depth - w) > (w - dW)) {
                    dirs = true;
                }
                if (depth - wn > 0.005 && (depth - wn) > (wn - dWN)) {
                    dirs = true;
                }

                if (dirs) col = _OutlineColor;

                return col;
                //return fixed4(depth, depth, depth, 1.0); //Helps me by showing the depth map
            }
            ENDCG
        }
    }
}
