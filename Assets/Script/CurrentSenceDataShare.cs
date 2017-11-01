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

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
	{
	    
    }
}
