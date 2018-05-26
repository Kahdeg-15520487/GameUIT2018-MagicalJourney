using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemEquip : MonoBehaviour {

	private Text ItemDes;

	void Awake()
	{
		ItemDes = GameObject.Find ("ItemDescription").GetComponent<Text>();
	}
	public void OnItemClick()
	{
		Debug.Log ("Click on item " + this.gameObject.name);
		ItemDes.text = this.gameObject.GetComponentInChildren<Text> ().text;
	}

}
