using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

    /// <summary>
    /// will move by every frame
    /// </summary>
    public Vector3 MovementVector;
	
	// Update is called once per frame
	void Update () {
        transform.position += MovementVector;
	}
}
