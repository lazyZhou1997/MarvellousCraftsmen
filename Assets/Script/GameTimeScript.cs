using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimeScript : MonoBehaviour
{
    public Text ShowTime; //用于显示当前时间

    #region 私有变量

    private float beginTime; //开始游戏时的时间

    #endregion

    // Use this for initialization
    void Start()
    {
        //获得开始游戏的时间
        beginTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        #region 每隔1秒统计游戏时间

        //获得当前游戏进行时间
        float currentTime = Time.time - beginTime;

        //当间隔超过1秒，则记录新的游戏时间
        if ((currentTime - ConfigureClass.finishTime) >= 1)
        {
            //赋值当前时间
            ConfigureClass.finishTime = currentTime;
            //显示当前用时
            ShowTime.text = Convert.ToString((int) (ConfigureClass.finishTime + ConfigureClass.lastFinishTime) / 60) +
                            ":" +
                            Convert.ToString((int) (ConfigureClass.finishTime + ConfigureClass.lastFinishTime) % 60);
        }

        #endregion
    }
}