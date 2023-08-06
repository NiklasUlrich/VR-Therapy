Shader "Custom/EdgeDarkening" {
    Properties{
        _MainTex("Texture", 2D) = "white" {}
        _EdgeDarkness("Edge Darkness", Range(0, 1)) = 0.2
    }

        SubShader{
            Tags {"Queue" = "Transparent" "RenderType" = "Transparent"}
            LOD 200

            CGPROGRAM
            #pragma surface surf Lambert

            sampler2D _MainTex;
            float _EdgeDarkness;

            struct Input {
                float2 uv_MainTex;
            };

            void surf(Input IN, inout SurfaceOutput o) {
                // Calculate the screen space UV coordinates
                float2 screenUV = IN.uv_MainTex * _ScreenParams.xy + _ScreenParams.zw;

                // Sample the texture at screen space UV
                fixed4 color = tex2D(_MainTex, screenUV);

                // Darken the color based on distance to edges
                fixed edgeDarkening = 1.0 - smoothstep(0.0, _EdgeDarkness, color.a);
                color.rgb *= edgeDarkening;

                o.Albedo = color.rgb;
                o.Alpha = color.a;
            }
            ENDCG
        }
            FallBack "Diffuse"
}
