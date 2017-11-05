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
public class TerrainTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    #region 公共变量

    public CurrentSenceDataShare currentSenceDataShare;//共享数据类对象

    public DestoryItem destoryItem;//销毁对象类

    #endregion

    #region PRIVATE_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;

    private int _currentCodeOfPuzzle = 1;//当前拼图编号，初始为1
    private int _endCodeOfPuzzle = ConfigureClass.sydneyStep["end"];//完成时的拼图编号
    private GameObject puzzleResult;//拼图成功后的对象持有

//    private bool b_firstFound = true;//是否是第一次发现目标对象，默认是true，表示是
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
//        //如果是第一次发现该对象并且该对象已经激活，则进行一些操作，让屏幕中心的对象消失
//        if (b_firstFound&&gameObject.activeSelf)
//        {
//            //取消当前场景中共享数据类的中所有对象的激活
//            CancelActivationAllGameObjects(currentSenceDataShare.CurrentItemgGameObjects);
//            //将第一次发现该对象设置为false
//            b_firstFound = false;
//        }


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


        //        if (null != currentSenceDataShare)//保证共享数据类被初始化
        //        {
        //            //取得当前对象名称放入共享数据类中的相应位置
        //            currentSenceDataShare.ActiveModel = gameObject.name;
        //        }

        #region 进行拼图处理

        //获得当前激活(选定)的游戏对象名称
        string name = currentSenceDataShare.GetNameOfActiveItemGameObject();
        if (null==name)//如果当前不存在选中对象
        {
            //则拼图失败
            return;
        }

        Debug.Log("要拼接的物品名称"+name);
        //获得当前激活（选定）的游戏对象对应的拼图编号
        int codeOfPuzzle = ConfigureClass.sydneyStep[name];
        //对比编号

        if (_currentCodeOfPuzzle==codeOfPuzzle)//编号满足，则拼接成功，拼图成功
        {
            //加载新的拼图结果
            GameObject tempGameObject =
                LoadUtils.LoadPrefabFromResources(ConfigureClass.sydneyStepPath + _currentCodeOfPuzzle);
            Debug.Log("要实例化的对象"+ ConfigureClass.sydneyStepPath + _currentCodeOfPuzzle);
            //实例化拼图结果
            tempGameObject = Instantiate(tempGameObject);

            //持有新拼图结果的引用，并且删除以前的拼图结果
            if (null!=puzzleResult)
            {
                //删除以前的拼图结果
                Destroy(puzzleResult);
            }
            //持有新拼图结果的引用
            puzzleResult = tempGameObject;
            //引用传给公共变量
            currentSenceDataShare.currentPuzzleResult = puzzleResult;

            Debug.Log("拼图" + _currentCodeOfPuzzle + "成功");

            //拼图编号增加1
            _currentCodeOfPuzzle++;

            //取消当前选中对象
            destoryItem.RemoveItemChoicedFromItemBar();
            //激活该对象对应的ImageTarget
            destoryItem.ActiveChoicedImageTarget();

            #region 拼图完成处理

            if ((_currentCodeOfPuzzle-1)==_endCodeOfPuzzle)
            {
                //TODO:拼图完成

                Debug.Log("拼图完成");
            }

            #endregion
        }
        else//编号不一致，拼图失败
        {
            //TODO:拼图失败操作
            Debug.Log("拼图" + _currentCodeOfPuzzle + "失败");
        }


        #endregion
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

//        if (null != currentSenceDataShare)//保证共享数据类被初始化
//        {
//            //将共享数据类中的当前对象设置为null
//            currentSenceDataShare.ActiveModel = null;
//        }
//
//        //将第一次发现该对象设置为true，此后再次发现该对象就是第一次发现
//        b_firstFound = true;
    }

    #endregion // PRIVATE_METHODS

//    /// <summary>
//    /// 取消传入的GameObject对象数组中所有对象的激活
//    /// </summary>
//    private void CancelActivationAllGameObjects(GameObject[] gameObjects)
//    {
//        #region 取消以前的物品栏中对象的激活
//
//        Debug.Log("进入取消对象激活");
//        //将物品栏对象集合中的所有对象设置为不激活
//        for (int i = 0; i < gameObjects.Length; i++)
//        {
//            if (null != gameObjects[i])
//            {
//                gameObjects[i].SetActive(false);
//            }
//        }
//        Debug.Log("完场取消对象激活");
//        #endregion
//    }
}
