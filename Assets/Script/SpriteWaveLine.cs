using UnityEngine;
using System.Collections;

public class SpriteWaveLine : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.tag = "WaveLine";

		float scaleValueX = this.GetComponent<Renderer>().material.mainTexture.width/GameManager.scale_value_x;
		
		float scaleValueY = this.GetComponent<Renderer>().material.mainTexture.height/GameManager.scale_value_y;
		
		this.transform.localScale = new Vector3 (scaleValueX,0.1f,scaleValueY);


	}
	
	// Update is called once per frame
//	void Update () {
//
//	}

	Vector3 curScreenSpace;
	
	Vector3 curPosition;
	
//	IEnumerator OnMouseDown()
//	{
//
//		GameManager.is_visible_var = true;
//		
//		//		Debug.Log(m_sprite.position);
//		
//		/*三维物体坐标转屏幕坐标*/
//		curScreenSpace =Camera.main.WorldToScreenPoint (transform.position);
//		/*将鼠标屏幕坐标转为三维坐标，再算出物体位置与鼠标之间的距离*/
//		curPosition = transform.position - Camera.main.ScreenToWorldPoint(new Vector3
//		                                                                  (Input.mousePosition.x,Input.mousePosition.y, curScreenSpace.z));
//		
//
//
////		Debug.Log("Input.mousePosition!");
//		
//		//		Debug.Log(Input.mousePosition);
//		//
//		//		Debug.Log(transform.position);
//
////		Debug.Log(pos_y);                                                                        
//		
////		Debug.Log("OnMouseDown Done!");
//		
//		//print("undown");
//		while (Input.GetMouseButton(0)) //单击鼠标左键
//		{
//			
//			curScreenSpace = new Vector3(Input.mousePosition.x,Input.mousePosition.y, curScreenSpace.z);
//			transform.position = Camera.main.ScreenToWorldPoint(curScreenSpace) + curPosition;
//
//			Debug.Log(curScreenSpace);
//			Debug.Log(curPosition);
//
//			Vector3 vector = Camera.main.transform.position;
//
//			vector.x =Camera.main.transform.position.x+1.0f;
//
//			Camera.main.transform.position =curPosition;//(float)(Camera.main.transform.position.x + 1.0);// =  Camera.main.ScreenToWorldPoint(curScreenSpace) + curPosition;;
//
////			Vector3 posttt = Camera.main.ScreenToViewportPoint(curScreenSpace) ;
//			
//			//			GameManager.text_x = ( transform.position.x ).ToString();
//			//			GameManager.text_y = ( transform.position.z ).ToString();
//			
////			pos_x = (int)( Input.mousePosition.x);
////			
////			pos_y = (int)( Input.mousePosition.y);
////			
////			GameManager.text_x =  pos_x.ToString();
////			
////			GameManager.text_y =  pos_y.ToString();
//			
//			
//			yield return 0; //这个很重要，循环执行
//		}
//		
//		while (Input.GetMouseButton(1)) //单击鼠标左键
//		{
//			
//		}
//
//	}




}
