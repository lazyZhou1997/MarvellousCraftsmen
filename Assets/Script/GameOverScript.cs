using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

	//显示游戏时间的控件
	public Text showGameTime;

	// Use this for initialization
	void Start () {
		//显示游戏时间
		if (ConfigureClass.finishTime > 0)
		{
			showGameTime.text = Convert.ToString(ConfigureClass.finishTime / 60) + "分" +
			                    Convert.ToString(ConfigureClass.finishTime % 60) + "秒";
		}
		else
		{
			Debug.Log("游戏时间出错！");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
