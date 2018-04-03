using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonar : MonoBehaviour {

	private ValueControl v;

	public Material SonarMat; 
	public Transform _origin;
	public Camera _cam;

	private bool _sonar;
	private float _speed = 5;

	public float _frequency;
	private float _interval;
	private float _width;
	private float _distance;

	public int _pulselength;
	private float[] pulse;
	private bool[] activepulse;
	private Vector4[] origin;
	private float[] travel;
	private float[] width;

	//public bool multiply = false;
	//private int m;

	void Start() {
		v = GetComponent<ValueControl> ();
		activepulse = new bool[_pulselength];
		pulse = new float[_pulselength];
		origin = new Vector4[_pulselength];
		travel = new float[_pulselength];
		width = new float[_pulselength];
		_cam.depthTextureMode = DepthTextureMode.Depth;
	}

	void Update () {
		PassiveSonar ();
		PulseActivate ();
		FrequencyControl ();
		PulseControl ();

/*if (multiply)
			m = 1;
		else
			m = 0;
            */
	}

	void FrequencyControl() {
		float shift = (_frequency - v.f_min) / (v.f_max - v.f_min);

		_interval = Mathf.Lerp (v.i_min, v.i_max, shift);
		_width = Mathf.Lerp (v.w_min, v.w_max, shift);
		_distance = Mathf.Lerp (v.d_min, v.d_max, shift);
	}

	void PulseActivate() {
		if (_sonar) {
			for (int i = 0; i < _pulselength; i++) {
				if (!activepulse [i]) {
					activepulse [i] = true;
					origin [i] = _origin.position;
					width [i] = _width;
					travel [i] = _distance;
					return;
				}
			}
		}
	}

	void PulseControl() {
		for (int i = 0; i < _pulselength; i++) {
			if (activepulse [i]) {
				pulse [i] += Time.deltaTime * v.speed;
				if (pulse [i] > travel[i]) {
					activepulse [i] = false;
					pulse [i] = 0;
				}
			}
		}
	}

	void ActiveSonar() {
		_sonar = Input.GetKeyDown (KeyCode.Space);
	}

	float time;
	void PassiveSonar () {
		time += Time.deltaTime;
		if (time > _interval) {
			_sonar = true;
			time = 0;
		} else {
			_sonar = false;
		}
	}


	[ImageEffectOpaque]
	void OnRenderImage (RenderTexture src, RenderTexture dst){
		SonarMat.SetInt ("_pulselength", _pulselength);
		SonarMat.SetFloatArray ("_pulses", pulse);
		SonarMat.SetVectorArray ("originarray", origin);
		SonarMat.SetFloatArray ("widtharray", width);
	//	SonarMat.SetInt ("m", m);
		RaycastCornerBlit (src, dst, SonarMat);
	}

	void RaycastCornerBlit(RenderTexture source, RenderTexture dest, Material mat)
	{
		// Compute Frustum Corners
		float camFar = _cam.farClipPlane;
		float camFov = _cam.fieldOfView;
		float camAspect = _cam.aspect;

		float fovWHalf = camFov * 0.5f;

		Vector3 toRight = _cam.transform.right * Mathf.Tan(fovWHalf * Mathf.Deg2Rad) * camAspect;
		Vector3 toTop = _cam.transform.up * Mathf.Tan(fovWHalf * Mathf.Deg2Rad);

		Vector3 topLeft = (_cam.transform.forward - toRight + toTop);
		float camScale = topLeft.magnitude * camFar;

		topLeft.Normalize();
		topLeft *= camScale;

		Vector3 topRight = (_cam.transform.forward + toRight + toTop);
		topRight.Normalize();
		topRight *= camScale;

		Vector3 bottomRight = (_cam.transform.forward + toRight - toTop);
		bottomRight.Normalize();
		bottomRight *= camScale;

		Vector3 bottomLeft = (_cam.transform.forward - toRight - toTop);
		bottomLeft.Normalize();
		bottomLeft *= camScale;

		// Custom Blit, encoding Frustum Corners as additional Texture Coordinates
		RenderTexture.active = dest;

		mat.SetTexture("_MainTex", source);

		GL.PushMatrix();
		GL.LoadOrtho();

		mat.SetPass(0);

		GL.Begin(GL.QUADS);

		GL.MultiTexCoord2(0, 0.0f, 0.0f);
		GL.MultiTexCoord(1, bottomLeft);
		GL.Vertex3(0.0f, 0.0f, 0.0f);

		GL.MultiTexCoord2(0, 1.0f, 0.0f);
		GL.MultiTexCoord(1, bottomRight);
		GL.Vertex3(1.0f, 0.0f, 0.0f);

		GL.MultiTexCoord2(0, 1.0f, 1.0f);
		GL.MultiTexCoord(1, topRight);
		GL.Vertex3(1.0f, 1.0f, 0.0f);

		GL.MultiTexCoord2(0, 0.0f, 1.0f);
		GL.MultiTexCoord(1, topLeft);
		GL.Vertex3(0.0f, 1.0f, 0.0f);

		GL.End();
		GL.PopMatrix();
	}

}