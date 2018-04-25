using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Xml;
using System.IO;
using System.Security;
using System.Xml;
using System.Text;
using System;

public class GameManager : MonoBehaviour {
	UIPropetyPanel uiPropetyPanel;
//	public static UIPropetyPanel uiPlane = new UIPropetyPanel();
//	public static float scale_value_x = 3252.0f;
//	
//	public static float scale_value_y = 3210.0f;
	public static float scale_value_x = 3200.0f;

	public static float scale_value_y = 3200.0f;

	public static GameManager Instance;
	// Use this for initialization
	public ActionSprite m_Sprite;

//	public ActionNewSprite m_NewSprite;

	public WaveSprite m_WaveSprite;
	
	public static GameObject select_sprite = null;
	
//	GameObject lastNewMonsterObject =null ;
	
	Vector3 vectorPos;

	int unique_id;

//	public static string test_level_name = "";

	public static Vector3 second_sprite_pos;

	void Start () {
		this.tag = "MainCamera";

//		m_Sprite = Assert

		Screen.SetResolution (960, 640, true);

		int count = int.Parse(UIPropetyPanel.text_level_max_wave);

		for (int i=0; i<count; i++) 
		{
			create_waveSprite ();
		}
	

//		GameObject []gameObjects3;
//		
//		gameObjects3 = GameObject.FindGameObjectsWithTag ("FebWaveSprite");

//		Debug.Log("Update");

//		Debug.Log(gameObjects3.Length);

	}
	float costTime = 0;

	// Update is called once per frame
	void Update () {


		float move_offset_x = 0.1f;

		if(Input.GetKey (KeyCode.A))
	    {
//			if(Camera.main.camera.transform.position.x>0)
//			{
			Camera.main.GetComponent<Camera>().transform.Translate(-move_offset_x,0,0);
//			}else{
////				Camera.main.camera.transform.position.x=0.0f;
//			}

		}else if(Input.GetKey (KeyCode.D))
		{
		
			Camera.main.GetComponent<Camera>().transform.Translate(move_offset_x,0,0);
		}

		if(Input.GetKey (KeyCode.W))
		{
			Camera.main.GetComponent<Camera>().transform.Translate(0,move_offset_x,0);
		}else if(Input.GetKey (KeyCode.S))
		{
			Camera.main.GetComponent<Camera>().transform.Translate(0,-move_offset_x,0);
		}

		costTime += Time.deltaTime;
		if (costTime>0.5f) 
		{
			costTime=0.0f;
						if (Input.GetKey (KeyCode.E)) {
								create_sprite ();
						}
		}


		if(Input.GetKey (KeyCode.Delete)||Input.GetKey (KeyCode.Q))
		{
			remove_sprite();
		}

		if(Input.GetKey (KeyCode.Alpha1))
		{
			//Sprite
		UIPropetyPanel.	selectedTabIndex=0;
		}

		if(Input.GetKey (KeyCode.Alpha2))
		{
			//Wave
			UIPropetyPanel.	selectedTabIndex=1;
		}

		if(Input.GetKey (KeyCode.Alpha3))
		{
			//Level
			UIPropetyPanel.	selectedTabIndex=2;

		}

//		Debug.Log ("__________________");
//		Debug.Log (Camera.main.camera.transform.position);

//		GameObject background = GameObject.FindWithTag ("Background");

//		GameObject[] handSprite;
//
//		handSprite =  GameObject.FindGameObjectsWithTag("ActionSprite");
//
////		background.transform.Rotate(100 * Time.deltaTime, 100 * Time.deltaTime, 0);
//
//		for(int i = 0;i < handSprite.Length;i++)
//		{
////			handSprite[i].transform.position = handSprite[i].transform.position + background.transform.position;
////			handSprite[i].transform.Rotate(100 * Time.deltaTime, 100 * Time.deltaTime, 0);
//		}

	}//fffffffff

	public void deleteWaveSprite()
	{
		GameObject[] handSprite;

//		int length =handSprite.Length;

		handSprite =  GameObject.FindGameObjectsWithTag("FebWaveSprite");

		foreach (GameObject go in handSprite) 
		{
			WaveSprite sprite2 = go.GetComponent<WaveSprite> ();

			if (sprite2)
			{
				Destroy(go);
			}
		}

	}

	public void refreshWaveSprite()
	{
		int count = int.Parse( UIPropetyPanel.text_level_max_wave);

		GameObject[] handSprite;
		
		handSprite =  GameObject.FindGameObjectsWithTag("FebWaveSprite");

		int length =handSprite.Length;

		if (length < count) 
		{
			for (int i=0; i<count-length; i++) 
			{
					create_waveSprite ();
			}
		} else if(length>count)
		{
			//remove 
			while(length!=count)
			{
				foreach (GameObject go in handSprite) 
				{
					WaveSprite sprite2 = go.GetComponent<WaveSprite> ();
					if (sprite2	&& sprite2.enabled &&	sprite2.name.Equals(length.ToString()))
					{
						sprite2.enabled=false;
						Destroy(go);
						break;
					}
				}


				length--;
			}

		}

		int wave_id = (int)UIPropetyPanel.show_sprite_wave_id;
		if (wave_id > count)
		{
			UIPropetyPanel.show_sprite_wave_id=count;
		}

	}

	public void refreshMapSpriteImage()
	{
		GameObject[] gos;
		
		gos = GameObject.FindGameObjectsWithTag("ActionSprite");

		foreach (GameObject go in gos) 
		{
			ActionSprite sprite = go.GetComponent<ActionSprite> ();
			if(sprite)
			{
				sprite.refreshTextureWithBGName();
			}
		}

	}

	public void refreshAllActionSpriteImage()
	{
		GameObject[] gos;

		gos = GameObject.FindGameObjectsWithTag("ActionSprite");

//		Debug.Log ("ActionSprite");

//		Debug.Log(gos.Length);

		foreach (GameObject go in gos) 
		{
			ActionSprite sprite = go.GetComponent<ActionSprite> ();
			if(sprite)
			{
			sprite.refreshTextureWithTag();
			}
		}

	}
	//TODO remove sprite
	public static bool CleanData = false;
	public void remove_sprite()
	{
		ActionSprite sprite=getSelectedActionSprite();


		if (sprite)
		{		
			sprite.spriteData.alert_x = null;


//			Destroy(sprite.alertLine);
			Debug.Log("sprite.spriteData.alert_x:"+sprite.spriteData.alert_x);

//			GameObject.Destroy (sprite);

//			DestroyImmediate(sprite);
			Destroy(sprite);

			sprite.refreshTextureScale0 ();
//			DestroyObject(sprite);
//			sprite=null;
			CleanData = true;
		}

		GC.Collect ();
	}
	//TODO Remove all BG
	public void deleteMap()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag("ActionSprite");

		foreach (GameObject obj in objs)
		{		
			ActionSprite sprite = obj.GetComponent<ActionSprite> ();

			if(sprite&&(sprite.spriteData.class_type.Equals(UIPropetyPanel.CLASS_BG)
			            ||sprite.spriteData.class_type.Equals(UIPropetyPanel.CLASS_RECT)
			            ||sprite.spriteData.class_type.Equals(UIPropetyPanel.CLASS_TRIGGER) ||sprite.spriteData.class_type.Equals(UIPropetyPanel.CLASS_MONSTER_AREA))
			   ){

				Destroy(sprite);
				
				sprite.refreshTextureScale0 ();
				
				CleanData = true;
			}

		}
		
		GC.Collect ();
	}

	//TODO Add all BG
	public void add_spriteBG()
	{
		//Add bg map



		Debug.Log ("Add the map");
	}

	public ActionSprite getSelectedActionSprite()
	{

		GameObject[] gos;
		
		gos = GameObject.FindGameObjectsWithTag("ActionSprite");
		
		foreach (GameObject go in gos) 
		{
			ActionSprite sprite = go.GetComponent<ActionSprite> ();
			if (sprite&&sprite.isTouchPressed)
			{
				return sprite;
			}
		}
		
		return null;
	}

	
	public static ActionSprite spriteFirstSelect = null;
	
	public static ActionSprite spriteSecondSelect = null;

	public static void setSelectedActionSprite(ActionSprite sprite)
	{
		GameObject[] gos;
		
		gos = GameObject.FindGameObjectsWithTag("ActionSprite");
		
		foreach (GameObject go in gos) 
		{
			ActionSprite __sprite = go.GetComponent<ActionSprite> ();
			if (sprite&&__sprite)
			{
				__sprite.isTouchPressed = false;
			}
		}

		sprite.isTouchPressed = true;

		if (spriteFirstSelect == null) {
						spriteFirstSelect = sprite;
		} else{
			if(sprite != spriteFirstSelect)
			{
			spriteSecondSelect=spriteFirstSelect;

			spriteFirstSelect=sprite;

			second_sprite_pos = spriteSecondSelect.transform.position;

				if(sprite.spriteData.class_type=="bg"&&spriteSecondSelect)
				{
					second_sprite_pos =	spriteSecondSelect.transform.position ;
				}else{
					second_sprite_pos = new Vector3(0,0,0);
				}


			}

		

		}


	}


	public bool isUnique(string unique)
	{
		GameObject[] gos;
		
		gos = GameObject.FindGameObjectsWithTag ("ActionSprite");
		
		foreach (GameObject go in gos) {
			ActionSprite sprite = go.GetComponent<ActionSprite> ();
			if (sprite&&sprite.spriteData.unique_id.Equals(unique)) 
			{
				return false;
			}
		}
		return true;
	}


	
	public WaveSprite getSelectedWaveSprite()
	{
		GameObject[] gos;
		
		gos = GameObject.FindGameObjectsWithTag("FebWaveSprite");
		WaveSprite sprite = null;
		foreach (GameObject go in gos) 
		{
			WaveSprite sprite2 = go.GetComponent<WaveSprite> ();
			if (sprite2)
			{

				int sprite_wave_id = (int)UIPropetyPanel.show_sprite_wave_id;

//				Debug.Log(sprite2.name+":"+value.ToString());

//				Debug.Log("name:"+sprite2.name+ "x2:"+sprite2.spriteData.wave_x2+":"+"next_time:"+sprite2.spriteData.next_time);

				if( sprite2.name.Equals(sprite_wave_id.ToString()))
				{

					sprite=sprite2;
				}else{

				}

			}

		}
		
		return sprite;
	}


	public void ClearAllSpriteAndData()
	{
		return;
		/*
		while (GameObject.FindGameObjectWithTag("FebWaveSprite"))
		{
			DestroyImmediate (GameObject.FindGameObjectWithTag("FebWaveSprite"));
		}

		while (GameObject.FindGameObjectWithTag("ActionSprite")) 
		{		
			DestroyImmediate (GameObject.FindGameObjectWithTag("ActionSprite"));
		}
		*/
	}

	
	public void create_waveSprite()
	{
		GameObject []gameObjects3;
		
		gameObjects3 = GameObject.FindGameObjectsWithTag ("FebWaveSprite");
		
		int count =	gameObjects3.Length;
		
		m_WaveSprite =(WaveSprite) Instantiate (m_WaveSprite,m_WaveSprite.transform.position,m_WaveSprite.transform.rotation);
		
		GameObject []gameObjects2;
		
		gameObjects2 = GameObject.FindGameObjectsWithTag ("FebWaveSprite");
		
		m_WaveSprite.name = gameObjects2.Length.ToString();

		//TODO 1200
		if (count == 0) 
		{
			//第一次初始化参数
//			m_WaveSprite.spriteData.wave_x2="1200";
			m_WaveSprite.spriteData.wave_x2="";
			m_WaveSprite.spriteData.wave_bossing="";
			m_WaveSprite.updateWavePropetyToGUI();
		}
		
	}

	public void create_waveSprite(WaveSprite.WaveData spData,int tag_index)
	{
		try{
			if(spData.wave_x2.Equals("")==false){
				float x2 = coverScreenX2WorldPosX (int.Parse (spData.wave_x2));
				Vector3 vectorPos;
				
				vectorPos =new Vector3( -x2, 0,0.6f);
				
				m_WaveSprite.transform.position = vectorPos;

				m_WaveSprite = (WaveSprite)Instantiate (m_WaveSprite,m_WaveSprite.transform.position,m_WaveSprite.transform.rotation);
				
				m_WaveSprite.name = tag_index.ToString();
				
				m_WaveSprite.spriteData = new WaveSprite.WaveData ();
				
				m_WaveSprite.spriteData = spData;	
			}

		}catch{
			Debug.Log("Don't create first time");
		}
//		float x2 = coverScreenX2WorldPosX (int.Parse (spData.wave_x2));
		

		


		//update gui
		int sprite_wave_id = (int)UIPropetyPanel.show_sprite_wave_id;

		if (m_WaveSprite.name.Equals (sprite_wave_id.ToString ())) 
		{
			m_WaveSprite.updateWavePropetyToGUI();
		}

	}


	public void Copy2Next()
	{
		ActionSprite sprite=getSelectedActionSprite();
		
		if (sprite) 
		{
				// 将上一个用户点击的sprite的属性进行拷贝 
				m_Sprite.transform.position = vectorPos;
				Debug.Log ("Create Sprite" + vectorPos);
				if (second_sprite_pos.x == 0.0f && second_sprite_pos.y == 0.0f) {
						vectorPos = new Vector3 (sprite.transform.position.x, sprite.transform.position.y, sprite.transform.position.z);

				}

		}


		ActionSprite newSprite =(ActionSprite) Instantiate (m_Sprite,m_Sprite.transform.position,m_Sprite.transform.rotation);
		
		
		
		if (newSprite&&sprite)
		{
			newSprite.spriteData = new ActionSprite.SpData();
			newSprite.spriteData.clone(sprite.spriteData);
		}
		
		int wave_id =(int) UIPropetyPanel.show_sprite_wave_id;	
		
		newSprite.spriteData.create_unique_id();
		
		//更新新精灵到属性面板
		newSprite.updatePropetyToGUI();
		
		setSelectedActionSprite (newSprite);



	//	ActionSprite sprite=getSelectedActionSprite();

//		Vector3 posVector = spriteSelect.transform.position;

//		newSprite.transform = posVector;
//
//		newSprite.updatePropetyToGUI ();
//		if (spriteSelect && spriteSelect.__spriteAction
//		    && spriteSelect.__spriteAction.renderer 
//		    && spriteSelect.__spriteAction.renderer.material
//		    && spriteSelect.__spriteAction.renderer.material.mainTexture)
		{
//						float width = spriteSelect.__spriteAction.renderer.material.mainTexture.width * 10 / GameManager.scale_value_x;
//
////		float offsetX = GameManager.coverScreenX2WorldPosX (spriteSelect.renderer.material.mainTexture.width);
//						Debug.Log ("width:" + width);
//


			float offsetX = sprite.__spriteAction.copyWidth * 10 / GameManager.scale_value_x;
//
//						Debug.Log ("offsetX:" + offsetX);

//			float offsetX =	spriteSelect.transform.localScale.x;

//			Debug.Log ("offsetX:" + offsetX);

			float finalOffsetX = offsetX;// fixedWorldPosX(offsetX);

			Vector3 posVector22 = new Vector3 (sprite.transform.position.x + finalOffsetX, sprite.transform.position.y, sprite.transform.position.z);
//
						newSprite.transform.position = posVector22;

					newSprite.updatePropetyToGUI ();
		}

//		newSprite.spriteData.pos_x 

//		newSprite.transform.position =

	}

	public ActionSprite create_sprite()
	{
		ActionSprite sprite=getSelectedActionSprite();

		if (sprite)
		{
			// 将上一个用户点击的sprite的属性进行拷贝 
			m_Sprite.transform.position = vectorPos;
			Debug.Log("Create Sprite" + vectorPos);
			if(second_sprite_pos.x==0.0f&&second_sprite_pos.y==0.0f)
			{
			vectorPos =new Vector3( sprite.transform.position.x, sprite.transform.position.y,sprite.transform.position.z);
			}else{
				
			}

		}

		ActionSprite newSprite =(ActionSprite) Instantiate (m_Sprite,m_Sprite.transform.position,m_Sprite.transform.rotation);


		if (newSprite&&sprite)
		{
			newSprite.spriteData = new ActionSprite.SpData();
			newSprite.spriteData.clone(sprite.spriteData);
		}

		int wave_id =(int) UIPropetyPanel.show_sprite_wave_id;	

		newSprite.spriteData.create_unique_id();

//		newSprite.name = m_Sprite.spriteData.tag_id + "";

		//更新新精灵到属性面板
		newSprite.updatePropetyToGUI();

		setSelectedActionSprite (newSprite);

//		newSprite.refreshTextureWithBGName ();

		return newSprite;
	}

	public void create_sprite(ActionSprite.SpData spData)
	{
		float posX = 0;

		float posY = 0;

		try{
			//old
//			posX = coverScreenX2WorldPosX(int.Parse (spData.pos_x));
//			posY = coverScreenY2WorldPosY(int.Parse (spData.pos_y));

			//modify display position
			posX = float.Parse( spData.display_x);
			posY = float.Parse( spData.display_y); 

		}catch(Exception e)
		{

		}

		Vector3 vectorPos;

		vectorPos =new Vector3( posX, posY,0.6f);
		
		m_Sprite.transform.position = vectorPos;

		ActionSprite newSprite = (ActionSprite)Instantiate (m_Sprite,m_Sprite.transform.position,m_Sprite.transform.rotation);

		newSprite.spriteData = new ActionSprite.SpData ();

		newSprite.spriteData = spData;

		newSprite.spriteData.create_unique_id();

		newSprite.updatePropetyToGUI ();

		setSelectedActionSprite (newSprite);

//		newSprite.refreshTextureWithBGName ();

			newSprite.name = m_Sprite.spriteData.tag_id + "";

	}
	
	void OnDrawGizmos()
	{

	}

	public static int coverWorldPosXToScreenX(float posX)
	{
//		return ((int)((posX) * 960 * 2 / 3 + 960) / 2);
//		float posXX =((posX) * 320 + 480);
//		float posXX2 =((posX) * 320.0f + 480.0f);

//		Debug.Log ("posXX:"+posXX+" posXX2:"+posXX2);

		float posX__ = (posX) * 320.0f ;
		float posX2__ = posX__+480.0f;
		return (int)posX2__;

//		return ((int)((posX) * 320.0f + 480.0f) );

	}
	
	public static int  coverWorldPosYToScreenY(float posY)
	{
//		return ((int)(( posY )*960*2/3 +640)/2);

		float posY__ = (posY) * 320.0f ;
		float posY2__ = posY__+320.0f;
		return (int)posY2__;

//		return ((int)(( posY )*320.0f +320.0f));

	}

	public static float coverScreenX2WorldPosX(int pixX)
	{
		return (float)(2*pixX-960)*3/2.0f/960.0f;
	}                            
	                                              
	public static float  coverScreenY2WorldPosY(int pixY)
	{
		return (float)(2*pixY-640)*3/2.0f/960.0f;                                                      
	}

	public static float fixedWorldPosX(float display_x)
	{
		int screenX = coverWorldPosYToScreenY (display_x);

		float __posX =  coverScreenX2WorldPosX(screenX);

		return __posX;
	}

	public static float fixedWorldPosY(float display_y)
	{
		int screenY = coverWorldPosYToScreenY (display_y);
		
		float __posY =  coverScreenY2WorldPosY(screenY);
		
		return __posY;
	}            

//	public Material mat0;
//
//	void OnPostRender()
//	{
//		GL.LoadOrtho ();
//		GL.Begin (GL.QUADS);
//
//		DrawRect (100,100,100,100,mat0);
//
//		GL.End ();
//	}
//	
//	void DrawRect(float x,float y,float width,float height,Material mat)
//	{
////		GL.PushMatrix ();
//////		mat.SetPass (0);
////		GL.LoadOrtho ();
////		GL.Begin (GL.QUADS);
//		
//		GL.Vertex3 (x/Screen.width,y/Screen.height,0);
//		GL.Vertex3 (x/Screen.width,(y+height)/Screen.height,0);
//		GL.Vertex3 ((x+width)/Screen.width,(y+height)/Screen.height,0);
//		GL.Vertex3 ((x+width)/Screen.width,y/Screen.height,0);
//		
////		GL.End ();
////		GL.PopMatrix ();
//	}

}



