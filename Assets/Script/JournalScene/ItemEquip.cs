using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemEquip : MonoBehaviour {

	public static Sprite EquipmentImage; //luu anh cua item co the equip
	public static string EquipmentType; //luu giu xem loai equipment duoc click la gi

	public static string ItemDesString; //luu description cho tat ca cac item
	private Text ItemDes; //UI text hien thi description cho tat ca cac items
	private Image itemImage; //luu hinh de preview cho keyitem
	private Text SpellName; //luu ten cua spellname
	void Awake()
	{
		EquipmentImage = null;
		EquipmentType = null;
		//tuy vao loai item ma chon UI hien thi tuong ung text thich hop trong scene
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
		//tuy vao loai item ma lam them cac hanh dong can thiet
		//neu vat pham duoc click la mot item
		if (transform.parent.gameObject.name == "ItemContent") {

			//cap nhat text description tuong ung cho tung item
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Chocolate Mint")
				ItemDes.text = PlayerPrefs.GetString ("ChocolateDes");
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Ruby Bracelet")
				ItemDes.text = PlayerPrefs.GetString ("RubyDes");
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Sapphire Necklace")
				ItemDes.text = PlayerPrefs.GetString ("SapphireDes");
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Milk Tea")
				ItemDes.text = PlayerPrefs.GetString ("MilkDes");
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Hermes Ring")
				ItemDes.text = PlayerPrefs.GetString ("HermesDes");
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Zephyr Ring")
				ItemDes.text = PlayerPrefs.GetString ("ZephyrDes");
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Rainbow Charm")
				ItemDes.text = PlayerPrefs.GetString ("RainbowDes");
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Herbal Tea")
				ItemDes.text = PlayerPrefs.GetString ("HerbalDes");
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Custard Pie")
				ItemDes.text = PlayerPrefs.GetString ("CustardDes");
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Curse Seal")
				ItemDes.text = PlayerPrefs.GetString ("CurseDes");
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Antique Necklace")
				ItemDes.text = PlayerPrefs.GetString ("AntiqueDes");
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Aether Ring")
				ItemDes.text = PlayerPrefs.GetString ("AetherDes");


			//dat anh cua item co the equip la item do
			EquipmentImage = transform.GetChild (0).GetComponentInChildren<Image> ().sprite;

			//neu anh thuoc loai consumable
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Chocolate Mint" ||
			    transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Milk Tea" ||
			    transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Herbal Tea" ||
			    transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Custard Pie" ||
			    transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Curse seal") {

				//thi dat loai la consume (su dung cho equip item)
				EquipmentType = "Consumable";
			} else {
				EquipmentType = "Equipment";
			}
				
		}
		if (transform.parent.gameObject.name == "KeyItemContent") {
			//dat text description tuong ung cho tung keyitem
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Denver Seal")
				ItemDes.text = PlayerPrefs.GetString ("DenverDes");
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Guild Amulet")
				ItemDes.text = PlayerPrefs.GetString ("GuildDes");
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Lore Scroll 1")
				ItemDes.text = PlayerPrefs.GetString ("LoreScroll1Des");
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Lore Scroll 2")
				ItemDes.text = PlayerPrefs.GetString ("LoreScroll2Des");
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Necrotic Seal")
				ItemDes.text = PlayerPrefs.GetString ("NecroticDes");
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Scrap Note - Part 7")
				ItemDes.text = PlayerPrefs.GetString ("ScrapNoteDes");
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Secret Key")
				ItemDes.text = PlayerPrefs.GetString ("SecretKeyDes");
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "teabag")
				ItemDes.text = PlayerPrefs.GetString ("TeabagDes");
			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "Witch Seal")
				ItemDes.text = PlayerPrefs.GetString ("WitchDes");

			Sprite itemSprite = transform.GetChild (0).GetComponentInChildren<Image> ().sprite;
			itemImage.sprite = itemSprite;
		}

		if (transform.parent.gameObject.name == "SpellContent") {

			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "fireball") {
				SpellName.text = PlayerPrefs.GetString ("Spell1Name");
				ItemDes.text = PlayerPrefs.GetString ("Spell1Des");
			}

			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "firepit") {
				SpellName.text = PlayerPrefs.GetString ("Spell2Name");
				ItemDes.text = PlayerPrefs.GetString ("Spell2Des");
			}

			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "summon_rock") {
				SpellName.text = PlayerPrefs.GetString ("Spell3Name");
				ItemDes.text = PlayerPrefs.GetString ("Spell3Des");
			}

			if (transform.GetChild (0).GetComponentInChildren<Image> ().sprite.name == "magic_missle") {
				SpellName.text = PlayerPrefs.GetString ("Spell4Name");
				ItemDes.text = PlayerPrefs.GetString ("Spell4Des");
			}
			Sprite itemSprite = transform.GetChild (0).GetComponentInChildren<Image> ().sprite;
			itemImage.sprite = itemSprite;
		}
	}

}
