using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGameMusic : MonoBehaviour
{
    //游戏背景音乐
    public AudioSource gameMusic;

	// Use this for initialization
	void Start () {
		
        //读取是否静音，没静音则播放背景音乐
	    if (!Convert.ToBoolean(PlayerPrefs.GetInt("mute")))
	    {
	        gameMusic.Play();
	    }
	}
	
}
