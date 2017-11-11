using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVedioScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//播放视频
		Handheld.PlayFullScreenMovie("gameintroduction.mp4", Color.black, FullScreenMovieControlMode.Full);
	}

}
