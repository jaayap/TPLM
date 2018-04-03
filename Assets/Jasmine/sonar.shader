Shader "custom/sonar"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Cull Off ZWrite Off ZTest Always

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
				float4 ray : TEXCOORD1;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float2 uvdepth : TEXCOORD1;
				float4 interpolatedRay : TEXCOORD2;
			};

			sampler2D _MainTex;
			sampler2D _CameraDepthTexture;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv.xy;
				o.uvdepth = v.uv.xy;
				o.interpolatedRay = v.ray;
				return o;
			}

			int _pulselength;
			float _pulses[20];
			float4 originarray[20];
			float widtharray[20];
			int m;


			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);

				float rawDepth = DecodeFloatRG(tex2D(_CameraDepthTexture, i.uvdepth));
				float linearDepth = Linear01Depth(rawDepth);
				float4 dir = linearDepth * i.interpolatedRay;
				float3 pos = _WorldSpaceCameraPos + dir;
				fixed4 pulsecol = fixed4(0,0,0,0);

				for(int i = 0; i < _pulselength; i++) {
					float dist = distance(pos, originarray[i]);
					if (dist < _pulses[i] && dist > _pulses[i] - widtharray[i]) {
						float diff = 1 - (_pulses[i] - dist) / (widtharray[i]);
					//	pulsecol = lerp(fixed4(1,0,0,1), fixed4(1,1,1,1), diff* .5);//pink
					//	pulsecol *= diff;
						pulsecol = lerp(fixed4(0,0,0,0), fixed4(1,1,1,1), diff* .5); //white
						pulsecol *= diff;
					}
				}

				/*if(m==0)
					return col + pulsecol;
				else
					return col * pulsecol; 
					*/

				return pulsecol;
			}
			ENDCG
		}
	}
}