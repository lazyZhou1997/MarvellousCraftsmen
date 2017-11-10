using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialGameScript : MonoBehaviour
{
    public Image[] Images = new Image[5]; //对物品栏的引用

    public SaveGameDataScript SaveGameDataScript; //获取游戏存档类

    public CurrentSenceDataShare CurrentSenceDataShare; //获得数据共享数据类的引用

    // Use this for initialization
    void Start()
    {
        //游戏时间初始化为0
        ConfigureClass.finishTime = 0;
        //上次游戏时间初始化为0
        ConfigureClass.lastFinishTime = 0;

        //判断是否要读取存档，如果是，则进行读取
        if (ConfigureClass.isreadGameData)
        {
            #region 恢复游戏存档场景

            //读取游戏存档数据
            GameData gameData = SaveGameDataScript.GetGameData();

            //恢复游戏时间
            ConfigureClass.lastFinishTime = gameData.gameTime;

            //恢复拼图步骤编号
            TerrainTrackableEventHandler._currentCodeOfPuzzle = gameData.currentPuzzleCode;

            //恢复物品栏中存的物品名称
            CurrentSenceDataShare.Items = gameData.items;

            //恢复场景中的其他对象
            for (int i = 0; i < gameData.items.Length; i++)
            {
                //将items中的空串设置为null
                if (gameData.items[i].Equals(""))
                {
                    gameData.items[i] = null;
                }

                if (null != gameData.items[i]) //如果物品栏中的物品名称不为null，则进行处理
                {
                    //恢复物品栏中图片
                    Images[i].sprite = LoadUtils.LoadSpriteFromResources(
                        ConfigureClass.itemsPicturePath[gameData.sceneName] +
                        gameData.items[i]);

                    #region 恢复物品栏中对象的引用

                    Debug.Log("要实例化："+ConfigureClass.itemsPrefabPath[gameData.sceneName] +
                              gameData.items[i]);

                    //加载游戏对象
                    GameObject itemGaneGameObject =
                        LoadUtils.LoadPrefabFromResources(ConfigureClass.itemsPrefabPath[gameData.sceneName] +
                                                          gameData.items[i]);
                    //实例化
                    itemGaneGameObject = Instantiate(itemGaneGameObject);
                    //传入引用
                    CurrentSenceDataShare.AddItemGameObjects(itemGaneGameObject, i);

                    #endregion

                    //取消激活ImageTarget
                    GameObject currentModel = GameObject.Find(gameData.items[i]);
                    currentModel.SetActive(false);

                    //添加取消激活的ImageTarget到取消激活的集合中
                    CurrentSenceDataShare.TargetsSetDisactive.Add(gameData.items[i],currentModel);//参数一是要取消激活模型的名称，参数二是具体引用
                }
            }

            //取消激活任务栏中的所有对象
            CurrentSenceDataShare.DisActiveAllItemgGameObjects();

            #endregion
        }

        //继续上一次拼图设置为false
        ConfigureClass.isreadGameData = false;
    }

}