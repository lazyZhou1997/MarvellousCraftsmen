using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentItemChoiced : MonoBehaviour {

    #region 公共变量

    //五个物品栏图片的引用
    public Button[] buttons = new Button[5];

    public int i_currentImageID; //当前选择的图片的ID，从0到4

    public CurrentSenceDataShare currentSenceDataShare;//当前场景的共享类对象

    #endregion

    #region 私有变量


    #endregion

    #region 私有成员变量的属性

    

    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 选中当前物品栏中物品
    /// </summary>
    public void ChoiceCurrentItem()
    {
        //设置共享类中物品栏游戏对象的当前对象为Active，其他为DisActive
        currentSenceDataShare.DisActiveAllItemgGameObjects();
        currentSenceDataShare.ActiveItemgGameObjectsInPositon(i_currentImageID);

//        //使另外五个物品栏按钮的不透明
//        for (int i = 0; i < buttons.Length; i++)
//        {
////            MaketCurrentImageNotTransparent(buttons[i]);
//        }

        //使当前按钮透明
//        MaketCurrentImageTransparent(buttons[i_currentImageID]);

        //MaketCurrentImageNotTransparent(GetComponent<Image>());
//        Debug.Log("当前物品栏对象的透明度："+gameObject.GetComponent<Image>().material.color.a);
//        for (int i = 0; i < images.Length; i++)
//        {
//            Debug.Log("物品栏"+i+"透明度为："+images[i].material.color.a);
//        }

    }

    #region 私有方法

//    /// <summary>
//    /// 使传入的按钮对象透明
//    /// </summary>
//    /// <param name="button"></param>
//    private void MaketCurrentImageTransparent(Button button)
//    {
//        Debug.Log("使按钮透明");
//        button.transform.GetComponent<SpriteRenderer>().color = new Color(1,1,1);
//    }
//
//    /// <summary>
//    /// 取消使传入按钮对象透明
//    /// </summary>
//    /// <param name="button"></param>
//    private void MaketCurrentImageNotTransparent(Button button)
//    {
//        
//    }

    #endregion
}
