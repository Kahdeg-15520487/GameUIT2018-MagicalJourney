using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {
    public GameObject text;

    public GameObject star;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 vector2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(star, vector2, transform.rotation);
            Instantiate(star, vector2 + new Vector2(1, 1), transform.rotation);
            Instantiate(star, vector2 + new Vector2(-5, 1), transform.rotation);
            Instantiate(star, vector2 + new Vector2(5, -1), transform.rotation);
            Instantiate(star, vector2 + new Vector2(-3, -1), transform.rotation);
            Instantiate(star, vector2 + new Vector2(3, -1), transform.rotation);
            Instantiate(text, vector2 , transform.rotation);
        }
    }
}
