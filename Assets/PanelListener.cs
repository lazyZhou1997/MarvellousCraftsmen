using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelListener : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    //激活此panel，点击选项按钮（OptionBT）时调用
    public void ShowOptionWindow()
    {
        //执行窗口显示状态
        gameObject.SetActive(true);
    }

    //隐藏panel，继续进行游戏
    public void HideOptionWindow()
    {
        //执行窗口隐藏
        gameObject.SetActive(false);
    }
}
