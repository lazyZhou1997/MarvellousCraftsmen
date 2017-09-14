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

        //判断是否静音
        ClickSoundButton clickSoundButton = GameObject.Find("SoundButton").GetComponent<ClickSoundButton>();

        //如果不是静音播放按钮音效
        if (!clickSoundButton.mute){
            buttonpressedMusic.Play();
        }
    }
}
