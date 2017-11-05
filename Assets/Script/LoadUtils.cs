using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUtils : MonoBehaviour {

    #region 对外静态公共方法

    /// <summary>
    /// 从Rescource资源文件夹的指定位置加载Sprite图片
    /// </summary>
    /// <param name="path">Resources资源夹下的指定位置</param>
    /// <returns></returns>
    public static Sprite LoadSpriteFromResources(string path)
    {
        Sprite itemSprite;//将要加载到内存的精灵图片
        //加载itemName对应的图片资源
        itemSprite = (Sprite)Resources.Load(path, typeof(Sprite));

        return itemSprite;

    }

    /// <summary>
    /// 从Rescource资源文件夹的指定位置加载预设体对象
    /// </summary>
    /// <param name="path">Resources资源夹下的指定位置</param>
    /// <returns></returns>
    public static GameObject LoadPrefabFromResources(string path)
    {
        GameObject prefab;//将要加载的预设体
        //从指定路径中加载资源
        prefab = (GameObject)Resources.Load(path, typeof(GameObject));

        return prefab;
    }

    #endregion
}