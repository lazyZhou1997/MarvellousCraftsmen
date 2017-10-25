using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitilizatinScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //自动对焦
        Vuforia.CameraDevice.Instance.SetFocusMode(Vuforia.CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
