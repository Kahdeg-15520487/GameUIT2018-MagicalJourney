﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GestureScript : MonoBehaviour
{

    public Texture2D text;
    //public Texture2D display;
    bool iniCount = false;
    public float timer = 1.0f;
    GameObject image;

    public GameObject player;

    public bool Success = false;

    // Use this for initialization
    void Start()
    {
        image = GameObject.Find("Display");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (image == null)
        {
            return;
        }
        else if (iniCount)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                image.GetComponent<RawImage>().enabled = false;
                iniCount = false;
            }
        }
    }


    //This method is needed for the Gesture to run, here you set Texture for recognition and can set the sucess rate needed to be achived
    void setGestureConfig()
    {
        if (player == null)
        {
            Debug.LogError("<b>GestureScript:</b> The code need a reference to the object that has the playerInput script");
            return;
        }
        player.GetComponent<GesturePlayer.PlayerInput>().setTextureG(text);
        player.GetComponent<GesturePlayer.PlayerInput>().setCorrectRate(0.5f);
    }

    //This method happen when the player look to the object and can be used for a variety of things, in this exemple we use to display the Pattern
    void displayPattern()
    {
        if (image == null)
        {
            return;
        }
        else if (timer > 0.0f)
        {
            iniCount = true;
            //image.GetComponent<RawImage>().texture = display;
            image.GetComponent<RawImage>().enabled = true;
        }
    }

    //This method happen when the player succefully do the gesture
    void onGestureCorrect()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.green;
        Success = true;
    }

    //This method happen when the player failed in the gesture
    void onGestureWrong()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        Success = false;
    }


    /* This method can be used if you wanna create a clickable object only, with no gesture, 
       use this method to detect when the object is click, the object must have the tag "Clickable"
    void onClick ()
    {

    }*/
}
