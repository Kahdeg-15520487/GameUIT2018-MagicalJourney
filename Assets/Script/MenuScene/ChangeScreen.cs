using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GotoBatleScreen()
    {
        LoaderBehaviour.SceneName = "OverWorldMapScene";
        SceneManager.LoadScene("LoadScreen");
    }

    public void GotoOverWorld()
    {
        LoaderBehaviour.SceneName = "OverWorldMapScene";
        SceneManager.LoadScene("LoadScreen");
    }
}
