using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteCurrentArchieveScript : MonoBehaviour
{

	public Dropdown Dropdown;//存档选择控件

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// 删除当前选中的存档
	/// </summary>
	public void DeleteCurrentArchieve()
	{
		//删除当前存档
		PlayerPrefs.DeleteKey(ConfigureClass.archiveName);
	}
}
