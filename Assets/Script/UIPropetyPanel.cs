			using UnityEngine;
			using System.Collections;
			using System;

			public class UIPropetyPanel : MonoBehaviour {
				
				public static string CLASS_SPRITE = "sprite";

				public static string CLASS_TRIGGER = "trigger";

				public static string CLASS_BG = "bg";

				public static string CLASS_RECT = "rect";

				public static string CLASS_MONSTER_AREA = "monster area";

				GameManager gameManager;

				TestXML testXML;
				
				public static string text_unique_id = "";

				public static string text_level_id = "1";

				public static string text_level_max_wave = "0";

				public static string text_class_type = "";
				
				public static string text_tag = "";

				public static string text_find = "";
				
				public static string text_type = "";
				
				public static string text_posX = "";
				
				public static string text_posY = "";
				
				public static string text_wave = "";
				
				public static string text_time = "";
				
				public static string text_z_order = "";
				
				public static string text_alert_x = "";

				public static string text_wave_x2 = "";
				
				public static string text_wave_next_time = "";

				public static string text_wave_bossing = "";

				public static string text_mouse_x = "";
				
				public static string text_mouse_y = "";

				public static string text_script_id;

				public static string text_bg_name;

				public static string text_bg_zorder = "";

				public static string text_bg_scale_x = "";

				public static string text_create_inmap = "";

				public static string text_boss_dropped = "";

				public static string text_max_monster = "";

				public static string text_nowWaveSpriteCount ="";
				//
				public static float show_bg_zorder_id=0;
				//显示所有背景图开关
				public static bool text_show_all_bg = true;

				private bool text_Hide = true;
				//TODO text_DrawRect
			//	private bool text_DrawRect = false;

				public static float show_sprite_wave_id=0f;
				
				public static float tmp_show_sprite_wave_id=0f;

				Rect tipsRect = new Rect(10,600,200,40);
				
				public string[] toolbarStrings = new string[] {};

				public string[] toolbarSpriteStrings = new string[] {};

				public static int selectedTabIndex=2;

				public static int selectedSpriteIndex___=0;

				public static string rect_x1="", rect_y1="", rect_x2="", rect_y2="", rect_x3="", rect_y3="", rect_x4="", rect_y4="";

				void Start ()
				{
					GameObject game = GameObject.FindGameObjectWithTag ("MainCamera");

					gameManager = game.GetComponent<GameManager> ();

					testXML = game.GetComponent<TestXML> ();
				}

				void Update () 
				{
					{
						updateShowWaveSprite(false);

						updateShowBgSprite();

						updateHideBgSprite();
					}
				}
				//TODO draw rect
			//	void  updatadrawRect()
			//	{
			//
			//	}
				//TODO Hide
				void updateHideBgSprite()
				{
					GameObject[] gos;
					
					gos = GameObject.FindGameObjectsWithTag ("ActionSprite");
					
					foreach (GameObject go in gos) {
						ActionSprite sprite = go.GetComponent<ActionSprite> ();
					
						//TODO Jack
							if(sprite && sprite.spriteData.class_type.Equals("bg")==true){
							if (text_Hide == false && text_show_all_bg == true) {
								MeshRenderer meshRender = sprite.GetComponent<MeshRenderer> ();
								meshRender.enabled = false;
								
								MeshRenderer meshRender2 = sprite.__spriteAction.GetComponent<MeshRenderer> ();
								meshRender2.enabled = true;
								
								sprite.isTouchActive = false;
								
							} 
							else if(text_Hide && text_show_all_bg == false){
								//Do Nothing
							}
							else if(text_Hide == false && text_show_all_bg == false && sprite.spriteData.class_type.Equals("bg")==true){
								MeshRenderer meshRender = sprite.GetComponent<MeshRenderer> ();
								meshRender.enabled = false;

								sprite.isTouchActive = false;
							}
							else{
								
								if(sprite){
									MeshRenderer meshRender = sprite.GetComponent<MeshRenderer> ();
									meshRender.enabled = true;
									
									MeshRenderer meshRender2 = sprite.__spriteAction.GetComponent<MeshRenderer> ();
									meshRender2.enabled = true;
									
									sprite.isTouchActive = true;
								}
							}
						}else{
							continue;
						}
					}

				}

				void updateShowBgSprite()
				{
					
					//		if (UIPropetyPanel.text != UIPropetyPanel.tmp_show_sprite_wave_id)
					{
						int __show_bg_zorder_id =	(int)show_bg_zorder_id;

						GameObject[] gos;

						gos = GameObject.FindGameObjectsWithTag("ActionSprite");

						foreach (GameObject go in gos) 
						{
							ActionSprite sprite = go.GetComponent<ActionSprite> ();
							if(sprite==false || sprite.spriteData.class_type.Equals("bg")==false)
								continue;

							if(text_show_all_bg==false&&sprite.spriteData.z_order.Equals("") == false)
							{
								int z_order =-1;
								try{
									z_order = int.Parse( sprite.spriteData.z_order);
								}catch(Exception e)
								{
									Debug.Log(e);
									continue;
								}

								if((__show_bg_zorder_id!=0&&z_order/10==__show_bg_zorder_id))
								{
									MeshRenderer meshRender = sprite.GetComponent<MeshRenderer>();
									meshRender.enabled=true;

									MeshRenderer meshRender2 = sprite.__spriteAction.GetComponent<MeshRenderer>();
									meshRender2.enabled=true;
									{
										sprite.isTouchActive=true;
									}
									
								}else{
									MeshRenderer meshRender = sprite.GetComponent<MeshRenderer>();
									meshRender.enabled=false;

									MeshRenderer meshRender2 = sprite.__spriteAction.GetComponent<MeshRenderer>();
									meshRender2.enabled=false;

									{
										sprite.isTouchActive=false;
									}
								}

							}else{
								MeshRenderer meshRender = sprite.GetComponent<MeshRenderer>();
								meshRender.enabled=true;

								MeshRenderer meshRender2 = sprite.__spriteAction.GetComponent<MeshRenderer>();
								meshRender2.enabled=true;

								{
									sprite.isTouchActive=true;
								}
							}
							
						}

						
					}

					
					//		Debug.Log("sprite2");

				}

				//切换wave显示不同波次
				void updateShowWaveSprite(bool isNeedRefresh)
				{
					if (UIPropetyPanel.show_sprite_wave_id != UIPropetyPanel.tmp_show_sprite_wave_id||isNeedRefresh)
					{
			//			WaveSprite sprite3=gameManager.getSelectedWaveSprite();
			//			
			//			if (sprite3)
			//			{
			//				sprite3.updateWavePropetyToGUI();
			//			}
						int nowWaveSpriteCount = 0;

						tmp_show_sprite_wave_id=show_sprite_wave_id;
						
						int show_wave_id = (int)show_sprite_wave_id;
						
						GameObject[] gos;
						
						gos = GameObject.FindGameObjectsWithTag("ActionSprite");
						
						foreach (GameObject go in gos) 
						{
							ActionSprite sprite = go.GetComponent<ActionSprite> ();
							
							if(sprite&&sprite.spriteData.wave_id.Equals("") == false)
							{
								int wave_id =-1;
								try{
									wave_id = int.Parse( sprite.spriteData.wave_id);
								}catch(Exception e)
								{
									Debug.LogError(e);
								}

								if(wave_id==show_wave_id ||show_wave_id == 0)
								{
									MeshRenderer meshRender = sprite.GetComponent<MeshRenderer>();
									meshRender.enabled=true;
									MeshRenderer meshRender2 = sprite.__spriteAction.GetComponent<MeshRenderer>();
									meshRender2.enabled = true;

									//if(sprite.spriteData.class_type.Equals(CLASS_SPRITE))
									{
									sprite.isTouchActive=true;
									}
									nowWaveSpriteCount++;
			//						float _z_order =-3.5f;
			//						Vector3 vectorT = new Vector3( sprite.transform.position.x,sprite.transform.position.y, _z_order) ;
			//						sprite.transform.position = vectorT;

								}else{
									MeshRenderer meshRender = sprite.GetComponent<MeshRenderer>();
									meshRender.enabled=false;
									MeshRenderer meshRender2 = sprite.__spriteAction.GetComponent<MeshRenderer>();
									meshRender2.enabled = false;

									if(sprite.spriteData.class_type.Equals(CLASS_SPRITE))
									{
										sprite.isTouchActive=false;
									}

									if(sprite.spriteData.class_type.Equals(CLASS_MONSTER_AREA))
									{
										sprite.isTouchActive=false;
									}

			//						float _z_order =-3.2f;
			//						Vector3 vectorT = new Vector3( sprite.transform.position.x,sprite.transform.position.y, _z_order) ;
			//						sprite.transform.position = vectorT;
								}
							}
							
						}

						WaveSprite sprite3=gameManager.getSelectedWaveSprite();
						
						if (sprite3)
						{
							sprite3.updateWavePropetyToGUI();
						}


						text_nowWaveSpriteCount =""+nowWaveSpriteCount;


					}

					//every frame to update
					WaveSprite sprite2=gameManager.getSelectedWaveSprite();
					
					if (sprite2)
					{
						sprite2.updateWaveGUIToPropety ();
					}

					//		Debug.Log("sprite2");

				

				}
				//TODO 1
			//	public ActionSprite.SpData spriteData = new ActionSprite.SpData ();
				void OnGUI()
				{
					if (GUI.Button (new Rect (250+120, 10, 100, 30),new GUIContent ("Delete", "Delete a sprite")))
					{
						gameManager.remove_sprite();
					}

					if (GUI.Button (new Rect (250+10, 10, 100, 30),new GUIContent ("Click Me", "Create a new sprite")))
					{
						gameManager.create_sprite ();
					}
					
					GUI.Label(tipsRect, GUI.tooltip);

					if (selectedTabIndex == 0) {
						//sprite
						onGUI_DrawSpritePropety ();
						
						onGUI_UpdateSpritePropety();

					} else if (selectedTabIndex == 1) {
						//wave
						onGUI_DrawWavePropety();

					} else {
						//level
						TestXML.test_level_name_xml = GUI.TextField (new Rect (10, 50, 100, 20), TestXML.test_level_name_xml, 15);

						if (GUI.Button(new Rect(115, 45, 50, 30), "save"))
						{

							testXML.Save("ceshi1", "测试2", 1.23f, 999);//要显示中文需设定中文字体
						}
						if (GUI.Button(new Rect(170, 45, 50, 30), "load"))
						{
							gameManager.ClearAllSpriteAndData();
							testXML.Load();
			//				ShowData = 1;
						}
						if(GUI.Button(new Rect(225, 45, 100, 30), "Delete map"))
						{
							//TODO Callback gameManager.remove_spriteBG()
							gameManager.deleteMap();
					
							Debug.Log("Delete the map");

						}
						TestXML.test_level_name_map = GUI.TextField (new Rect (330, 50, 100, 20), TestXML.test_level_name_map, 15);
						if(GUI.Button(new Rect(430, 45, 100, 30), "Add map"))
						{
							//TODO Callback gameManager.addmap()
							testXML.Addmap();
						}
						GUI.Label (new Rect (400, 50, 70, 30), ".map"); 

						TestXML.test_level_name_sp = GUI.TextField (new Rect (530, 50, 100, 20), TestXML.test_level_name_sp, 15);
						if(GUI.Button(new Rect(630, 45, 100, 30), "Add sprite"))
						{
							//TODO Callback gameManager.addmap()
							testXML.LoadSprite();
						}
						GUI.Label (new Rect (600, 50, 70, 30), ".sp"); 
						onGUI_DrawLevelPropety();

			//			Rect rect2 = new Rect (30, 10, 100, 30);

			//			show_level_propety = GUI.Toggle(rect2, show_level_propety, "on level");

					}

					selectedTabIndex = GUI.Toolbar(new Rect(5, 15, 250, 30), selectedTabIndex, toolbarStrings);

			//		selectedTabIndex = GUI.Toolbar(new Rect(10,10,200,30),selectedTabIndex,toolbarStrings);

					//		GUI.Label (new Rect (7, 45, 70, 20), verticalValue.ToString());  


					//fffff
					int scene_x = GameManager.coverWorldPosXToScreenX (Camera.main.transform.position.x)-480;
					
					int scene_y = GameManager.coverWorldPosYToScreenY (Camera.main.transform.position.y)-320;

					int pos_x = (int)((int)Input.mousePosition.x + scene_x);
					
					int pos_y = (int)((int)Input.mousePosition.y + scene_y);
					
					UIPropetyPanel.text_mouse_x =pos_x.ToString();
					
					UIPropetyPanel.text_mouse_y = pos_y.ToString();

					//mouse move position
					GUI.Label (new Rect (0 ,  0  , 80, 20), "("+text_mouse_x+","+text_mouse_y+")");  
					//TODO Rect
			//		GUI.Toggle(new Rect(500, 20, 100, 30), text_DrawRect, "DrawRect");
			//		 GUI.Label (new Rect (20, 0  , 10, 20), );  

				}

				public void onGUI_DrawWavePropety()
				{
					int x = 0;
					int y = 40;
					
					{
						GUI.Label (new Rect (x + 170, y+10, 300, 20), "wave_sprite_count:"+text_nowWaveSpriteCount);

						GUI.Label (new Rect (x + 10, y+10  , 110, 20), "show_wave_sprite:");

						int max_wave_count=0;

						try
						{
							max_wave_count=int.Parse( UIPropetyPanel.text_level_max_wave);// text_level_max_wave.tos
						}catch(Exception e)
						{
							Debug.Log(e);
							max_wave_count=100;
						}

						show_sprite_wave_id = GUI.HorizontalSlider(new Rect(x+10,y+40,20+max_wave_count*5,15),show_sprite_wave_id,0,max_wave_count);  
						int value = (int)show_sprite_wave_id;
						show_sprite_wave_id = value;

						string str  = GUI.TextField (new Rect (x+125, y+10, 30, 20),  show_sprite_wave_id.ToString(), 15);
						try{
							show_sprite_wave_id = float.Parse (str);
						}catch(Exception e)
						{
							Debug.Log(e);
						}

						if(value!=0)
						{
							GUI.Label (new Rect (x+10, y+65, 100, 20), "wave_x2:");  
							text_wave_x2  = GUI.TextField (new Rect (x+80, y+65, 40, 20),  text_wave_x2.ToString(), 15);
							
							GUI.Label (new Rect (x + 10, y+95  , 100, 20), "wave_time:");
							text_wave_next_time  = GUI.TextField (new Rect (x+80, y+95, 40, 20),  text_wave_next_time.ToString(), 15);

							GUI.Label (new Rect (x + 10, y+120  , 100, 20), "wave_bossing:");
							text_wave_bossing  = GUI.TextField (new Rect (x+120, y+120, 40, 20),  text_wave_bossing.ToString(), 15);


			//				WaveSprite sprite2=gameManager.getSelectedWaveSprite();
			//				
			//				if (sprite2)
			//				{
			//					sprite2.updateWaveGUIToPropety();
			//				}

						}

					}

				}


				public void onGUI_DrawLevelPropety()
				{
					int x = 0;
					int y = 120;
					
					{
			//			GUI.Label (new Rect (x + 7, y - 25, 70, 20), "level_id:");  
			//			
			//			text_level_id = GUI.TextField (new Rect (x + 70, y - 25, 50, 20), text_level_id, 15);

						GUI.Label (new Rect (x + 7, y +5, 70, 20), "max_wave:");  
						
						text_level_max_wave = GUI.TextField (new Rect (x + 90, y +5, 30, 20), text_level_max_wave, 15);

						if (GUI.Button (new Rect (x+125, y+10, 20, 15),new GUIContent ("O", "refresh new image")))
						{
							gameManager.refreshWaveSprite();
						}

						text_Hide = GUI.Toggle(new Rect(x+10, y+40, 100, 30), text_Hide, "HIDE BG");

						text_show_all_bg = GUI.Toggle(new Rect(x+10, y+60+20, 100, 30), text_show_all_bg, "show all bg");

						if(text_show_all_bg == false)
						{
						GUI.Label (new Rect(x+10,y+70+40,20+6*20,20), "show_bg_zorder:");  

						text_bg_zorder  = GUI.TextField (new Rect(x+110,y+70+40,20,20),  text_bg_zorder.ToString(), 15);

						show_bg_zorder_id = GUI.HorizontalSlider(new Rect(x+10,y+100+40,20+6*20,15),show_bg_zorder_id,0,6);  

						text_bg_zorder = ((int)(show_bg_zorder_id)).ToString();

						}

					}
					
				}


				public void onGUI_UpdateSpritePropety()
				{
					if (selectedSpriteIndex___ == 0) {
							text_class_type = CLASS_SPRITE;
					} else if (selectedSpriteIndex___ == 1) {
							text_class_type = CLASS_TRIGGER;
					} else if (selectedSpriteIndex___ == 2) {
							text_class_type = CLASS_BG;
					} else if (selectedSpriteIndex___ == 3) {
							text_class_type = CLASS_RECT;
					} else if (selectedSpriteIndex___ == 4) {
							text_class_type = CLASS_MONSTER_AREA;
					}
					
					ActionSprite sprite=gameManager.getSelectedActionSprite();

					bool is_x = true;
					bool is_y = true;
					int pos_x = 0;
					int pos_y =0;
					try{
					 pos_x =int.Parse(UIPropetyPanel.text_posX);
					} catch(Exception e)
					{
			//			Debug.Log(e.ToString());

						is_x=false;
					}
					try{
					 pos_y =int.Parse(UIPropetyPanel.text_posY);
					} catch(Exception e)
					{
						Debug.Log(e.ToString());

						is_y=false;
					}

					if (sprite&&is_x && is_y)
					{

						float tranform_posX = GameManager.coverScreenX2WorldPosX(pos_x);
						
						float tranform_posY = GameManager.coverScreenY2WorldPosY(pos_y);
						
						Vector3 vectorPos;
						
						vectorPos =new Vector3( tranform_posX, tranform_posY,0.6f);
						
						sprite.transform.position = vectorPos;
					
					}
					
					if (sprite) 
					{
						sprite.updateGUIToPropety ();
					}

				}
				
				public void onGUI_DrawSpritePropety()
				{

					selectedSpriteIndex___ = GUI.Toolbar(new Rect(5, 45, 550, 20), selectedSpriteIndex___, toolbarSpriteStrings);

					int x = 0;

					int y = 20;
				
					//copy me
					if (GUI.Button (new Rect (x+200, y+80, 80, 30),new GUIContent ("Copy2Next", "copy to next line")))
					{
						gameManager.Copy2Next();
					}

					{
					int __offsetY = 45;
					GUI.Label (new Rect (x+7, y+__offsetY, 70, 20), "unique_id:");  

					GUI.Label (new Rect (x+70, y+__offsetY, 70, 20), text_unique_id); 

					text_find = GUI.TextField (new Rect (x+170, y+__offsetY, 50, 20), text_find, 15);
					if(GUI.Button (new Rect (x+220, y+__offsetY, 50, 20),new GUIContent ("Find", "Find the property")))
						{
							//TODO Show all the Property
							Debug.Log("Show all the Property");
						}
					__offsetY+=30;
					GUI.Label (new Rect (x+7, y+__offsetY, 70, 20), "tag_id:");  
						
					text_tag = GUI.TextField (new Rect (x+70, y+__offsetY, 50, 20), text_tag, 15);
						
					if (GUI.Button (new Rect (x+120, y+__offsetY, 20, 15),new GUIContent ("O", "refresh new image")))
						{
							gameManager.refreshAllActionSpriteImage();
						}
						
						GUI.Label(tipsRect, GUI.tooltip);

					__offsetY+=30;
						//------------
					GUI.Label (new Rect (x+7, y+__offsetY, 70, 20), "type:");

					text_type = GUI.TextField (new Rect (x+70, y+__offsetY, 50, 20), text_type, 15);
						//------------
					__offsetY+=30;

					GUI.Label (new Rect (x+7, y+__offsetY, 70, 20), "pos_x:");
						
					text_posX = GUI.TextField (new Rect (x+70, y+__offsetY, 50, 20), text_posX, 15);
						
					__offsetY+=30;
					GUI.Label (new Rect (x+7, y+__offsetY, 70, 20), "pos_y:");
						
					text_posY = GUI.TextField (new Rect (x+70, y+__offsetY, 50, 20), text_posY, 15);
						
					__offsetY+=30;

					GUI.Label (new Rect (x+7, y+__offsetY, 70, 25), "wave_id:");
						try{
						text_wave = GUI.TextField (new Rect (x+70, y+__offsetY, 50, 20), text_wave, 15);
						}catch(Exception e)
						{

						}

					__offsetY+=30;
					GUI.Label (new Rect (x+7, y+__offsetY, 70, 25), "show_time:");
						
					text_time = GUI.TextField (new Rect (x+70, y+__offsetY, 50, 20), text_time, 15);	
						
					__offsetY+=30;
					GUI.Label (new Rect (x+7, y+__offsetY, 70, 20), "z_order:");
						
					text_z_order = GUI.TextField (new Rect (x+70, y+__offsetY, 50, 20), text_z_order, 15);

					__offsetY+=30;

					GUI.Label (new Rect (x+7, y+__offsetY, 70, 20), "alert_x:");

					text_alert_x = GUI.TextField (new Rect (x+70, y+__offsetY, 50, 20), text_alert_x, 15);

					__offsetY+=30;
					GUI.Label (new Rect (x+7, y+__offsetY, 70, 20), "script_id:");
						
					text_script_id = GUI.TextField (new Rect (x+70, y+__offsetY, 50, 20), ""+text_script_id, 15);

					__offsetY+=30;
					GUI.Label (new Rect (x+7, y+__offsetY, 70, 20), "bg_name:");
						
						text_bg_name = GUI.TextField (new Rect (x+70, y+__offsetY, 100, 20), ""+text_bg_name, 32);
					
					if (GUI.Button (new Rect (x+170, y+__offsetY, 20, 20),new GUIContent ("O", "refresh new image")))
						{
							gameManager.refreshMapSpriteImage();
						}

					__offsetY+=30;
					GUI.Label (new Rect (x+7, y+__offsetY, 70, 20), "bg_sacle_x:");
						
					text_bg_scale_x = GUI.TextField (new Rect (x+80, y+__offsetY, 20, 20), ""+text_bg_scale_x, 15);




					__offsetY+=30;
						//TODO x1,y1 to x4,y4
					GUI.Label (new Rect (x+7, y+__offsetY, 70, 20), "x1:");
					rect_x1 = GUI.TextField (new Rect (x+30, y+__offsetY, 50, 20), ""+rect_x1, 15);
						//			text_x1_id = int.Parse(text_x1);
					GUI.Label (new Rect (x+87, y+__offsetY, 70, 20), "y1:");
					rect_y1 = GUI.TextField (new Rect (x+110, y+__offsetY, 50, 20), ""+rect_y1, 15);
						//			text_y1_id = int.Parse(text_y1);
					
				__offsetY+=30;
					GUI.Label (new Rect (x+7, y+__offsetY, 70, 20), "x2:");
					rect_x2 = GUI.TextField (new Rect (x+30, y+__offsetY, 50, 20), ""+rect_x2, 15);
						//			text_x2_id = int.Parse(text_x2);
					GUI.Label (new Rect (x+87, y+__offsetY, 70, 20), "y2:");
					rect_y2 = GUI.TextField (new Rect (x+110, y+__offsetY, 50, 20), ""+rect_y2, 15);
						//			text_y2_id = int.Parse(text_y2);
					
				__offsetY+=30;
					GUI.Label (new Rect (x+7, y+__offsetY, 70, 20), "x3:");
					rect_x3 = GUI.TextField (new Rect (x+30, y+__offsetY, 50, 20), ""+rect_x3, 15);
						//			text_x3_id = int.Parse(text_x3);
					GUI.Label (new Rect (x+87, y+__offsetY, 70, 20), "y3:");
					rect_y3 = GUI.TextField (new Rect (x+110, y+__offsetY, 50, 20), ""+rect_y3, 15);
						//			text_y3_id = int.Parse(text_y3);
					
				__offsetY+=30;
					GUI.Label (new Rect (x+7, y+__offsetY, 70, 20), "x4:");
					rect_x4 = GUI.TextField (new Rect (x+30, y+__offsetY, 50, 20), ""+rect_x4, 15);
						//			text_x4_id = int.Parse(text_x4);
					GUI.Label (new Rect (x+87, y+__offsetY, 70, 20), "y4:");
					rect_y4 = GUI.TextField (new Rect (x+110, y+__offsetY, 50, 20), ""+rect_y4, 15);
					
				__offsetY+=30;
					GUI.Label (new Rect (x+5, y+__offsetY, 120, 20), "create_inmap:");
						
					text_create_inmap = GUI.TextField (new Rect (x+95, y+__offsetY, 20, 20),""+ text_create_inmap, 15);	
					
				__offsetY+=30;
					GUI.Label (new Rect (x+5, y+__offsetY, 120, 20), "boss_dropped:");
					
					text_boss_dropped = GUI.TextField (new Rect (x+95, y+__offsetY, 20, 20),""+ text_boss_dropped, 15);	
					
				__offsetY+=30;
					GUI.Label (new Rect (x+5, y+__offsetY, 120, 20), "max_monster:");
					
					text_max_monster = GUI.TextField (new Rect (x+95, y+__offsetY, 35, 20),""+ text_max_monster, 15);	
					
				

					}
					
				}



			}
