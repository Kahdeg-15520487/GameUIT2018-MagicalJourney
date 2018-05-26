using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestructStarLight : MonoBehaviour {
   // public Vector2 vector2;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 2);
      //  gameObject.GetComponent<Renderer>().material.color.a = 0;
    }

    // Update is called once per frame
    void Update () {
     
        transform.localScale += new Vector3(0.005f, 0.005f, 0);

       
    }
}
