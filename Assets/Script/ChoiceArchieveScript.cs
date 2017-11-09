using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceArchieveScript : MonoBehaviour
{

	public Dropdown Dropdown;//选择存档的控件

	// Use this for initialization
	void Start () {
		//获取上次选择的存档
		int lastChoice = PlayerPrefs.GetInt("archieve", 1);
		//设置上次的存档
		Dropdown.value = lastChoice;
		//设置当前存档
		ConfigureClass.archiveName = Convert.ToString(lastChoice);
	}

	// Update is called once per frame
	void Update () {

	}

	/// <summary>
	/// 选择当前存档作为存档
	/// </summary>
	public void ChoiceCurrentArchieve()
	{
		//这次存档的value值
		int choiceValue = Dropdown.value;
		//保存存档的value值
		PlayerPrefs.SetInt("archieve",choiceValue);
		//设置当前存档
		ConfigureClass.archiveName = Convert.ToString(choiceValue);
	}
}
