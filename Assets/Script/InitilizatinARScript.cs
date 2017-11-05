using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitilizatinARScript : MonoBehaviour
{


	// Use this for initialization
	void Start () {
        //自动对焦
        if (!Vuforia.CameraDevice.Instance.SetFocusMode(Vuforia.CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO))
        {
            Debug.Log("相机自动对焦不可用");
        }
    }
	
	// Update is called once per frame
	void Update () {

        
    }
}
