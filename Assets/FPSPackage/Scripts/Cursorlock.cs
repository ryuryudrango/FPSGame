using UnityEngine;
using System.Collections;

public class Cursorlock : MonoBehaviour {

    private void Awake()
    {
		
	}
    // Use this for initialization
    void Start () {
		// マウスカーソルを画面内にロックする。
		//Screen.lockCursor = true;
		Debug.Log(Cursor.visible);
		Cursor.lockState = CursorLockMode.Locked;
		// マウスカーソルを消去する
		Cursor.visible = false;
		Debug.Log(Cursor.visible);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// ダメージを与えられた時、カメラを揺らす
	void Damage(){
		transform.Find ("MainCamera").SendMessage ("Shake");
	}
}
