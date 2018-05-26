using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemEquip : MonoBehaviour {

	public static Sprite EquipmentImage; //luu anh cua item co the equip
	public static string EquipmentType; //luu giu xem loai equipment duoc click la gi

	private Text ItemDes; //luu description cho tat ca cac item
	private Image itemImage; //luu hinh de preview cho keyitem
	private Text SpellName; //luu ten cua spellname
	void Awake()
	{
		EquipmentImage = null;
		EquipmentType = null;
		//tuy vao loai item ma chon item description text thich hop trong scene
		if (transform.parent.gameObject.name == "ItemContent") {
			ItemDes = GameObject.Find ("ItemDescription").GetComponent<Text> ();
		}
		if (transform.parent.gameObject.name == "KeyItemContent") {
			ItemDes = GameObject.Find ("KeyItemDescription").GetComponent<Text> ();
			itemImage = GameObject.Find ("KeyItemImage").GetComponent<Image> ();
		}
		if (transform.parent.gameObject.name == "SpellContent") {
			ItemDes = GameObject.Find ("SpellDescription").GetComponent<Text> ();
			SpellName = GameObject.Find ("SpellNameLabel").GetComponent<Text> ();
			itemImage = GameObject.Find ("SpellPreviewImage").GetComponent<Image> ();
		}
	}
	public void OnItemClick()
	{
		//khi nhan vao mot item thi cap nhat noi dung item description truoc, sau do
		ItemDes.text = this.gameObject.GetComponentInChildren<Text> ().text;

		//tuy vao loai item ma lam them cac hanh dong can thiet
		//neu vat pham duoc click la mot item
		if (transform.parent.gameObject.name == "ItemContent") {
			ItemDes = GameObject.Find ("ItemDescription").GetComponent<Text> (); //cap nhat text cho description tuong ung

			//dat anh cua item co the equip la item do
			EquipmentImage = transform.GetChild (0).GetComponentInChildren<Image> ().sprite;

			Debug.Log((transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name));
			//neu anh thuoc loai consumable
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Chocolate Mint" ||
			    transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Milk Tea" ||
			    transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Herbal Tea" ||
			    transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Custard Pie" ||
			    transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Curse seal") {

				EquipmentType = "Consumable";
			} else {
				EquipmentType = "Equipment";
			}
				
		}
		if (transform.parent.gameObject.name == "KeyItemContent") {
			ItemDes = GameObject.Find ("KeyItemDescription").GetComponent<Text> ();

			Sprite itemSprite = transform.GetChild (0).GetComponentInChildren<Image> ().sprite;
			itemImage.sprite = itemSprite;
		}
		if (transform.parent.gameObject.name == "SpellContent") {
			ItemDes = GameObject.Find ("SpellDescription").GetComponent<Text> ();

			Sprite itemSprite = transform.GetChild (0).GetComponentInChildren<Image> ().sprite;
			itemImage.sprite = itemSprite;
		}
	}

}
