﻿using System.Collections;
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
        SceneManager.LoadScene("OverWorldMapScene", LoadSceneMode.Single);
    }

    public void GotoOverWorld()
    {
        SceneManager.LoadScene("OverWorldMapScene", LoadSceneMode.Single);
    }
}
