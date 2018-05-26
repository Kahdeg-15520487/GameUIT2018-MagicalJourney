using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLoad : MonoBehaviour {

	public Transform Items;
	// Use this for initialization
	void Start () {
		Instantiate (Items, this.gameObject.transform);
		Instantiate (Items, this.gameObject.transform);
		Instantiate (Items, this.gameObject.transform);
		Instantiate (Items, this.gameObject.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
