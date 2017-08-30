using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour {


    /**
     * 按下Button之后播放按钮音效
     * */
    public void playButtonPressedMusic() {

        //获取按钮音效
        AudioSource buttonpressedMusic = gameObject.GetComponent<AudioSource>();

        //播放按钮音效
        buttonpressedMusic.Play();

    }
}
