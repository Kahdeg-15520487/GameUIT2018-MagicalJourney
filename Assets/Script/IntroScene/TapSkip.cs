using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class TapSkip : MonoBehaviour
{
    public GameObject text;
#if UNITY_EDITOR
    VideoPlayer videoPlayer;
    public GameObject game;
#endif
    // Use this for initialization
    void Start()
    {
#if UNITY_EDITOR
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Play();
#elif UNITY_ANDROID
        Handheld.PlayFullScreenMovie("intro.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
        GameObject.Destroy(text);
#endif
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            //videoPlayer.StepForward()
            videoPlayer.frame = 80;
            game.SetActive(false);
        }
        if ((ulong)videoPlayer.frame == videoPlayer.frameCount)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
#endif

#if UNITY_ANDROID
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
#endif
    }
}
