using UnityEngine;
using System.Collections;
//using UnityEditor;

public class DrawRect : MonoBehaviour {
//	Texture2D texture = null;
//	public static string text_mouse_x = "";
//	
//	public static string text_mouse_y = "";

	void Start () {
//		Material mat = new Material (Shader.Find ("path"));
//		texture = (Texture2D)AssetDatabase.LoadAssetAtPath ("path/a.png", typeof(Texture2D));
//		mat.mainTexture = texture;
//		AssetDatabase.CreateAsset (mat, "Asset/mat.mat");

		GameObject objCube = GameObject.CreatePrimitive (PrimitiveType.Cube);
//		MeshCollider mesh1 = objCube.GetComponents<MeshCollider>;
//		objCube.AddComponent ("Handle the mouse effect");

		CreateRect ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown()
	{

	}

	void OnMouseUp()
	{

	}

	public Transform obj_rect;
	void CreateRect()
	{
		int scene_x = GameManager.coverWorldPosXToScreenX (Camera.main.transform.position.x)-480;
		
		int scene_y = GameManager.coverWorldPosYToScreenY (Camera.main.transform.position.y)-320;
		
		int pos_x = (int)((int)Input.mousePosition.x + scene_x);
		
		int pos_y = (int)((int)Input.mousePosition.y + scene_y);

		UIPropetyPanel.text_mouse_x =pos_x.ToString();
		
		UIPropetyPanel.text_mouse_y = pos_y.ToString();

//		if (Input.GetMouseButtonDown (0)) {
//			obj_rect = Instantiate(obj_rect, this.transform.position,this.transform.rotation);
//	    }
	}

}
