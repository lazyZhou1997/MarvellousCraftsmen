using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class SaveGameDataScript : MonoBehaviour
{

	public CurrentSenceDataShare CurrentSenceDataShare;//数据共享类
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// 保存游戏的存档
	/// </summary>
	public void SaveGameData(string sceneName)
	{
		if (null == ConfigureClass.archiveName) //如果存档名称为null，则存档失败
		{
			return;
		}
		
		//构建存档数据类
		GameData gameData = new GameData();
		//封装GameData数据
		gameData.currentPuzzleCode = TerrainTrackableEventHandler._currentCodeOfPuzzle;//拼图步骤号
		gameData.items = CurrentSenceDataShare.Items;//物品栏中物品的名称
		gameData.gameTime = ConfigureClass.finishTime;//游戏时长
		gameData.sceneName = sceneName;//当前场景名称
		
		//获取存档Json数据
		string gameDataJson = JsonUtility.ToJson(gameData);
		//将Json数据存储到PlayerPrefs中
		PlayerPrefs.SetString(ConfigureClass.archiveName, gameDataJson);
		
		//TODO:存档成功其他处理
	}
	
	/// <summary>
	/// 读取游戏存档
	/// </summary>
	/// <returns></returns>
	public GameData GetGameData()
	{
		//先读取Json字符串
		String gameDataJson = PlayerPrefs.GetString(ConfigureClass.archiveName, null);
		
		//如果读取处的Json字符串为null，则读取存档失败
		if (null==gameDataJson)
		{
			Debug.Log("读取存档失败");
			//TODO:读取存档失败其他处理
		}
		
		//将Json字符串转化为GameObject对象,返回结果
		return JsonUtility.FromJson<GameData>(gameDataJson);

	}


}
