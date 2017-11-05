using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingAsyn : MonoBehaviour
{
    //异步加载操作对象
    private AsyncOperation async;
    //进度表示
    private int progress = 0;
    //进度条控件
    public Slider progressSlider;

    public Text text;
    //下一个要加载的场景名称
    private string nextscenename;
	// Use this for initialization
	void Start ()
	{
  
        //获取下一个场景的名称
	    nextscenename = ConfigureClass.nextSceneName;
        //执行异步加载
	    StartCoroutine(loadscene());
	    progressSlider.value = 0;

	}
	
	// Update is called once per frame
	void Update ()
	{
	    progress = (int) (async.progress * 100);
	    if (async.isDone == true)
	    {
	        Destroy(this);
	    }
	}

    void OnGUI()
    {
        if (async != null&& async.isDone==false)
        {
            text.text = "已完成" + progress + "%";
            progressSlider.value = progress;
        }
    }

    IEnumerator loadscene()
    {
        async = SceneManager.LoadSceneAsync(nextscenename);
        yield return async;

    }
}
