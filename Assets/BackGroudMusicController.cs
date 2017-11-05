using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroudMusicController : MonoBehaviour {

    #region 公共变量

    public AudioSource backgroudMusic;//背景音乐控制

    #endregion

    // Use this for initialization
    void Start () {

        //获取是否静音
        int mute = PlayerPrefs.GetInt("mute",0);
        //如果不是静音，则播放背景音乐
        if (0 != mute&&null!=backgroudMusic)
        {
            backgroudMusic.Stop();
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
