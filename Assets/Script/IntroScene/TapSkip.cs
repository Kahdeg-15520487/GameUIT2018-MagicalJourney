using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class TapSkip : MonoBehaviour {
    VideoPlayer videoPlayer;
    public GameObject game;
    // Use this for initialization
    void Start () {
        videoPlayer = GetComponent<VideoPlayer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            //videoPlayer.StepForward()
            videoPlayer.frame = 80;
            game.SetActive(false);
        }
        if ((ulong)videoPlayer.frame == videoPlayer.frameCount)
        {
            SceneManager.LoadScene("tt", LoadSceneMode.Single);
        }
    }
}
