using UnityEngine;
using System.Collections;

public class UIAlert : MonoBehaviour {



	// Use this for initialization
	void Start () {
//		Debug.Log ("222&&&&&&&");
		setVisible (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	string str__;

	void OnGUI()
	{
		int width = 300;
		int height = 200;
		GUI.Box(new Rect(Screen.width/2-width/2,Screen.height/2-height/2,width,height),str__);
//
		if (GUI.Button (new Rect (Screen.width / 2 - width / 8, Screen.height / 2 - height / 16, width/4, height/4),"sure!"))
		{
			setVisible(false);
		}

	}

	public void setString(string str)
	{
		setVisible (true);
		str__ = str;
	}

	void setVisible(bool visible)
	{
		this.enabled = visible;

	}


}
