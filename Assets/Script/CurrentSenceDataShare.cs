using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 保存本场景中的一些共享数据
/// </summary>
public class CurrentSenceDataShare : MonoBehaviour
{
    #region 公共变量

    public GameObject currentPuzzleResult;//当前拼图结果

    #endregion

    //已经设置为disActive的ImageTarget对象，保存它们用于在取消保存到物品栏之后恢复其Active。
    private Dictionary<string, GameObject> targetsSetDisactive = new Dictionary<string, GameObject>();

    private string activeModel;//当前活跃的AR模型

    private string[] items = new string[5]; //表示物品栏中存的物品名称

    private GameObject[] currentItemgGameObjects = new GameObject[5];//当前物品栏中的对象集合
    
    public string ActiveModel
    {
        get { return activeModel; }
        set { activeModel = value; }
    }

    //获取对物品栏的引用
    public string[] Items
    {
        get { return items; }
    }

    public Dictionary<string, GameObject> TargetsSetDisactive
    {
        get { return targetsSetDisactive; }
    }

    public GameObject[] CurrentItemgGameObjects
    {
        get { return currentItemgGameObjects; }
    }

    #region 对外公共方法

    #region 对物品栏中对象的操作

    /// <summary>
    /// 激活物品栏中position处的对象
    /// </summary>
    /// <param name="position">int类型，范围为0-4</param>
    public void ActiveItemgGameObjectsInPositon(int position)
    {
        if (null!=currentItemgGameObjects[position])
        {
            currentItemgGameObjects[position].SetActive(true);
        }
    }

    /// <summary>
    /// 取消激活物品栏中的所有对象
    /// </summary>
    public void DisActiveAllItemgGameObjects()
    {
        foreach (GameObject itemgGameObject in currentItemgGameObjects)
        {
            //如果对象不为null，则取消激活
            if (null!=itemgGameObject)
            {
                itemgGameObject.SetActive(false);
            }  
        }
    }

    /// <summary>
    /// 增加游戏对象gameObject到position处
    /// </summary>
    /// <param name="gameObject">游戏对象</param>
    /// <param name="position">位置</param>
    public void AddItemGameObjects(GameObject itemGameObject,int position)
    {
        currentItemgGameObjects[position] = itemGameObject;
    }

    /// <summary>
    /// 删除物品栏游戏对象中当前已经激活的对象，也就是目前选中的对象
    /// </summary>
    public void DestoryActivedItemGameObjects()
    {
        for (int i = 0; i < currentItemgGameObjects.Length; i++)
        {
            //当前对象不为null并且已经被激活（被选中）
            if (null!=currentItemgGameObjects[i]&&currentItemgGameObjects[i].activeSelf)
            {
                //销毁对象
                Destroy(currentItemgGameObjects[i]);
                //该对象指向null
                currentItemgGameObjects[i] = null;
            }
        }
    }

    #endregion

    #region 对取消激活的ImageTarget对象的操作

    /// <summary>
    /// 激活name对应的ImageTarget
    /// </summary>
    /// <param name="name">要激活的ImageTarget的名称</param>
    public void ActiveImageTargetByName(string name)
    {
        //如果传入的name为null，不继续操作
        if (null==name)
        {
            Debug.Log("传入要激活的ImageTarget对象的值为null，在CurrentSenceDataShare类中");
            return;
        }

        //查询要激活的gameObject对象
        GameObject imagetTarget = targetsSetDisactive[name];
        //激活对象
        imagetTarget.SetActive(true);
        //从targetsSetDisactive中移除该ImageTarget
        targetsSetDisactive.Remove(name);
    }

    #endregion

    #region 对当前物品栏中ImageTarget对象名称的操作

    /// <summary>
    /// 移除指定位置的物品栏中存的物品名称
    /// </summary>
    /// <param name="position">要移除的位置,int类型，范围0-4</param>
    /// <returns></returns>
    public string RemoveItemInPosition(int position)
    {
        string name = items[position];//暂存名字
        items[position] = null;//移除名字

        return name;
    }

    #endregion

    #region 当前激活（选中）的物品栏中游戏对象的操作

    /// <summary>
    /// 返回当前激活（选中）对象的索引，如果没有激活对象则返回值为-1
    /// </summary>
    /// <returns>当前激活（选中）对象的索引，如果没有激活对象则值为-1</returns>
    public int GetIndexOfActiveItemGameObject()
    {
        for (int i = 0; i < currentItemgGameObjects.Length; i++)
        {
            //当前对象不为null并且已经被激活（被选中）
            if (null != currentItemgGameObjects[i] && currentItemgGameObjects[i].activeSelf)
            {
                //返回索引
                return i;
            }
        }

        return -1;
    }

    /// <summary>
    /// 返回当前激活（选中）对象的名称，如果没有激活对象则返回值null
    /// </summary>
    /// <returns>当前激活（选中）对象的名称，如果没有激活对象则返回值null</returns>
    public string GetNameOfActiveItemGameObject()
    {
        for (int i = 0; i < currentItemgGameObjects.Length; i++)
        {
            //当前对象不为null并且已经被激活（被选中）
            if (null != currentItemgGameObjects[i] && currentItemgGameObjects[i].activeSelf)
            {
                //返回名称
                return items[i];
            }
        }

        return null;
    }

    #endregion
    #endregion

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
	{
	    
    }

    #region 私有方法


    #endregion

}
