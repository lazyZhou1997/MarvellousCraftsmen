/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;

/// <summary>
///     A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    #region 共享数据类

    public CurrentSenceDataShare currentSenceDataShare;//共享数据类对象

    #endregion

    #region PRIVATE_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;


    private bool b_firstFound = true;//是否是第一次发现目标对象，默认是true，表示是
    #endregion // PRIVATE_MEMBER_VARIABLES

    #region UNTIY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NOT_FOUND)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS

    protected virtual void OnTrackingFound()
    {
        //如果是第一次发现该对象并且该对象已经激活，则进行一些操作，让屏幕中心的对象消失
        if (b_firstFound&&gameObject.activeSelf)
        {
            //取消当前场景中共享数据类的中所有对象的激活
            CancelActivationAllGameObjects(currentSenceDataShare.CurrentItemgGameObjects);

            //将第一次发现该对象设置为false
            b_firstFound = false;
        }

        //如果当前拼图结果存在并且为Active，则设置其为DisActive
        if (null != currentSenceDataShare.currentPuzzleResult
            && currentSenceDataShare.currentPuzzleResult.activeSelf)
        {
            Debug.Log("继续对象" + gameObject.name);
            //设置其为DisActive
            currentSenceDataShare.currentPuzzleResult.SetActive(false);
        }

        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;


        if (null != currentSenceDataShare)//保证共享数据类被初始化
        {
            //取得当前对象名称放入共享数据类中的相应位置
            currentSenceDataShare.ActiveModel = gameObject.name;
        }
    }


    protected virtual void OnTrackingLost()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;

        if (null != currentSenceDataShare)//保证共享数据类被初始化
        {
            //将共享数据类中的当前对象设置为null
            currentSenceDataShare.ActiveModel = null;
        }

        //将第一次发现该对象设置为true，此后再次发现该对象就是第一次发现
        b_firstFound = true;
    }

    #endregion // PRIVATE_METHODS

    /// <summary>
    /// 取消传入的GameObject对象数组中所有对象的激活
    /// </summary>
    private void CancelActivationAllGameObjects(GameObject[] gameObjects)
    {
        #region 取消以前的物品栏中对象的激活

        Debug.Log("进入取消对象激活");
        //将物品栏对象集合中的所有对象设置为不激活
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (null != gameObjects[i])
            {
                gameObjects[i].SetActive(false);
            }
        }
        Debug.Log("完场取消对象激活");
        #endregion
    }
}
