// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,)' with 'UnityObjectToClipPos()'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,)' with 'UnityObjectToClipPos()'

Shader "Custom/UnlitText"
{
    Properties
    {
    _MainTex("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Pass {

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

#include "unitycg.cginc"


            struct VertInput {
                float4 pos : POSITION; 
                float2 uv : TEXCOORD0;
            };

sampler2D _MainTex;
float4 _MainTex_ST;

            struct VertOutput {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            VertOutput vert(VertInput i) {

                VertOutput o;

                o.pos = UnityObjectToClipPos(i.pos);
                o.uv = TRANSFORM_TEX(i.uv, _MainTex);

                return o;
            }

            half4 frag(VertOutput i) : COLOR{

               return tex2D(_MainTex, i.uv);
            }

            ENDCG
        }
    }
    FallBack "Diffuse"
}