using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour {

    //加载下一个场景
    public void LoadScene(string sceneName){
        //加载下一个场景
        SceneManager.LoadScene(sceneName);
    }
}
