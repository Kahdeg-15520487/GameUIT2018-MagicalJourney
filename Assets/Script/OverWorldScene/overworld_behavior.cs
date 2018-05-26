using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class overworld_behavior : MonoBehaviour {
    public void GoToHell()
    {
        SceneManager.LoadScene("TurtorialScene", LoadSceneMode.Single);
    }
    public void GoToBattle()
    {
        SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
    }
    public void GoToShop()
    {
        SceneManager.LoadScene("JournalScene", LoadSceneMode.Single);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
