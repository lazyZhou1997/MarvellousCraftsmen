using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于抓取一个对象到物品栏，并且取消该物品与ImageTarget的绑定
/// </summary>
public class CatchAModel : MonoBehaviour
{

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
	void Update () {
		
	}

    /// <summary>
    /// 将当前活跃的模型添加到物品栏数组items中
    /// </summary>
    public void AddModelToItems()
    {
        int position = 0;//物品栏中的空缺位置
        //从物品栏中找出空缺位置，如果大于5，则无空缺位置
        for (int i = 0; i < items.Length; i++)
        {
            //如果物品栏中已经存在该活动模型，则作一下处理
            if (items[i]!=null && items[i].Equals(currentSenceDataShare.ActiveModel))
            {
                //TODO:如果已经存在，则做以下处理
                return;
            }

            if (items[i]==null)
            {
                break;//找到空缺位置
            }
            //位置增加
            position++;
        }
        //当position的值大于等于物品栏长度，不存在空缺位置
        if (position >= items.Length)
        {
            //TODO:当任务栏位置不够的时候
            
            return;
        }

        //当position的值大于0且小于物品栏长度时，将当前活跃的模型的名字赋值给position对应的物品栏
        items[position] = currentSenceDataShare.ActiveModel;//ActiveModel是当前活动模型名字的访问器

        //卸载当前模型
        GameObject currentModel = GameObject.Find(items[position]);
        currentModel.SetActive(false);
        //将当前模型的引用进行保存，方便之后恢复
        targetsSetDisactive.Add(currentSenceDataShare.ActiveModel,currentModel);//参数一是要取消激活模型的名称，参数二是具体引用
    }
}
