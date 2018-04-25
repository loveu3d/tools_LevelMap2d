using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class ActionSprite : MonoBehaviour {

	public bool isTouchPressed;

	public bool isTouchActive;

	public void setTouchActive(bool isActive)
	{
		isTouchActive = isActive;

		if (isTouchActive) {

		} else {

		}
	}

	public SpData spriteData = new SpData ();

//	Rect rectInPixe = new Rect(0,0,100,100);

//	public Texture textureRect;
	public SpriteText spriteText;

	public SpriteAlertLine alertLine;

//	public Rect rectSprite;

//	public ActionSprite spriteRect;
	public SpriteAction __spriteAction;

	public SpriteLineRender __spriteLineRender;
	//

	void Start () 
	{		
		init_line_render ();

		init_sprite_action ();

		init_warning_line ();


		if (spriteData.class_type.Equals (UIPropetyPanel.CLASS_BG) == true && spriteData.bg_name.Equals ("") == false) {
				refreshTextureWithBGName ();
		}// else if (spriteData.class_type.Equals ("sprite")) 
		else
		{
			refreshTextureWithTag ();

		}

		init_text_render ();

	}
	
//	private GameObject LineRenderGameObjcect;

	private LineRenderer lineRender;
	
	private int lineLength =11;
	
//	private Vector3 v0 = new Vector3(1.0f,0.0f,0.0f);
//	private Vector3 v1 = new Vector3(2.0f,0.0f,0.0f);
//	private Vector3 v2 = new Vector3(3.0f,0.0f,0.0f);
//	private Vector3 v3 = new Vector3(4.0f,0.0f,0.0f);

	void init_text_render()
	{
//		spriteText.guiTexture;
		GameObject text = new GameObject ();
//		text.AddComponent<UIButton> ();
//		__spriteAction.a
	}

	
	void update_draw_show_time()
	{
		//draw_show_time()
		
		//draw_update_time()
//		return;

		String commponentName = "New Text";
		//abc
		if (spriteData.class_type == UIPropetyPanel.CLASS_MONSTER_AREA
		    ||
						spriteData.class_type == UIPropetyPanel.CLASS_SPRITE
		    ) 
		{
			if (spriteData.show_time.Equals ("") == false) {
					Transform text = (Transform)__spriteAction.transform.Find(commponentName);
					text.GetComponent<TextMesh>().gameObject.SetActive (true);// .transform.gameObject.SetActive();
					text.GetComponent<TextMesh>().text = "" + spriteData.show_time;
			} else {
					Transform text = (Transform)__spriteAction.transform.Find(commponentName);
					text.GetComponent<TextMesh>().gameObject.SetActive (false);
			}

		} else 
		{
			Transform text = (Transform)__spriteAction.transform.Find (commponentName);
			text.GetComponent<TextMesh>().gameObject.SetActive (false);
		}
	
		//def
	}



	void init_line_render()
	{
//		GameObject object = new GameObject();

//		object.Equals();

		__spriteLineRender = (SpriteLineRender)Instantiate (__spriteLineRender,this.transform.position,this.transform.rotation);

//		__spriteLineRender = GameObject.FindGameObjectWithTag ("ObjLine");

		if (__spriteLineRender) 
		{
			lineRender = (LineRenderer)__spriteLineRender.GetComponent ("LineRenderer");
	
			if(lineRender)
			{
				lineRender.SetVertexCount (lineLength);

				lineRender.SetWidth (0.01f,0.01f);

				lineRender.material = new Material (Shader.Find("Particles/Additive"));

			}

		}
	
	}


	void update_line_render()
	{
		bool isUpdate = false;

		if (lineRender && (spriteData.class_type == UIPropetyPanel.CLASS_RECT
						|| spriteData.class_type == UIPropetyPanel.CLASS_MONSTER_AREA
		                   )
		   )
		{
			if(isTouchActive)
			{
				isUpdate = true;
			}

			if( spriteData.class_type == UIPropetyPanel.CLASS_MONSTER_AREA)
			{

			if(isTouchActive)
			{
				//渲染框线
				isUpdate = true;	
					lineRender.GetComponent<Renderer>().enabled = true;

			}else
			{
				//不渲染框线
				isUpdate=false;
					lineRender.GetComponent<Renderer>().enabled = false;

			}

			}


			if(spriteData.class_type == UIPropetyPanel.CLASS_MONSTER_AREA)
			{
				lineRender.SetColors( Color.red, Color.red);
			}else{
				lineRender.SetColors( Color.green, Color.green);
			}

		} else 
		{
			lineRender.GetComponent<Renderer>().enabled = false;
		}


		if(isUpdate)
		{
			float x1 = 0.0f;float x2 = 0, x3 = 0, x4 = 0, y1 = 0, y2 = 0, y3 = 0, y4 = 0;

			//if (isTouchActive)
			{
				try {
//					Debug.Log ("22222222222");
//					
//					if (UIPropetyPanel.rect_x1.Equals ("") == false || UIPropetyPanel.rect_x2.Equals ("") == false || 
//					    UIPropetyPanel.rect_x3.Equals ("") == false || UIPropetyPanel.rect_x4.Equals ("") == false ||
//					    UIPropetyPanel.rect_y1.Equals ("") == false || UIPropetyPanel.rect_y2.Equals ("") == false || 
//					    UIPropetyPanel.rect_y3.Equals ("") == false || UIPropetyPanel.rect_y4.Equals ("") == false)
//					
//					{
//						spriteData.rect_x1 = UIPropetyPanel.rect_x1;
//						
//						spriteData.rect_x2 = UIPropetyPanel.rect_x2;
//						
//						spriteData.rect_x3 = UIPropetyPanel.rect_x3;
//						
//						spriteData.rect_x4 = UIPropetyPanel.rect_x4;
//						
//						
//						spriteData.rect_y1 = UIPropetyPanel.rect_y1;
//						
//						spriteData.rect_y2 = UIPropetyPanel.rect_y2;
//						
//						spriteData.rect_y3 = UIPropetyPanel.rect_y3;
//						
//						spriteData.rect_y4 = UIPropetyPanel.rect_y4;
//					}
				} catch (Exception e) {
//					;
					Debug.Log(e.ToString());
				}
			}
			
			try {
//				Debug.Log ("3333333333333");
				
				x1 = GameManager.coverScreenX2WorldPosX (int.Parse (spriteData.rect_x1));
				x2 = GameManager.coverScreenX2WorldPosX (int.Parse (spriteData.rect_x2));
				x3 = GameManager.coverScreenX2WorldPosX (int.Parse (spriteData.rect_x3));
				x4 = GameManager.coverScreenX2WorldPosX (int.Parse (spriteData.rect_x4));
				
				y1 = GameManager.coverScreenY2WorldPosY (int.Parse (spriteData.rect_y1));
				y2 = GameManager.coverScreenY2WorldPosY (int.Parse (spriteData.rect_y2));
				y3 = GameManager.coverScreenY2WorldPosY (int.Parse (spriteData.rect_y3));
				y4 = GameManager.coverScreenY2WorldPosY (int.Parse (spriteData.rect_y4));
				
			} catch (Exception e) {
				Debug.Log(e.ToString());

			}
			float z_order = 0.0f;
			Vector3 v0 = new Vector3 (x1 + transform.position.x + 1.5f, y1 + transform.position.y + 1.0f, z_order);
			Vector3 v1 = new Vector3 (x2 + transform.position.x + 1.5f, y2 + transform.position.y + 1.0f, z_order);
			Vector3 v00 = new Vector3 (x1 + transform.position.x + 1.5f, y1 + transform.position.y + 1.0f, z_order);
			Vector3 v11 = new Vector3 (x2 + transform.position.x + 1.5f, y2 + transform.position.y + 1.0f, z_order);
			Vector3 v2 = new Vector3 (x3 + transform.position.x + 1.5f, y3 + transform.position.y + 1.0f, z_order);
			Vector3 v111 = new Vector3 (x2 + transform.position.x + 1.5f, y2 + transform.position.y + 1.0f, z_order);
			Vector3 v22 = new Vector3 (x3 + transform.position.x + 1.5f, y3 + transform.position.y + 1.0f, z_order);
			Vector3 v3 = new Vector3 (x4 + transform.position.x + 1.5f, y4 + transform.position.y + 1.0f, z_order);
			Vector3 v222 = new Vector3 (x3 + transform.position.x + 1.5f, y3 + transform.position.y + 1.0f, z_order);
			Vector3 v33 = new Vector3 (x4 + transform.position.x + 1.5f, y4 + transform.position.y + 1.0f, z_order);
			Vector3 v4 = new Vector3 (x1 + transform.position.x + 1.5f, y1 + transform.position.y + 1.0f, z_order);
			
			lineRender.SetPosition (0, v0);
			lineRender.SetPosition (1, v1);
			lineRender.SetPosition (2, v00);
			lineRender.SetPosition (3, v11);
			lineRender.SetPosition (4, v2);
			lineRender.SetPosition (5, v111);
			lineRender.SetPosition (6, v22);
			lineRender.SetPosition (7, v3);
			lineRender.SetPosition (8, v222);
			lineRender.SetPosition (9, v33);
			lineRender.SetPosition (10, v4);
		}

	}


	public void refreshTextureWithBGName()
	{
//		Debug.Log (e);

		if(spriteData.class_type.Equals (UIPropetyPanel.CLASS_BG)==true&&
		   spriteData.bg_name.Equals("")==false)
		{
			{
				//			int path_name = int.Parse (spriteData.tag_id);
				
				//			Debug.Log(spriteData.tag_id);
				
				Texture textureNewRect = (Texture)Resources.Load (spriteData.bg_name);
				if(textureNewRect)
				{
				__spriteAction.transform.GetComponent<Renderer>().material.mainTexture = textureNewRect;

//				this.transform.renderer.material.mainTextureOffset =new Vector2(100,100);
				float value = 1;

				try{
					if(spriteData.bg_scale_x.Equals("")==false)
					{
						value = float.Parse(spriteData.bg_scale_x);
					}
				}catch(Exception e)
				{
					Debug.Log(e.ToString());
				}
//				if(value!=1&&value!=-1)
//				{
//					value=1;
//				}

				refreshTextureScale (value);
				}
			}
		}

		//		if (spriteData.tag_id. Equals ("")==false) 


	}


	public void refreshTextureWithTag()
	{
		float scaleValue = 1.0f;
		Texture textureNewRect;
		if (spriteData.class_type.Equals (UIPropetyPanel.CLASS_TRIGGER)) 
		{
						textureNewRect = (Texture)Resources.Load ("__trigger");
		}else if(spriteData.class_type.Equals(UIPropetyPanel.CLASS_MONSTER_AREA)){
			textureNewRect = (Texture)Resources.Load ("__monsterbuilder");
		}else if (spriteData.tag_id.Equals ("") == false ) {
//			int path_name = int.Parse (spriteData.tag_id);
//			Debug.Log(spriteData.tag_id);
			//monster
			if(spriteData.class_type.Equals(UIPropetyPanel.CLASS_SPRITE))
			{
				int tag_num =int.Parse(spriteData.tag_id);
				int id_number = tag_num/100000;
				if(id_number<11||id_number>14)
				{
					textureNewRect	= (Texture)Resources.Load (spriteData.tag_id);
				}else if(id_number == 11){
					textureNewRect	= (Texture)Resources.Load (""+(tag_num-1100000)/1000);
				}else{
					textureNewRect	= (Texture)Resources.Load (""+id_number*100);
				}

			}else{
				textureNewRect	= (Texture)Resources.Load (spriteData.tag_id);
			}


			if(spriteData.alert_x.Equals("") == false)
			{
			if(int.Parse( spriteData.alert_x)<0)
			{
			scaleValue = -1.0f;
			}
			}

		} else {
			textureNewRect = (Texture)Resources.Load ("__rect");

		}
		
		__spriteAction.transform.GetComponent<Renderer>().material.mainTexture = textureNewRect;
		
		refreshTextureScale (scaleValue);
	}

	public void refreshTextureScale0()
	{
		if (__spriteAction.GetComponent<Renderer>().material.mainTexture) 
		{
			__spriteAction.transform.localScale = new Vector3 (0, 0, 0);

		}
		if (this.GetComponent<Renderer>().material.mainTexture) 
		{
			this.transform.localScale = new Vector3 (0, 0, 0);
		}

	}


	public void refreshTextureScale (float value)
	{
		if (__spriteAction.GetComponent<Renderer>().material.mainTexture) 
		{
			float scaleValueX = __spriteAction.GetComponent<Renderer>().material.mainTexture.width / GameManager.scale_value_x;
		
			float scaleValueY = __spriteAction.GetComponent<Renderer>().material.mainTexture.height / GameManager.scale_value_y;
		
			__spriteAction.transform.localScale = new Vector3 (value*scaleValueX, 0.1f, scaleValueY);

		}

	}

	void init_warning_line()
	{
		alertLine = (SpriteAlertLine)Instantiate (alertLine,this.transform.position,this.transform.rotation);
	}

	void init_sprite_action()
	{
		__spriteAction = (SpriteAction)Instantiate (__spriteAction,this.transform.position,this.transform.rotation);
	}





	public class SpData
	{
		public string unique_id = "";

		public string class_type = "";

		public string tag_id = "";
	
		public string type = "";

		public string pos_x = "";
		
		public string pos_y = "";
		//
		public string display_x = "";
		
		public string display_y = "";
		
		public string wave_id = "";

		public string show_time = "";
		
		public string z_order = "";

		public string alert_x = "";

		public int script_id ;

		public string bg_name ;
		//@BG
		public string bg_scale_x ;

		public string rect_x1, rect_y1, rect_x2, rect_y2, rect_x3, rect_y3, rect_x4, rect_y4;

		public string create_inmap ;

		public string boss_dropped ;

		public string max_monster ;

//		public SpData()
//		{
//			//from 1 
//
//		}
		public void create_unique_id ()
		{
			if (unique_id.Equals (""))
			{
				int __uniqu_id = 1+10000;
				GameObject[] gos;

				gos = GameObject.FindGameObjectsWithTag ("ActionSprite");

				while(unique_id.Equals(""))
				{
					bool is_unique=true;
					foreach (GameObject go in gos)
					{
						ActionSprite sprite = go.GetComponent<ActionSprite> ();
						if (sprite) 
						{
							if(sprite.spriteData.unique_id.Equals("")==false)
							{
								int sprite_uniqu_id = int.Parse(sprite.spriteData.unique_id);
								if(sprite_uniqu_id == __uniqu_id)
								{
									is_unique=false;
									break;
								}
							}
						}
					}
					if(is_unique)
					{
						unique_id = ""+ (__uniqu_id);
					}else{
					__uniqu_id++;
					}
				}
			}
		}

		public void clone(SpData cloneA)
		{
//			this.unique_id = cloneA.unique_id;
			this.class_type = cloneA.class_type;
			this.tag_id = cloneA.tag_id;
			this.type = cloneA.type;
			this.pos_x = cloneA.pos_x;
			this.pos_y = cloneA.pos_y;
			this.wave_id = cloneA.wave_id;
			this.show_time = cloneA.show_time;
			this.z_order = cloneA.z_order;
			this.alert_x = cloneA.alert_x;
			this.script_id = cloneA.script_id;
			this.bg_name = cloneA.bg_name;
			this.bg_scale_x = cloneA.bg_scale_x;
			this.rect_x1 = cloneA.rect_x1;
			this.rect_x2 = cloneA.rect_x2;
			this.rect_x3 = cloneA.rect_x3;
			this.rect_x4 = cloneA.rect_x4;
			this.rect_y1 = cloneA.rect_y1;
			this.rect_y2 = cloneA.rect_y2;
			this.rect_y3 = cloneA.rect_y3;
			this.rect_y4 = cloneA.rect_y4;

			this.display_x = cloneA.display_x;
			this.display_y = cloneA.display_y;

			this.create_inmap = cloneA.create_inmap;
			this.boss_dropped = cloneA.boss_dropped;
			this.max_monster = cloneA.max_monster;
		}

	}


	public void updatePropetyToGUI()
	{
		spriteData.pos_x = GameManager.coverWorldPosXToScreenX(this.transform.position.x).ToString();
		
		spriteData.pos_y = GameManager.coverWorldPosYToScreenY(this.transform.position.y).ToString();

		UIPropetyPanel.text_unique_id = spriteData.unique_id;

		UIPropetyPanel.text_class_type = spriteData.class_type;

		if (UIPropetyPanel.text_class_type.Equals(UIPropetyPanel.CLASS_SPRITE)) 
		{
			UIPropetyPanel.selectedSpriteIndex___ = 0;
		}else if (UIPropetyPanel.text_class_type.Equals(UIPropetyPanel.CLASS_TRIGGER))
		{
			UIPropetyPanel.selectedSpriteIndex___ = 1;
		}else if (UIPropetyPanel.text_class_type.Equals(UIPropetyPanel.CLASS_BG))
		{
			UIPropetyPanel.selectedSpriteIndex___ = 2;
		}else if (UIPropetyPanel.text_class_type.Equals(UIPropetyPanel.CLASS_RECT))
		{
			UIPropetyPanel.selectedSpriteIndex___ = 3;
		}else if (UIPropetyPanel.text_class_type.Equals(UIPropetyPanel.CLASS_MONSTER_AREA))
		{
			UIPropetyPanel.selectedSpriteIndex___ = 4;
		}


		UIPropetyPanel.text_tag = spriteData.tag_id;

		UIPropetyPanel.text_type = spriteData.type;

		UIPropetyPanel.text_posX = spriteData.pos_x;

		UIPropetyPanel.text_posY = spriteData.pos_y;
		
		UIPropetyPanel.text_wave = spriteData.wave_id;

		UIPropetyPanel.text_time = spriteData.show_time;

		UIPropetyPanel.text_z_order = spriteData.z_order;

		UIPropetyPanel.text_alert_x = spriteData.alert_x;

		UIPropetyPanel.text_script_id =""+ spriteData.script_id;

		UIPropetyPanel.text_bg_name =""+ spriteData.bg_name;

		UIPropetyPanel.text_bg_scale_x =""+ spriteData.bg_scale_x;

		UIPropetyPanel.text_create_inmap = spriteData.create_inmap;

		UIPropetyPanel.text_boss_dropped = spriteData.boss_dropped;

		UIPropetyPanel.text_max_monster = spriteData.max_monster;

		//TODO x,y
		UIPropetyPanel.rect_x1 = "" + spriteData.rect_x1;
		UIPropetyPanel.rect_x2 = "" + spriteData.rect_x2;
		UIPropetyPanel.rect_x3 = "" + spriteData.rect_x3;
		UIPropetyPanel.rect_x4 = "" + spriteData.rect_x4;
		
		UIPropetyPanel.rect_y1 = "" + spriteData.rect_y1;
		UIPropetyPanel.rect_y2 = "" + spriteData.rect_y2;
		UIPropetyPanel.rect_y3 = "" + spriteData.rect_y3;
		UIPropetyPanel.rect_y4 = "" + spriteData.rect_y4;


	}
	
	public void updateGUIToPropety()
	{
		spriteData.unique_id = UIPropetyPanel.text_unique_id;

		spriteData.class_type = UIPropetyPanel.text_class_type;

		spriteData.tag_id=UIPropetyPanel.text_tag;

		spriteData.type = UIPropetyPanel.text_type;

		spriteData.pos_x=UIPropetyPanel.text_posX;
		
		spriteData.pos_y=UIPropetyPanel.text_posY;
		
		spriteData.wave_id=UIPropetyPanel.text_wave;
		
		spriteData.show_time=UIPropetyPanel.text_time;

		spriteData.z_order=UIPropetyPanel.text_z_order;

		spriteData.alert_x=UIPropetyPanel.text_alert_x;

		spriteData.bg_scale_x=UIPropetyPanel.text_bg_scale_x;

		spriteData.create_inmap=UIPropetyPanel.text_create_inmap;

		spriteData.boss_dropped = UIPropetyPanel.text_boss_dropped;

		spriteData.max_monster = UIPropetyPanel.text_max_monster;

		spriteData.rect_x1 = UIPropetyPanel.rect_x1;
		spriteData.rect_x2 = UIPropetyPanel.rect_x2;
		spriteData.rect_x3 = UIPropetyPanel.rect_x3;
		spriteData.rect_x4 = UIPropetyPanel.rect_x4;
		
		spriteData.rect_y1 = UIPropetyPanel.rect_y1;
		spriteData.rect_y2 = UIPropetyPanel.rect_y2;
		spriteData.rect_y3 = UIPropetyPanel.rect_y3;
		spriteData.rect_y4 = UIPropetyPanel.rect_y4;

		try{
		spriteData.script_id=int.Parse( UIPropetyPanel.text_script_id);
		}catch(Exception e)
		{
			Debug.Log(e.ToString());

		}
		if(spriteData.z_order.Equals("")==false)
			
		spriteData.bg_name=UIPropetyPanel.text_bg_name ;



//		UIPropetyPanel.text_bg_name =""+ spriteData.bg_name;
	}


//	int tag = 0;

//	public Transform m_sprite;

	float ticketTime;




	// Update is called once per frame
	void Update () {
		update_draw_show_time ();

		update_line_render ();

		spriteData.display_x = this.transform.position.x.ToString();

		spriteData.display_y = this.transform.position.y.ToString();


		//fixed position to pixel
		ticketTime+=Time.deltaTime;

//		if (ticketTime > 3.0) 
//		{
//						ticketTime=0.0f;
//
//						Vector3 vectorT22 = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
//		
//			float pos_fixedX = GameManager.coverWorldPosXToScreenX (float.Parse (spriteData.display_x));
//		
//			float pos_fixedY = GameManager.coverWorldPosYToScreenY (float.Parse (spriteData.display_y));
//		
//						this.transform.position = vectorT22;
//		}
		//fixed position to pixel


		float alert_x = 0;

		if (spriteData.alert_x.Equals ("")==false) 
		{
			bool parse_faild=false;
			try{
				alert_x = int.Parse (spriteData.alert_x);

			}catch(Exception ex)
			{
				Debug.LogWarning("monster alert_x formation"+ex);
				parse_faild=true;
			}

			if(parse_faild==false)
			{
//				Debug.Log("UpdateUpdateUpdate");

//				Debug.Log(alert_x);

				alert_x = alert_x*10 / GameManager.scale_value_x;

//				Debug.Log(alert_x);

			}

		}

		Vector3 vector = new Vector3( this.transform.position.x + alert_x,this.transform.position.y,this.transform.position.z ) ;

		alertLine.transform.position = vector;

		MeshRenderer meshRender = alertLine.GetComponent<MeshRenderer>();

		if (spriteData.alert_x.Equals ("")) {
			meshRender.enabled = false;
		} else {
			meshRender.enabled=true;
		}



		float z_order = 0;
		
		try{
			if(spriteData.z_order.Equals("")==false)
			z_order = int.Parse(spriteData.z_order);
		}catch(Exception e)
		{
			Debug.Log(e.ToString());
		}
		
		if (spriteData.class_type.Equals (UIPropetyPanel.CLASS_SPRITE) == true)
		{
			if(isTouchActive)
			z_order=3.5f;
			else
			z_order=3.2f;

		}else if (spriteData.class_type.Equals (UIPropetyPanel.CLASS_BG) == true
		          ||spriteData.class_type.Equals (UIPropetyPanel.CLASS_TRIGGER) == true
		          ||spriteData.class_type.Equals (UIPropetyPanel.CLASS_RECT) == true
		          ||spriteData.class_type.Equals (UIPropetyPanel.CLASS_MONSTER_AREA) == true
		          )
		{
			int zzz=0;
			try{
			zzz =int.Parse( spriteData.z_order);
			}catch(Exception e)
			{
//				Debug.Log(e.ToString());
			}

			float z_z = zzz/100.0f;

			z_order=-1f - z_z;

			if(UIPropetyPanel.text_show_all_bg==false)
			{
				int z_orderZZ=0;
				try{
					z_orderZZ = int.Parse( spriteData.z_order);
				}catch(Exception e)
				{
					Debug.Log(e);
				}

				int bg_zorders= (int)UIPropetyPanel.show_bg_zorder_id;

				if((bg_zorders!=0&&z_orderZZ/10==bg_zorders))
				{
					z_order +=4.0f;
				}

//				UIPropetyPanel.text_
			
			}

		}
		
		//			z_order = z_order/400;
		
		Vector3 vectorT = new Vector3( this.transform.position.x,this.transform.position.y, -z_order) ;
		
		this.transform.position = vectorT;

//		float scaleValueX = this.renderer.material.mainTexture.width / GameManager.scale_value_x;
//		
//		float scaleValueY = this.renderer.material.mainTexture.height / GameManager.scale_value_y;

//		float x_value = 0.1f;//  this.renderer.material.mainTexture.width / GameManager.scale_value_x ;//GameManager.coverScreenX2WorldPosX ( (int)(spriteAction.renderer.material.mainTexture.width) );
//
//		float y_value = 0.2f;
//		float scaleValueX = this.renderer.material.mainTexture.width / GameManager.scale_value_x;



		if (__spriteAction&&__spriteAction.GetComponent<Renderer>()&&__spriteAction.GetComponent<Renderer>().material&&__spriteAction.GetComponent<Renderer>().material.mainTexture)
		{
			float x_value =  (__spriteAction.GetComponent<Renderer>().material.mainTexture.width)*10/ GameManager.scale_value_x;//GameManager.coverScreenX2WorldPosX ((int)(spriteAction.renderer.material.mainTexture.width));
		
			float y_value =  (__spriteAction.GetComponent<Renderer>().material.mainTexture.height)*10/ GameManager.scale_value_y;//GameManager.coverScreenX2WorldPosX ((int)(spriteAction.renderer.material.mainTexture.width));

			Vector3 vectorT2 = new Vector3 (this.transform.position.x + x_value/2, this.transform.position.y + y_value/2 , -z_order);

			__spriteAction.transform.position = vectorT2;
		
		}


	}
	
	
	//	return ((int)(( transform.position.y )*960*2/3 +640)/2);

	Vector3 curobjPos, curmousePos, mousePosfirst, objPosfirst, differencePos;
	
	Vector3 curScreenSpace;
	
	Vector3 curPosition;

//	IEnumerator OnMouseOver()
//	{
//		/*三维物体坐标转屏幕坐标*/
//		curScreenSpace =Camera.main.WorldToScreenPoint (transform.position);
//		/*将鼠标屏幕坐标转为三维坐标，再算出物体位置与鼠标之间的距离*/
//		curPosition = transform.position - Camera.main.ScreenToWorldPoint(new Vector3
//		                                                                  (Input.mousePosition.x, Input.mousePosition.y, curScreenSpace.z));
//		curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, curScreenSpace.z);
//		transform.position = Camera.main.ScreenToWorldPoint(curScreenSpace) + curPosition;
//		
//		Vector3 posttt = Camera.main.ScreenToViewportPoint(curScreenSpace) ;
//		
//		float pos_mouse_x = GameManager.coverWorldPosXToScreenX(this.transform.position.x);
//		
//		float pos_mouse_y = GameManager.coverWorldPosYToScreenY(this.transform.position.y);
//
//		Debug.Log ("pos_mouse_x"+pos_mouse_x+"pos_mouse_y"+pos_mouse_y);
//
//		yield return 0; //这个很重要，循环执行
//
//	}


	IEnumerator OnMouseDown()
	{
//		is_visible_var = true;

//		Debug.Log(m_sprite.position);
		if (isTouchActive == true) 
		{

		
						/*三维物体坐标转屏幕坐标*/
						curScreenSpace = Camera.main.WorldToScreenPoint (transform.position);
						/*将鼠标屏幕坐标转为三维坐标，再算出物体位置与鼠标之间的距离*/
						curPosition = transform.position - Camera.main.ScreenToWorldPoint (new Vector3
		                                                                          (Input.mousePosition.x, Input.mousePosition.y, curScreenSpace.z));
	
						setMonsterVisible (false);
						//cur propety update to ->GUI
						updatePropetyToGUI ();


//		Debug.Log("Input.mousePosition!");

//		Debug.Log(Input.mousePosition);
//
//		Debug.Log(transform.position);

//		Debug.Log(pos_y);

//		Debug.Log("OnMouseDown Done!");
//		if (Input.GetMouseButton(0))              
//		{                   
//			
//			Debug.Log("世界坐标" + this.transform.position);                    
//			
////			Debug.Log("屏幕坐标" + Input.GetTouch(0).position);                    
//			
//			Debug.Log("世界坐标→屏幕坐标" + camera.WorldToScreenPoint(this.transform.position));                    
//			
////			Debug.Log("屏幕坐标→视口坐标" + camera.ScreenToViewportPoint(Input.GetTouch(0).position));                   
//			
//			Debug.Log("世界坐标→视口坐标" + camera.WorldToViewportPoint(this.transform.position));               
//			
//		}

						//print("undown");
			while (Input.GetMouseButton(0)) { //单击鼠标左键



								curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, curScreenSpace.z);
								transform.position = Camera.main.ScreenToWorldPoint (curScreenSpace) + curPosition;

//			Vector3 posttt = Camera.main.ScreenToViewportPoint(curScreenSpace) ;

//			GameManager.text_x = ( transform.position.x ).ToString();
//			GameManager.text_y = ( transform.position.z ).ToString();
			
//			pos_x = (int)( Input.mousePosition.x) + Camera.main.transform.position.x;
//			
//			pos_y = (int)( Input.mousePosition.y) + Camera.main.transform.position.y;

//			pos_x = Camera.main.transform.position.x;
//			
//			pos_y = Camera.main.transform.position.y;
//			Debug.Log("OnMouseRepeated !");

								spriteData.pos_x = GameManager.coverWorldPosXToScreenX (this.transform.position.x).ToString ();

								spriteData.pos_y = GameManager.coverWorldPosYToScreenY (this.transform.position.y).ToString ();

//			spriteData.pos_x = getScreenPosX().ToString();
//
//			spriteData.pos_y = getScreenPosY().ToString();




								updatePropetyToGUI ();

								yield return 0; //这个很重要，循环执行
						}

//		while (Input.GetMouseButton(1)) //单击鼠标左键
//		{
//
//		}

		} else {
			yield return 1;
		}
				
	}


	void OnDrawGizmos()
	{
//		Gizmos.DrawIcon
//		Debug.Log ("ffffffff");

//		Gizmos.color=new Color(1,0,0,5);    //    在变换位置处绘制一个变透明的蓝色立方体
//		Gizmos.DrawCube(transform.position,new Vector3(1,1,1));

		Gizmos.color = Color.blue;   //从transform到target绘制一条蓝色的线

		Gizmos.DrawLine(transform.position ,new Vector3(transform.position.x+1.0f,transform.position.y+1.0f,transform.position.z) );

//		Gizmos.DrawIcon(new Vector3(transform.position.x,transform.position.y,transform.position.z - 0.5f) ,"rect.png",true);

	}

//	public int toolbarInt = 0;

	void setMonsterVisible(bool isVisible)
	{
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
//
//		isTouchPressed = true;

		GameManager.setSelectedActionSprite (this);
	}


}






