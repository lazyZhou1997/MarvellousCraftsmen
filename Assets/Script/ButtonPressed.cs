using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPressed : MonoBehaviour {


    /**
     * 按下Button之后播放按钮音效
     * */
    public void playButtonPressedMusic() {

        //获取按钮音效
        AudioSource buttonpressedMusic = gameObject.GetComponent<AudioSource>();

        //获取是否静音
        int mute = PlayerPrefs.GetInt("mute",0);

        Debug.Log("是否静音："+mute);

        //如果不是静音则播放按钮音效
        if (0==mute){
            buttonpressedMusic.Play();
        }
    }
}
