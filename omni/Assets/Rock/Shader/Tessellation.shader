// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Tessellation"
{
	Properties
	{
		_TessValue( "Max Tessellation", Range( 1, 32 ) ) = 15
		_TessMin( "Tess Min Distance", Float ) = 10
		_TessMax( "Tess Max Distance", Float ) = 25
		_TessPhongStrength( "Phong Tess Strength", Range( 0, 1 ) ) = 0.5
		_basecolor("basecolor", 2D) = "white" {}
		_metallic("metallic", 2D) = "white" {}
		_roughness("roughness", 2D) = "white" {}
		_roughnes_vole("roughnes_vole", Range( -1 , 1)) = 0.430571
		[Normal]_normal("normal", 2D) = "white" {}
		_height("height", 2D) = "white" {}
		_height_vole("height_vole", Range( -3 , 5)) = 0.3
		_ambientOcclusion("ambientOcclusion", 2D) = "white" {}
		_ambient_occlusion_vole("ambient_occlusion_vole", Range( -1 , 2)) = 1
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IgnoreProjector" = "True" }
		Cull Back
		CGPROGRAM
		#include "Tessellation.cginc"
		#pragma target 4.6
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows vertex:vertexDataFunc tessellate:tessFunction tessphong:_TessPhongStrength 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _height;
		uniform float4 _height_ST;
		uniform float _height_vole;
		uniform sampler2D _normal;
		uniform float4 _normal_ST;
		uniform sampler2D _basecolor;
		uniform float4 _basecolor_ST;
		uniform sampler2D _metallic;
		uniform float4 _metallic_ST;
		uniform sampler2D _roughness;
		uniform float4 _roughness_ST;
		uniform float _roughnes_vole;
		uniform sampler2D _ambientOcclusion;
		uniform float4 _ambientOcclusion_ST;
		uniform float _ambient_occlusion_vole;
		uniform float _TessValue;
		uniform float _TessMin;
		uniform float _TessMax;
		uniform float _TessPhongStrength;

		float4 tessFunction( appdata_full v0, appdata_full v1, appdata_full v2 )
		{
			return UnityDistanceBasedTess( v0.vertex, v1.vertex, v2.vertex, _TessMin, _TessMax, _TessValue );
		}

		void vertexDataFunc( inout appdata_full v )
		{
			float3 ase_vertexNormal = v.normal.xyz;
			float2 uv_height = v.texcoord * _height_ST.xy + _height_ST.zw;
			v.vertex.xyz += ( float4( ase_vertexNormal , 0.0 ) * ( tex2Dlod( _height, float4( uv_height, 0, 0.0) ) * _height_vole ) ).rgb;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_normal = i.uv_texcoord * _normal_ST.xy + _normal_ST.zw;
			o.Normal = UnpackNormal( tex2D( _normal, uv_normal ) );
			float2 uv_basecolor = i.uv_texcoord * _basecolor_ST.xy + _basecolor_ST.zw;
			o.Albedo = tex2D( _basecolor, uv_basecolor ).rgb;
			float2 uv_metallic = i.uv_texcoord * _metallic_ST.xy + _metallic_ST.zw;
			o.Metallic = tex2D( _metallic, uv_metallic ).r;
			float2 uv_roughness = i.uv_texcoord * _roughness_ST.xy + _roughness_ST.zw;
			o.Smoothness = ( ( 1.0 - tex2D( _roughness, uv_roughness ) ) * _roughnes_vole ).r;
			float2 uv_ambientOcclusion = i.uv_texcoord * _ambientOcclusion_ST.xy + _ambientOcclusion_ST.zw;
			o.Occlusion = ( tex2D( _ambientOcclusion, uv_ambientOcclusion ) * _ambient_occlusion_vole ).r;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=15301
1003;92;917;936;1469.466;1249.611;2.314754;True;False
Node;AmplifyShaderEditor.SamplerNode;3;-274.0999,408.9001;Float;True;Property;_height;height;10;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;4;-235.1155,653.1187;Float;False;Property;_height_vole;height_vole;11;0;Create;True;0;0;False;0;0.3;0;-3;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;11;-651.8757,-58.00757;Float;True;Property;_roughness;roughness;7;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;16;-673.5619,543.0564;Float;False;Property;_ambient_occlusion_vole;ambient_occlusion_vole;13;0;Create;True;0;0;False;0;1;0;-1;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;9;-708.3617,280.1799;Float;True;Property;_ambientOcclusion;ambientOcclusion;12;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.NormalVertexDataNode;7;69.08449,346.3189;Float;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;13;-681.7756,187.6924;Float;False;Property;_roughnes_vole;roughnes_vole;8;0;Create;True;0;0;False;0;0.430571;0;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;18;-282.7094,-227.5768;Float;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;5;82.08447,510.1189;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;-69.75368,-33.11051;Float;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;17;-247.271,174.1738;Float;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;8;-593.8594,-549.7036;Float;True;Property;_metallic;metallic;6;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;1;-201.5585,-978.5596;Float;True;Property;_basecolor;basecolor;5;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;6;280.9845,468.5189;Float;False;2;2;0;FLOAT3;0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;21;-215.2591,-649.0182;Float;True;Property;_normal;normal;9;1;[Normal];Create;True;0;0;False;0;None;None;True;0;False;white;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;481.4331,-268.9249;Float;False;True;6;Float;ASEMaterialInspector;0;0;Standard;Tessellation;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;0;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;True;0;15;10;25;True;0.5;True;0;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;-1;False;-1;-1;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Spherical;True;Relative;0;;-1;-1;-1;0;0;0;0;False;0;0;0;False;-1;0;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;18;0;11;0
WireConnection;5;0;3;0
WireConnection;5;1;4;0
WireConnection;12;0;18;0
WireConnection;12;1;13;0
WireConnection;17;0;9;0
WireConnection;17;1;16;0
WireConnection;6;0;7;0
WireConnection;6;1;5;0
WireConnection;0;0;1;0
WireConnection;0;1;21;0
WireConnection;0;3;8;0
WireConnection;0;4;12;0
WireConnection;0;5;17;0
WireConnection;0;11;6;0
ASEEND*/
//CHKSM=785B21C803BE51C99572DDBCE9B0495956862CD4