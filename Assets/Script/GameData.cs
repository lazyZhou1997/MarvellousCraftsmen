using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData
{

	#region 游戏存档内容

	public float gameTime;//游戏时间

	public string[] items;//游戏物品栏中的物品名称

	public string sceneName;//保存的游戏场景

	public int currentPuzzleCode;//当前拼图结果

	#endregion
}