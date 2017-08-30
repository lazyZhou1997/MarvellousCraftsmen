using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

    //退出游戏时的操作
    public void OnApplicationQuit()
    {

    }

    //退出游戏
    public void QuitGameNow()
    {
        //退出游戏
        Application.Quit();

        Debug.Log("退出");
    }

    //每帧操作
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android&&Input.GetKey(KeyCode.Escape))
        {            
            //退出游戏
            Application.Quit();
        }
    }

}
