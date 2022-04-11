// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,)' with 'UnityObjectToClipPos()'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,)' with 'UnityObjectToClipPos()'

Shader "Custom/NewSurfaceShader"
{
    Properties
    {

    }
    SubShader
    {
        Pass {

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            struct VertInput {
                float4 pos : POSITION; 
            };

            struct VertOutput {
                float4 pos : SV_POSITION;
                float3 wpos : POSITION1;
            };

            VertOutput vert(VertInput i) {

                VertOutput o;

                o.pos = UnityObjectToClipPos(i.pos);
                o.wpos = mul(unity_ObjectToWorld, i.pos).xyz;

                return o;
            }

            half4 frag(VertOutput i) : COLOR{

                return half4(abs((i.wpos - floor(i.wpos)) - 0.5) * 2, 1.0f);
            }

            ENDCG
        }
    }
    FallBack "Diffuse"
}