using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class DisassociateScrip : MonoBehaviour
{
    //子对象预设
    public GameObject childObjectPrefab;

    //标记对象是否已经被取消关联
    private Boolean isDisassociate;

    //原来的子对象
    private GameObject childObject;


    void Start()
    {
        //保存子对象原来的位置
        childObject = transform.GetChild(0).gameObject;
        //初始化为没有取消关联
        isDisassociate = false;
    }

    public void Click()
    {
        if (!isDisassociate)
        {
            //将ImageTarget与子对象解除关联
            gameObject.transform.DetachChildren();
            //设置已经解除关联为true
            isDisassociate = true;

        }
        else
        {

            //销毁原来的对象
            Destroy(childObject);
            //实例化出新的子对象
            childObject = Instantiate(childObjectPrefab);

            #region 将预设对象设置为不可见

            SendMessage("OnTrackingLost()");
//            Renderer[] rendererComponents = childObject.GetComponents<Renderer>();
//            Collider[] colliderComponents = childObject.GetComponents<Collider>();
//
//            // Disable rendering:
//            foreach (Renderer component in rendererComponents)
//            {
//                component.enabled = false;
//            }
//
//            // Disable colliders:
//            foreach (Collider component in colliderComponents)
//            {
//                component.enabled = false;
//            }
            #endregion

            //设为子对象
            childObject.transform.parent = transform;
            //调整位置
            childObject.transform.localPosition = Vector3.zero;
            childObject.transform.localRotation = Quaternion.identity;
            //设置取消关联为false
            isDisassociate = false;
        }

    }

}
