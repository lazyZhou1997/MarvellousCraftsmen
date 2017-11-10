using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{

    public SplashLoad SplashLoad;//加载场景类

    //显示游戏时间的控件
    public Text showGameTime;

    //游戏评级显示控件
    public GameObject[] Images = new GameObject[3];

    /// <summary>
    /// 显示游戏结果
    /// </summary>
    public void ShowGameResult()
    {
        //获取游戏用时
        float gameTime = ConfigureClass.finishTime;

        //显示游戏用时
        if (gameTime > 0)
        {
            showGameTime.text = Convert.ToString((int) gameTime / 60) + ":" +
                                Convert.ToString((int) gameTime % 60);
        }
        else
        {
            Debug.Log("游戏时间出错！");
        }

        //显示游戏评分
        if (gameTime <= 150) //3星评级
        {
            #region 显示三星评级

            for (int i = 0; i < Images.Length; i++)
            {
                Images[i].SetActive(true);
            }

            #endregion
        }
        else if (gameTime > 150 && gameTime <= 300)//2星评级
        {
            #region 显示两星评级

            for (int i = 0; i < Images.Length - 1; i++)
            {
                Images[i].SetActive(true);
            }

            #endregion
        }
        else if (gameTime > 300 && gameTime <= 600)//1星评级
        {
            #region 显示一星评级

            for (int i = 0; i < Images.Length - 2; i++)
            {
                Images[i].SetActive(true);
            }

            #endregion
        }
        //无星评级
    }

    /// <summary>
    /// 再次玩这个游戏
    /// </summary>
    /// <param name="sceneName">重玩游戏</param>
    public void PlayAgain(string sceneName)
    {
        //玩游戏
        SplashLoad.StartSplashDefault(sceneName);
    }

    /// <summary>
    /// 再次玩下一关的游戏
    /// </summary>
    /// <param name="sceneName">下一个游戏</param>
    public void PlayNextGame(string sceneName)
    {
        //将游戏计时清空为0
        ConfigureClass.finishTime = 0;
        //玩下一个游戏
        SplashLoad.StartSplashGameScene(sceneName);
    }

    /// <summary>
    /// 返回主菜单
    /// </summary>
    public void ReturnToMainMenu()
    {
        //返回主菜单
        SplashLoad.StartSplashDefault("begin_ugui");
    }
}