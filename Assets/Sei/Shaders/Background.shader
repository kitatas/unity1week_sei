Shader "Custom/Background"
{
    Properties
    {
        _SquareNum ("SquareNum", int) = 10

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float2 random2(float2 st)
            {
                st = float2(dot(st, float2(127.1, 311.7)),
                            dot(st, float2(269.5, 183.3)));
                return -1.0 + 2.0 * frac(sin(st) * 43758.5453123);
            }

            int _SquareNum;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 st = i.uv;
                st *= _SquareNum;

                float2 ist = floor(st); // 整数
                float2 fst = frac(st);  // 少数の右側

                float distance = 5;
                float2 p_min;

                for (int y = -1; y <= 1; y++)
                for (int x = -1; x <= 1; x++)
                {
                    float2 neighbor = float2(x, y);
                    float2 p = 0.5 + 0.5 * sin(_Time.y + 6.2831 * random2(ist + neighbor));

                    float2 diff = neighbor + p - fst;

                    if (distance > length(diff))
                    {
                        distance = length(diff);
                        // 最も近い白点も更新
                        p_min = p;
                    }
                }

                // 最も近い白点の座標を基に色を出力
                // 色を変化させるための式
                p_min.x += sin(_Time.y);
                p_min.y += cos(_Time.y);

                return fixed4(p_min.y * 0.25 + 0.5, p_min.y * 0.25 + 0.5, p_min.y * 0.25 + 0.5, 1);
            }
            ENDCG
        }
    }
}