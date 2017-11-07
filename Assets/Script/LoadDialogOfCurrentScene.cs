using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class LoadDialogOfCurrentScene : MonoBehaviour
{
	//切换场景类
	public SplashLoad splashLoad;
	//下一个要加载的场景名称
	public string nextSceneToLoad;

	public Text introductionText;//用于表示要呈现内容的Text
	
	private string[] allContent; //要呈现的所有内容
	

	private int position = 0;//当前显示到第position个对话
	
	// Use this for initialization
	void Start () {
		
		//获取要呈现的内容
		allContent = ConfigureClass.dialogs[ConfigureClass.nextSceneName];	
		//显示第一个对话	
		introductionText.text = allContent[position];
		//对话位置加一
		position++;

	}

	/// <summary>
	/// 继续当前对话
	/// </summary>
	public void ContinueDialog()
	{
		if (position < allContent.Length) //当对话还没有完成
		{
			//显示下一个对话
			introductionText.text = allContent[position];
			//对话位置加一
			position++;
		}
		else//对话完成
		{
			//跳转到下一个场景
			splashLoad.StartSplash(nextSceneToLoad, 2);
		}
	}

	/// <summary>
	/// 跳转到下一个场景
	/// </summary>
	public void ChangeToNextScene()
	{
		splashLoad.StartSplash(nextSceneToLoad, 2);
	}

}
