using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshakeTest : MonoBehaviour {

	public CameraShake cameraShake;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha0)){
			cameraShake.ShakeCamera(10,1);
		}
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			cameraShake.ShakeCamera(2,10);
		}
		if(Input.GetKeyDown(KeyCode.Alpha3)){
			cameraShake.ShakeCamera(5,5);
		}
	}
}
