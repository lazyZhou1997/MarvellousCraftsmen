using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelToShowInRepository : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// 设置将要在仓库中显示的模型名字
	/// </summary>
	/// <param name="modelName">模型名字</param>
	public void ModelNameToShow(string modelName)
	{
		//在全局变量中设置该名字
		ConfigureClass.showModelInRepository = modelName;
	}
}
