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
    #region 物品栏中的五个按钮中的Image引用
    public Image[] itemImages = new Image[5];
    #endregion
    public Text test;

    #region 动态加载路径

    private static string sydneyItemsPicturePath = "Resource\\picture\\ItemBar\\Sydney\\";//悉尼歌剧院的物品图片存储地址  
    private static string sydneyItemsPrefabPath = "Resource\\prefab\\Sydney\\";//悉尼歌剧院的Prefab存储地址
    #endregion

    //已经设置为disActive的ImageTarget对象，保存它们用于在取消保存到物品栏之后恢复其Active。
    private Dictionary<string, GameObject> targetsSetDisactive = new Dictionary<string, GameObject>();

    private string activeModel = null;//当前活跃的AR模型

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
	void Update () {
	    test.text = activeModel;

        //对items中的每一个物品，加载他们的图片到物品栏中
	    Sprite itemSprite;//将要加载到内存的精灵图片
	    GameObject itemGameObject;//将要实例化的prefab
        for (int i = 0; i < items.Length; i++)
	    {
	        if (items[i]!=null && !items[i].Equals(""))//防止为null时赋值
	        {
                #region 完成物品栏中图片的加载
                Debug.Log("reach");
	            //加载itemName对应的图片资源
	            itemSprite = (Sprite)Resources.Load(sydneyItemsPicturePath + items[i], typeof(Sprite));
                //将Sprite图片加载到物品栏上,itemImages是对物品栏上的图片框的引用
	            itemImages[i].sprite = itemSprite;
                #endregion

                #region 完成物品栏中对象的加载
                //加载对应的prefab对象,实例化预设体
	            itemGameObject = (GameObject) Resources.Load(sydneyItemsPrefabPath+items[i]+"Collider", typeof(GameObject));
	            itemGameObject = Instantiate(itemGameObject) as GameObject;
                //添加到当前物品栏中对象集合中
	            currentItemgGameObjects[i] = itemGameObject;
                #endregion
	        }
	    }
	}
}
