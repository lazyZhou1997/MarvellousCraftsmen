using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 用于抓取一个对象到物品栏，并且取消该物品与ImageTarget的绑定
/// </summary>
public class CatchAModel : MonoBehaviour
{
    #region 物品栏中的五个按钮中的Image引用
    public Image[] itemImages = new Image[5];
    #endregion



    public CurrentSenceDataShare currentSenceDataShare;//当前场景中的共享数据类

    private String[] items;//当前场景中物品栏中物品的名称，会在Start()中被初始化并且赋值
    private Dictionary<string, GameObject> targetsSetDisactive;//当前场景中已经被取消激活的ImageTarget，会在Start()中被初始化并且赋值

    // Use this for initialization
    void Start ()
	{
	    items = currentSenceDataShare.Items;//获取物品栏数组的引用
	    targetsSetDisactive = currentSenceDataShare.TargetsSetDisactive;//获取对已经被取消激活的ImageTarget模型的引用
    }
	
	// Update is called once per frame
	void Update ()
	{

	}

    /// <summary>
    /// 将当前活跃的模型添加到物品栏数组items中
    /// </summary>
    public void AddModelToItems()
    {
        //如果当前活跃模型为空，则直接返回
        if (null == currentSenceDataShare.ActiveModel)
        {
            return;
        }

        int position = 0;//物品栏中的空缺位置
        //从物品栏中找出空缺位置，如果大于5，则无空缺位置
        for (int i = 0; i < items.Length; i++)
        {
            //如果物品栏中已经存在该活动模型，则作一下处理
            if (items[i]!=null && items[i].Equals(currentSenceDataShare.ActiveModel))
            {
                //将物品栏中物品对象设置为激活状态
                currentSenceDataShare.CurrentItemgGameObjects[i].SetActive(true);
                return;
            }

            if (items[i]==null)
            {
                break;//找到空缺位置
            }
            //位置增加
            position++;
        }
        Debug.Log(position);
        //当position的值大于等于物品栏长度，不存在空缺位置
        if (position >= items.Length)
        {
            //TODO:当任务栏位置不够的时候
            
            return;
        }

        //当position的值大于0且小于物品栏长度时，将当前活跃的模型的名字赋值给position对应的物品栏
        items[position] = currentSenceDataShare.ActiveModel;//ActiveModel是当前活动模型名字的访问器
        Debug.Log("当前对象是：" + currentSenceDataShare.ActiveModel);
        Debug.Log("items[position]中是："+items[position]);
        //卸载当前模型,将不再能够检测到改模型的状态
        GameObject currentModel = GameObject.Find(items[position]);
        currentModel.SetActive(false);//TODO:有错
        
        //将当前模型的引用进行保存，方便之后恢复
        targetsSetDisactive.Add(items[position],currentModel);//参数一是要取消激活模型的名称，参数二是具体引用
        //加载对应的资源到内存中
        //对刚刚添加到物品栏的物品，加载他的图片到物品栏图片集合中中
        Sprite itemSprite;//将要加载到内存的精灵图片
        GameObject itemGameObject;//将要实例化的prefab
        
        #region 完成物品栏中图片的加载
        //加载itemName对应的图片资源
        itemSprite = LoadUtils.LoadSpriteFromResources(ConfigureClass.sydneyItemsPicturePath + items[position]);
        //将Sprite图片加载到物品栏上,itemImages是对物品栏上的图片框的引用
        itemImages[position].sprite = itemSprite;
        #endregion

        #region 完成物品栏中对象的加载
        //加载对应的prefab对象,实例化预设体
        itemGameObject = LoadUtils.LoadPrefabFromResources(ConfigureClass.sydneyItemsPrefabPath + items[position]);
        Debug.Log("加载对象" + items[position]);
        itemGameObject = Instantiate(itemGameObject) as GameObject;
        //添加到当前物品栏中对象集合中
        currentSenceDataShare.AddItemGameObjects(itemGameObject,position);
        #endregion
    }
}
