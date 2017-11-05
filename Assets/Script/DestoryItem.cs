using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestoryItem : MonoBehaviour {

    #region 公共属性

    public CurrentSenceDataShare currentSenceDataShare;//当前场景的共享公共类

    public Image[] images = new Image[5];//当前物品栏中游戏物品的图片数组

    #endregion

    #region 私有属性

    private int activeIndex = -1;//当前激活对象的索引

    #endregion

    #region 公共方法

    /// <summary>
    /// 重物品栏中删除选中的物品
    /// </summary>
    public void RemoveItemChoicedFromItemBar()
    {
        //获得选中物品的索引
        activeIndex = currentSenceDataShare.GetIndexOfActiveItemGameObject();

        //如果当前选中对象索引是-1，不做操作
        if (-1 == activeIndex)
        {
            Debug.Log("当前选中对象索引是-1");
            return;
        }       
        
        #region 将图片数组中的图片换成item_box

        //销毁原来的精灵图片
        //DestroyImmediate(images[activeIndex].sprite); 
        //将该图片换成item_box
        images[activeIndex].sprite = LoadUtils.LoadSpriteFromResources(ConfigureClass.item_boxPicturePath);//从Resources文件夹下加载

        //删除选中物品的游戏对象
        currentSenceDataShare.DestoryActivedItemGameObjects();
        #endregion
    }

    /// <summary>
    /// 激活选中物品的ImageTarget
    /// </summary>
    public void ActiveChoicedImageTarget()
    {
        //如果当前选中对象索引是-1，不做操作
        if (-1 == activeIndex)
        {
            Debug.Log("当前选中对象索引是-1");
            return;
        }

        //获得选中物品的名称
        string name = currentSenceDataShare.RemoveItemInPosition(activeIndex);
        //如果当前选中对象名称为null，不做操作
        if (null==name)
        {
            Debug.Log("当前选中对象名称为null");
        }
        //激活指定名称的ImageTarget
        currentSenceDataShare.ActiveImageTargetByName(name);
    }

    #endregion

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
		
	}
}
