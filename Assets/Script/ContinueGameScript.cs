using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGameScript : MonoBehaviour
{

	public SplashLoad SplashLoad;//加载场景脚本

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadArchieveScene()
	{
		//获取当前存档中的数据
		string gameDataJson = PlayerPrefs.GetString(ConfigureClass.archiveName);
		GameData gameData = JsonUtility.FromJson<GameData>(gameDataJson);
		//判断是不是有存档数据
		if (null==gameData)
		{
			Debug.Log("存档不存在");
			return;
		}

		//设置读取存档标志
		ConfigureClass.isreadGameData = true;
		//跳转到存档所在场景
		SplashLoad.StartSplash(gameData.sceneName,2);
	}
}
