using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRepository : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//加载要显示的对象的预设体
		GameObject prefab = LoadUtils.LoadPrefabFromResources(ConfigureClass.itemsPrefabPath["result"]+ConfigureClass.showModelInRepository);
		//显示该对象
		Instantiate(prefab);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
