using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuExit : MonoBehaviour {




	//hàm dùng để exit game khi nhấn nút exit ở mainmenu
	public void ExitGame()
	{
		//nếu đang chạy trên unity editor thì thoát khỏi playmode
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else //nếu đang chạy trên phone thì thoát game
		Application.Quit ();
		#endif
		
	}
}
