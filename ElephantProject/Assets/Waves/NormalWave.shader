Shader "Custom/NormalWave" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)

		_SpecularColor ("Specular Color", Color) = (1,1,1,1)
      	_SpecPower ("Specular Power", Range(0,1000)) = 1
      	_Blend("_Blend", Range(0,1) ) = 0.5

		[Space(10)]
		_Normal("Normal Map", 2D) = "bump"{}
		_ScrollSpeedX("Scroll Speed X", Range(-1,1)) = 0
		_ScrollSpeedY("Scroll Speed Y", Range(-1,1)) = 0

		[Space(10)]
		_Normal2("Normal Map", 2D) = "bump"{}
		_ScrollSpeedX2("Scroll Speed X", Range(-1,1)) = 0
		_ScrollSpeedY2("Scroll Speed Y", Range(-1,1)) = 0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Phong
		#pragma target 3.0

		float _SpecPower;
		float4 _SpecularColor;

		fixed4 LightingPhong(SurfaceOutput s, fixed3 lightDir, half3 viewDir, fixed atten)
		{
			//Reflection
			float NdotL = dot(s.Normal, lightDir);
			float3 reflectionVector = normalize(2.0 * s.Normal * NdotL - lightDir);

			//Specular
			float spec = pow(max(0, dot(reflectionVector, viewDir)), _SpecPower);
			float3 finalSpec = _SpecularColor.rgb * spec;

			fixed4 c;
			c.rgb = (s.Albedo * _LightColor0.rgb * max(0,NdotL) * atten) + (_LightColor0.rgb * finalSpec);
			c.a = s.Alpha;
			return c;
		}

		sampler2D _MainTex;
		sampler2D _Normal;
		sampler2D _Normal2;

		float _ScrollSpeedX;
		float _ScrollSpeedY;
		float _ScrollSpeedX2;
		float _ScrollSpeedY2;
		float _Blend;
		float4 _Color;

		struct Input {
			float2 uv_MainTex;
			float2 uv_Normal;
			float2 uv_Normal2;
		};


		void surf (Input IN, inout SurfaceOutput o) {
			

			float2 scroll = IN.uv_Normal;
			float xScroll = _ScrollSpeedX * _Time;
			float yScroll = _ScrollSpeedY * _Time;
			scroll += float2(xScroll, yScroll);

			float2 scroll2 = IN.uv_Normal2;
			float xScroll2 = _ScrollSpeedX2 * _Time;
			float yScroll2 = _ScrollSpeedY2 * _Time;
			scroll2 += float2(xScroll2, yScroll2);

			fixed4 c = tex2D(_MainTex, scroll) * _Color;

			fixed3 normalMap = UnpackNormal(tex2D(_Normal, scroll));
			fixed3 normalMap2 = UnpackNormal(tex2D(_Normal2, scroll2));
			fixed3 lerpTex = lerp(normalMap, normalMap2, _Blend);

					

			o.Normal = normalize(lerpTex);
			

			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
