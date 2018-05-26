using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemEquip : MonoBehaviour {

	private Text ItemDes;
	private Text SpellName;
	void Awake()
	{
		//tuy vao loai item ma chon item description text thich hop trong scene
		if (transform.parent.gameObject.name == "ItemContent") {
			ItemDes = GameObject.Find ("ItemDescription").GetComponent<Text> ();
		}
		if (transform.parent.gameObject.name == "KeyItemContent") {
			ItemDes = GameObject.Find ("KeyItemDescription").GetComponent<Text> ();
		}
		if (transform.parent.gameObject.name == "SpellContent") {
			ItemDes = GameObject.Find ("SpellDescription").GetComponent<Text> ();
			SpellName = GameObject.Find ("SpellNameLabel").GetComponent<Text> ();
		}
	}
	public void OnItemClick()
	{
		//khi nhan vao mot item thi cap nhat noi dung item description truoc, sau do
		ItemDes.text = this.gameObject.GetComponentInChildren<Text> ().text;

		//tuy vao loai item ma lam them cac hanh dong can thiet
		if (transform.parent.gameObject.name == "ItemContent") {
			ItemDes = GameObject.Find ("ItemDescription").GetComponent<Text> ();
		}
		if (transform.parent.gameObject.name == "KeyItemContent") {
			ItemDes = GameObject.Find ("KeyItemDescription").GetComponent<Text> ();
		}
		if (transform.parent.gameObject.name == "SpellContent") {
			ItemDes = GameObject.Find ("SpellDescription").GetComponent<Text> ();
		}
	}

}
