using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AutoChangeScene : MonoBehaviour {

    //切换场景类
    public SplashLoad splashLoad;
    //下一个要加载的场景名称
    public string nextSceneToLoad;
    //画面停留的时间,单位:秒
    public int stayTime=3;

    private bool firstIn = true;

    private float beginTime;//开始计时
    // Use this for initialization
    void Start ()
    {
        beginTime = Time.time; //获得开始时间
    }
	
	// Update is called once per frame
	void. Update ()
	{
	    float deltTime = Time.time - beginTime;//从开始到现在经历的时间

        if (deltTime>=stayTime)
        {
            splashLoad.StartSplash(nextSceneToLoad, 2);
        }

    }

 
}
