using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class LoadIntroductionOfCurrentScene : MonoBehaviour
{

	public Text introductionText;//用于表示要呈现内容的Text

	public string currentSceneName;//当前场景的名称

	private StringBuilder currentShowedContent = new StringBuilder();//当前显示的内容
	
	private string allContent; //要呈现的所有内容

	private float previousTime;//初始时间 
	
	private const float SHOWTIME = 0.1f;//显示时间间隔

	private int position = 0;//当前显示到第position个文字
	
	// Use this for initialization
	void Start () {
		
		//获取要呈现的内容
		allContent = ConfigureClass.descriptions[currentSceneName];
		//获取初始时间
		previousTime = Time.time;
		//显示内容
		introductionText.text = currentShowedContent.ToString();

	}
	
	// Update is called once per frame
	void Update () {

		if (position<allContent.Length)//如果内容还没有显示完
		{
			#region 显示要呈现的内容，每隔SHOWTIME秒显示一个字符

			//获取当前时间
			float currentTime = Time.time;

			if ((currentTime - previousTime) > SHOWTIME) //如果时间间隔大于0.5秒，则显示一个文字
			{
				currentShowedContent.Append(allContent[position]);//将字符添加到显示内容后面
				introductionText.text = currentShowedContent.ToString();//显示修改后的内容
				position++;//要显示的字符串位置增加
				previousTime = currentTime;//修改时间
			}

			#endregion

		}

	}

}
