using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisassociateScrip : MonoBehaviour
{

    public string childName;

    //保存child对象的初始化位置
    private Transform saveTransform;

    //标记对象是否已经被取消关联
    private Boolean isDisassociate;

    void Start()
    {
        //保存子对象原来的位置
        saveTransform = gameObject.GetComponentInChildren<GameObject>().transform;
        //初始化为没有取消关联
        isDisassociate = false;
    }

    public void Click()
    {
        if (!isDisassociate)
        {
            //将ImageTarget与子对象解除关联
            gameObject.transform.DetachChildren();
        }
        else
        {
            
            //获得要挂上去的对象
            GameObject waterGameObject = GameObject.Find(childName);
            Destroy(waterGameObject);
            //设置要挂上去的对象的位置
            //waterGameObject.transform.SetPositionAndRotation(saveTransform.position,saveTransform.rotation);
            //将找到的对象挂上去
            //waterGameObject.transform.parent = gameObject.transform;
        }
        
    }

}
