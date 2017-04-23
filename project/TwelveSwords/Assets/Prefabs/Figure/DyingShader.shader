Shader "GUI/DyingShader"
{
	Properties
	{
		_FadeRate("Fade Rate", Range(1, 10)) = 10
		_MainTex("Main Texture", 2D) = "white" {}
		_Wide("Wide", Float) = 1.0
		_Hight("Hight", Float) = 1.0
	}
	SubShader
	{
		Tags { 
			"Queue"="Transparent" 
			"RenderType"="Transparent" 
			"IgnoreProjector"="True"
			"DisableBatching"="True"
		}

		Pass
		{
			Tags{
				"LightMode"="ForwardBase"
			}
			ZWrite off
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct a2v
			{
				float4 vertex : POSITION;
				float4 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 pos : SV_POSITION;
				fixed alpha : TEXCOORD1;
				float2 uv : TEXCOORD2;
			};

			float _FadeRate;
			float _Wide;
			float _Hight;
			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (a2v v)
			{
				v2f o;

				o.alpha = (sin(_FadeRate * _Time.y) + 1.0) * 0.45 + 0.1;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;

				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 c = tex2D(_MainTex, i.uv).rgba;
				c.w *= i.alpha;
				return c;
			}
			ENDCG
		}
	}
}
