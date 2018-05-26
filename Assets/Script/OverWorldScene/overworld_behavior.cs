using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class overworld_behavior : MonoBehaviour {
    public void GoToHell()
    {
        SceneManager.LoadScene("TurtorialScene");
    }
    public void GoToBattle()
    {
        LoaderBehaviour.SceneName = "BattleScene";
        SceneManager.LoadScene("LoadScreen");
    }
    public void GoToShop()
    {
        LoaderBehaviour.SceneName = "JournalScene";
        SceneManager.LoadScene("LoadScreen");
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
