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
        SceneManager.LoadScene("BattleScene");
    }
    public void GoToShop()
    {
        SceneManager.LoadScene("JournalScene");
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
