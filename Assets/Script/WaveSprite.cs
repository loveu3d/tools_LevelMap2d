using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class WaveSprite : MonoBehaviour {

	public bool isTouchPressed;

	public WaveData spriteData = new WaveData ();

//	public SpriteWaveLine waveLine1;

	public SpriteWaveLine waveLine2;

//	Texture2D tex
	public void setVisible(bool isVisible)
	{

		MeshRenderer meshRender = this.GetComponent<MeshRenderer>();

		meshRender.enabled = isVisible;
//		if (waveLine1)
//		{
//						MeshRenderer waveLine11 = waveLine1.GetComponent<MeshRenderer> ();
//
//						waveLine11.enabled = isVisible;
//		}

		if (waveLine2)
		{
						MeshRenderer waveLine22 = waveLine2.GetComponent<MeshRenderer> ();
								waveLine22.enabled = isVisible;
		}
	}

	void refreshTextureScale ()
	{
		if (this.GetComponent<Renderer>().material.mainTexture)
		{
			Debug.Log("refreshTextureScale");
			Debug.Log(this.GetComponent<Renderer>().material.mainTexture.width);
			Debug.Log(this.GetComponent<Renderer>().material.mainTexture.height);

			float scaleValueX = this.GetComponent<Renderer>().material.mainTexture.width / GameManager.scale_value_x;

			float scaleValueY = this.GetComponent<Renderer>().material.mainTexture.height / GameManager.scale_value_y;

			this.transform.localScale = new Vector3 (scaleValueX, 0.1f, scaleValueY);
		}

	}

	void init_wave_line()
	{
//		if (waveLine1) 
//		{
//			waveLine1 = (SpriteWaveLine)Instantiate (waveLine1, this.transform.position, this.transform.rotation);
//		}
		if (waveLine2) 
		{
			waveLine2 = (SpriteWaveLine)Instantiate (waveLine2, this.transform.position, this.transform.rotation);
		}
	}

	void updateToWorld00()
	{
		float posX = GameManager.coverScreenX2WorldPosX(0);
		
		float posY = GameManager.coverScreenY2WorldPosY(0);
		
		Vector3 vectorPos;
		
		vectorPos =new Vector3( posX, posY,0.6f);
		
		this.transform.position = vectorPos;
	}

	void Start () 
	{
		updateToWorld00 ();

//		refreshTextureScale ();

		init_wave_line ();
	
	}


	public class WaveData
	{
//		public string wave_x1 = "";

		public string wave_x2 = "";

		public string wave_bossing = "";

		public string next_time = "";

		public string wave_id = "";//only in export

		public void clone(WaveData cloneA)
		{
//			this.wave_x1 = cloneA.wave_x1;

			this.wave_x2 = cloneA.wave_x2;

			this.next_time = cloneA.next_time;

			this.wave_bossing = cloneA.wave_bossing;
		}

	}



	public void updateWavePropetyToGUI()
	{
		UIPropetyPanel.text_wave_x2=spriteData.wave_x2;

		UIPropetyPanel.text_wave_bossing=spriteData.wave_bossing;

		//
		UIPropetyPanel.text_wave_next_time=spriteData.next_time;
	}
	
	public void updateWaveGUIToPropety()
	{
		spriteData.wave_x2=UIPropetyPanel.text_wave_x2;

		spriteData.wave_bossing=UIPropetyPanel.text_wave_bossing;

		spriteData.next_time=UIPropetyPanel.text_wave_next_time;
	}

	void OnMouseEnter()
	{

	}

	void updateWaveLine (int index)
	{
		string strPos="";

//		SpriteWaveLine waveLine = null;

//		if (index == 1) {
//			strPos = spriteData.wave_x1;
//			waveLine=waveLine1;
//		}else 
//			if(index == 2)

		strPos = spriteData.wave_x2;
//		waveLine=waveLine2;



		float alert_x = 0;
		if (strPos.Equals ("")==false) 
		{
			bool parse_faild=false;
			try{
				alert_x = int.Parse (strPos);
			}catch(Exception ex)
			{
				Debug.Log (ex);
				parse_faild=true;
			}
			
			if(parse_faild==false)
			{	
				alert_x = alert_x / GameManager.scale_value_x*10;
			}
			
		}
//		Debug.Log (alert_x);
		
		Vector3 vector = new Vector3( this.transform.position.x + alert_x,this.transform.position.y,this.transform.position.z ) ;

//		if (index == 1) {
//			if(waveLine1)
//			waveLine1.transform.position = vector;
//		} else  if(index==2)
		{
			if(waveLine2)
			waveLine2.transform.position = vector;
		}

		MeshRenderer meshRender=null;// = waveLine.GetComponent<MeshRenderer>();
//		if (index == 1) {
//			if(waveLine1)
//			meshRender=waveLine1.GetComponent<MeshRenderer>();
//		} else  if(index==2)
		{
			if(waveLine2)
			meshRender=waveLine2.GetComponent<MeshRenderer>();
		}

		if (strPos.Equals ("")) {
			if(meshRender)
			meshRender.enabled = false;
		} else {
			if(meshRender)
			meshRender.enabled=true;
		}

	}

	void Update () 
	{
//		updateWaveLine (1);

		updateWaveLine (2);
	}

	Vector3 curobjPos, curmousePos, mousePosfirst, objPosfirst, differencePos;
	
	Vector3 curScreenSpace;
	
	Vector3 curPosition;


	void OnGUI()
	{
		if(isTouchPressed)
		{

		}
	}


//	void setMonsterVisible(bool isVisible)
//	{
//		GameObject[] gos;
//
//		gos = GameObject.FindGameObjectsWithTag("ActionSprite");
//
////		GameObject closest;
//
//		foreach (GameObject go in gos)
//		{
//			ActionSprite sprite = go.GetComponent<ActionSprite>();
//			if(sprite)
//			{
//			sprite.isTouchPressed=false;
//			}
//		}
//		isTouchPressed = true;
//	}

	void Destory()
	{
		Debug.Log ("killed");
	}

}






