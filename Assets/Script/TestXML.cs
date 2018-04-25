
/* Unity3D读取保存XML文件
　　代码已测试，无误。就一个脚本(C#版)。
　　运行时会首先执行FirstSave()函数，该函数的作用是初始化XML里的内容，如果该XMl不存在，则会自动创建并初始化。
　　
　　按下save按钮后执行Save()函数会把数据保存到指定的XMl里
　　
　　按下load按钮后会执行Load()函数把你保存在XML里的数据读取出来
　　
　　导出exe后XML文件会保存在Data文件夹里，修改XML里面的数据，运行，你会发现读取的数据是你刚刚修改过的数据。
　　　　
　　可以保存和读取的数据类型支持英文、中文、浮点型、整型 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;


public class TestXML: MonoBehaviour
{
	private string c1;
	private string c2;
	private float c3;
	private int c4;

	private string _FileLocation;

	static public string test_level_name_xml= "level-10001.xml";

//	static public string test_level_name_map= "level-10001.map";
//
//	static public string test_level_name_sp= "level-10001.sp";

	static public string test_level_name_map= "level-50002";

	static public string mapmap = ".map";

	static public string test_level_name_sp= "";
	static public string spritesp = ".sp";

	//	LevelInfo[] myData = new LevelInfo[10];

	//	private LevelInfo tempSpriteInfo = null;
	
//	int i = 0;
	public class LevelInfo
	{
		public int level_id ;
//		public int max_wave ;
		public ActionSprite.SpData[] SpriteArray = null;

		public WaveSprite.WaveData[] WaveArray = null;


	}
	
	void Awake()
	{//找到路径
		_FileLocation = Application.dataPath;
	}
	
	void Start()
	{
//	
	}
	/*
	void FirstSave()
	{//初始化XML
		tempData._iUser.Ceshi1 = "?";
		tempData._iUser.Ceshi2 = "?";
		tempData._iUser.Ceshi3 = 0;
		tempData._iUser.Ceshi4 = 0;
		StreamWriter writer;
		FileInfo t = new FileInfo(_FileLocation + "/" + test_level_name);
		if (!t.Exists)
		{
			writer = t.CreateText();
			_data = SerializeObject(tempData);
			for (i = 0; i < 10; i++)
			{
				writer.WriteLine(_data);
			}
			writer.Close();
		}
	}
	*/

	public void Save(string sc1, string sc2, float sc3, int sc4)
	{//保存数据到指定的XMl里
		Debug.Log ("Save File:");

		LevelInfo levelInfo = new LevelInfo();

		if( UIPropetyPanel.text_level_id.Equals(""))
		{
			Debug.LogError ("UIPropetyPanel.text_level_id:"+ UIPropetyPanel.text_level_id);
		}

		levelInfo.level_id = int.Parse( UIPropetyPanel.text_level_id);

//		if( UIPropetyPanel.text_level_max_wave.Equals(""))
//		{
//			Debug.LogError ("UIPropetyPanel.text_level_max_wave:"+ UIPropetyPanel.text_level_max_wave);
//		}
//		levelInfo.max_wave = int.Parse( UIPropetyPanel.text_level_max_wave);

		GameObject[] objects;
		
		objects = GameObject.FindGameObjectsWithTag("ActionSprite");

		levelInfo.SpriteArray=new ActionSprite.SpData[objects.Length];

		int m = 0;
		foreach (GameObject obj in objects)
		{
			ActionSprite sprite = obj.GetComponent<ActionSprite> ();
			if(sprite)
			{
				//modify final save the pos2D
//				sprite.spriteData.pos_x = GameManager.coverWorldPosXToScreenX(float.Parse(sprite.spriteData.display_x)).ToString();
//
//				sprite.spriteData.pos_y = GameManager.coverWorldPosYToScreenY(float.Parse(sprite.spriteData.display_y)).ToString();

				if(int.Parse( sprite.spriteData.unique_id)==10275)
				{
//				sprite.spriteData.display_x = GameManager.fixedWorldPosX(float.Parse(sprite.spriteData.pos_x)).ToString();
//				
//				sprite.spriteData.display_y = GameManager.fixedWorldPosY(float.Parse(sprite.spriteData.pos_y)).ToString();

					string pos_fixedX = GameManager.coverWorldPosXToScreenX (float.Parse (sprite.spriteData.display_x)).ToString();

					string pos_fixedY = GameManager.coverWorldPosYToScreenY (float.Parse (sprite.spriteData.display_y)).ToString();

					sprite.spriteData.pos_x = pos_fixedX;

					sprite.spriteData.pos_y = pos_fixedY;

				}


				levelInfo.SpriteArray[m] = sprite.spriteData;

				m++;
			}

		}

		GameObject[] objects2;
		
		objects2 = GameObject.FindGameObjectsWithTag("FebWaveSprite");

		levelInfo.WaveArray=new WaveSprite.WaveData[objects2.Length];

		int k = 0;

		foreach (GameObject obj in objects2)
		{
			WaveSprite sprite = obj.GetComponent<WaveSprite> ();
			
			if(sprite&&sprite.name.Equals("")==false)
			{
				sprite.spriteData.wave_id = sprite.name;

				levelInfo.WaveArray[k] = sprite.spriteData;

//				Debug.Log("GameObject:");

//				Debug.Log(sprite.spriteData);

				if(levelInfo.WaveArray[k].wave_x2.Equals(""))
				{
//					Debug.LogError("waveIndex:"+k+" wave_x2:"+"no VALUE");
					Debug.Log("waveIndex:"+k+" wave_x2:"+"no VALUE");
//					OnGUI();
				}
				k++;
			}	
		}


		StreamWriter writer;
		FileInfo t = new FileInfo(_FileLocation + "/" + test_level_name_xml);
		t.Delete();
		writer = t.CreateText();
		string _data;

		_data = SerializeObject(levelInfo);

		writer.WriteLine(_data);

		writer.Close();

		Debug.Log ("levelInfo.WaveArray:length "+levelInfo.WaveArray.Length);

		Debug.Log ("Save End");

	}

	public void Addmap()
	{
		GameObject gameObject = GameObject.FindWithTag ("MainCamera");

		GameManager gameManager = gameObject.GetComponent<GameManager>();

//		gameManager.deleteWaveSprite ();

		//读取保存在XML里的数据
		StreamReader r = File.OpenText(_FileLocation + "/" + test_level_name_map + mapmap);	//map
		string _info;
		string _data;

		LevelInfo levelInfo = new LevelInfo();
		{
			_info = r.ReadLine();
			_data = _info;
			levelInfo = (LevelInfo)DeserializeObject(_data);
		}

		int length = levelInfo.SpriteArray.Length;

		if (test_level_name_sp.Equals ("") == false) {
						StreamReader r2 = File.OpenText (_FileLocation + "/" + test_level_name_sp + spritesp);//Sprite
						string _info2;
						string _data2;

						LevelInfo levelInfo2 = new LevelInfo ();
						{
								_info2 = r2.ReadLine ();
								_data2 = _info2;
								levelInfo2 = (LevelInfo)DeserializeObject (_data2);
						}
			
						int length2 = levelInfo2.SpriteArray.Length;


						for (int i = 0; i < length; i++) 
						{				
							ActionSprite.SpData sp = levelInfo.SpriteArray [i];
				
							for (int j = 0; j < length2; j++) 
							{
									ActionSprite.SpData sp2 = levelInfo2.SpriteArray [j];

								if (sp.unique_id != null) 
								{
									if (sp.unique_id.Equals(sp2.unique_id)) 
									{
										sp.unique_id = "";
										sp.create_unique_id();
										gameManager.create_sprite (sp);

									}
								}
									
							}
						}
						
				}
				else 
				{
					for (int i=0; i<length; i++) 
					{
						ActionSprite.SpData sp = levelInfo.SpriteArray[i];
						
						if(sp!=null //&& gameManager.isUnique(sp.unique_id)
				   )
						{
							gameManager.create_sprite(sp);
						}
						
					}	
				}

		int wave_length = levelInfo.WaveArray.Length;

		UIPropetyPanel.text_level_id = levelInfo.level_id.ToString ();

		UIPropetyPanel.text_level_max_wave = levelInfo.WaveArray.Length.ToString();

//		UIPropetyPanel.text_level_max_wave = levelInfo.max_wave.ToString ();

		int max_wave = int.Parse (UIPropetyPanel.text_level_max_wave);

		int name_tag=0;

		for (int i=0; i<max_wave; i++) 
		{
			name_tag++;

			WaveSprite.WaveData sp = levelInfo.WaveArray[i];

			gameManager.create_waveSprite(sp,name_tag);
		}

		r.Close();
	}

	public void LoadSprite()
	{
		GameObject gameObject = GameObject.FindWithTag ("MainCamera");
		
		GameManager gameManager = gameObject.GetComponent<GameManager>();
		
		//		gameManager.deleteWaveSprite ();
		
		//读取保存在XML里的数据
		StreamReader r = File.OpenText(_FileLocation + "/" + test_level_name_sp + spritesp);//Sprite
		string _info;
		string _data;
		
		LevelInfo levelInfo = new LevelInfo();
		{
			_info = r.ReadLine();
			_data = _info;
			levelInfo = (LevelInfo)DeserializeObject(_data);
		}
		
		int length = levelInfo.SpriteArray.Length;


		if (test_level_name_map.Equals("") == false) {
						StreamReader r2 = File.OpenText (_FileLocation + "/" + test_level_name_map + mapmap);//map
						string _info2;
						string _data2;
			
						LevelInfo levelInfo2 = new LevelInfo ();
						{
								_info2 = r2.ReadLine ();
								_data2 = _info2;
								levelInfo2 = (LevelInfo)DeserializeObject (_data2);
						}
			
						int length2 = levelInfo2.SpriteArray.Length;
			
						for (int i = 0; i < length; i++) 
						{
							ActionSprite.SpData sp = levelInfo.SpriteArray [i];

							for (int j = 0; j < length2; j++) 
							{
								ActionSprite.SpData sp2 = levelInfo2.SpriteArray [j];

								if (sp.unique_id != null) 
								{
									if (sp.unique_id.Equals(sp2.unique_id)) 
									{
										sp.unique_id = "";

										sp.create_unique_id();

										gameManager.create_sprite (sp);


									}
								}
			
							}

						}
				}
				else 
				{
					for (int i=0; i<length; i++) 
					{
						ActionSprite.SpData sp = levelInfo.SpriteArray[i];
						//			sp.unique_id;
						
						if(sp!=null //&& gameManager.isUnique(sp.unique_id)

				   )
						{
							gameManager.create_sprite(sp);
						}
						
					}
			}
		int wave_length =levelInfo.SpriteArray.Length;
		
		UIPropetyPanel.text_level_id = levelInfo.level_id.ToString ();
		
		UIPropetyPanel.text_level_max_wave = wave_length.ToString ();
		
		int max_wave = int.Parse (UIPropetyPanel.text_level_max_wave);
		
		int name_tag=0;
		
		for (int i=0; i<max_wave; i++) 
		{
			name_tag++;
			
			WaveSprite.WaveData sp = levelInfo.WaveArray[i];
			
			gameManager.create_waveSprite(sp,name_tag);
		}
		
		r.Close();
	}

	public void Load()
	{
		GameObject gameObject = GameObject.FindWithTag ("MainCamera");
		
		GameManager gameManager = gameObject.GetComponent<GameManager>();
		
		//		gameManager.deleteWaveSprite ();
		
		//读取保存在XML里的数据
		StreamReader r = File.OpenText(_FileLocation + "/" + test_level_name_xml);
		string _info;
		string _data;
		
		LevelInfo levelInfo = new LevelInfo();
		{
			_info = r.ReadLine();
			_data = _info;
			levelInfo = (LevelInfo)DeserializeObject(_data);
		}
		
		int length = levelInfo.SpriteArray.Length;
		
		
		for (int i=0; i<length; i++) 
		{
			ActionSprite.SpData sp = levelInfo.SpriteArray[i];
			//			sp.unique_id;
			
			if(sp!=null //&& gameManager.isUnique(sp.unique_id)
			   )
			{
				gameManager.create_sprite(sp);
			}
			
		}
		int wave_length = levelInfo.WaveArray.Length;

		UIPropetyPanel.text_level_id = levelInfo.level_id.ToString ();
		
		UIPropetyPanel.text_level_max_wave = wave_length.ToString ();
		
		int max_wave = int.Parse (UIPropetyPanel.text_level_max_wave);
		
		int name_tag=0;
		
		for (int i=0; i<max_wave; i++) 
		{
			name_tag++;
			
			WaveSprite.WaveData sp = levelInfo.WaveArray[i];
			
			gameManager.create_waveSprite(sp,name_tag);
		}
		
		r.Close();
		
	}


	//================================================================================
	string UTF8ByteArrayToString(byte[] characters)
	{
		UTF8Encoding encoding = new UTF8Encoding();
		string constructedString = encoding.GetString(characters);
		return (constructedString);
	}
	
	//byte[] StringToUTF8ByteArray(string pXmlString)
	byte[] StringToUTF8ByteArray(string pXmlString)
	{
		UTF8Encoding encoding = new UTF8Encoding();
		byte[] byteArray = encoding.GetBytes(pXmlString);
		return byteArray;
	}
	
	// Here we serialize our SpriterData object of myData
	//string SerializeObject(object pObject)
	string SerializeObject(object pObject)
	{
		string XmlizedString = null;
		MemoryStream memoryStream = new MemoryStream();
		XmlSerializer xs = new XmlSerializer(typeof(LevelInfo));
		XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
		
		xs.Serialize(xmlTextWriter, pObject);
		memoryStream = (MemoryStream)xmlTextWriter.BaseStream; // (MemoryStream)
		XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
		return XmlizedString;
	}
	
	// Here we deserialize it back into its original form
	//object DeserializeObject(string pXmlizedString)
	object DeserializeObject(string pXmlizedString)
	{
		XmlSerializer xs = new XmlSerializer(typeof(LevelInfo));
		MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
		XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
		return xs.Deserialize(memoryStream);
	}


}


