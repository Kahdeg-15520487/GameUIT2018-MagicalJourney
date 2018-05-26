using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemLoad : MonoBehaviour {

	public Transform Items;

	//key item
	public Sprite GuildAmulet;
	public Sprite DenverSeal;
	public Sprite NecroticSeal;
	public Sprite TeaBag;
	public Sprite WitchSeal;
	public Sprite SecretKey;
	public Sprite LoreScroll1;
	public Sprite LoreScroll2;
	public Sprite ScrapNote;

	//equipment
	public Sprite Sapphire;
	public Sprite Ruby;
	public Sprite Aether;
	public Sprite Zephyr;
	public Sprite Hermes;
	public Sprite Rainbow;
	public Sprite Antique;

	//consumable
	public Sprite Herbal;
	public Sprite Milk;
	public Sprite Custard;
	public Sprite Chocolate;
	public Sprite Curse;
	// Use this for initialization
	void Start () {

		//load cac item
		if (this.gameObject.name == "ItemContent") {
			if (PlayerPrefs.GetInt ("SapphireBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("SapphireDes");
				newItem.GetChild (0).GetComponent<Image> ().sprite = Sapphire;
			}
			if (PlayerPrefs.GetInt ("RubyBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("RubyDes");
				newItem.GetChild (0).GetComponent<Image> ().sprite = Ruby;
			}
			if (PlayerPrefs.GetInt ("AetherBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("AetherDes");
				newItem.GetChild (0).GetComponent<Image> ().sprite = Aether;
			}
			if (PlayerPrefs.GetInt ("HerbalBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("HerbalDes");
				newItem.GetChild (0).GetComponent<Image> ().sprite = Herbal;
			}
			if (PlayerPrefs.GetInt ("ZephyrBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("ZephyrDes");
				newItem.GetChild (0).GetComponent<Image> ().sprite = Zephyr;
			}
			if (PlayerPrefs.GetInt ("HermesBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("HermesDes");
				newItem.GetChild (0).GetComponent<Image> ().sprite = Hermes;
			}
			if (PlayerPrefs.GetInt ("RainbowBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("RainbowDes");
				newItem.GetChild (0).GetComponent<Image> ().sprite = Rainbow;
			}
			if (PlayerPrefs.GetInt ("AntiqueBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("AntiqueDes");
				newItem.GetChild (0).GetComponent<Image> ().sprite = Antique;
			}
			if (PlayerPrefs.GetInt ("MilkBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("MilkDes");
				newItem.GetChild (0).GetComponent<Image> ().sprite = Milk;
			}
			if (PlayerPrefs.GetInt ("CustardBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("CustardDes");
				newItem.GetChild (0).GetComponent<Image> ().sprite = Custard;
			}
			if (PlayerPrefs.GetInt ("ChocolateBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("ChocolateDes");
				newItem.GetChild (0).GetComponent<Image> ().sprite = Chocolate;
			}
			if (PlayerPrefs.GetInt ("CurseBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("CurseDes");
				newItem.GetChild (0).GetComponent<Image> ().sprite = Curse;
			}
				
		}
		//load cac keyitem
		if (this.gameObject.name == "KeyItemContent") {
			if (PlayerPrefs.GetInt ("GuildBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("GuildDes");
				newItem.GetChild (0).GetComponent<Image> ().sprite = GuildAmulet;
			}
			if (PlayerPrefs.GetInt ("DenverBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("DenverDes");
				newItem.GetChild (0).GetComponent<Image> ().sprite = DenverSeal;
			}
			if (PlayerPrefs.GetInt ("NecroticBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("NecroticDes");
				newItem.GetChild (0).GetComponent<Image> ().sprite = NecroticSeal;
			}
			if (PlayerPrefs.GetInt ("TeabagBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("TeabagDes");
				newItem.GetChild (0).GetComponent<Image> ().sprite = TeaBag;
			}
			if (PlayerPrefs.GetInt ("WitchBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("WitchDes");
				newItem.GetChild (0).GetComponent<Image> ().sprite = WitchSeal;
			}
			if (PlayerPrefs.GetInt ("SecretKeyBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("SecretKeyDes");
				newItem.GetChild (0).GetComponent<Image> ().sprite = SecretKey;
			}
			if (PlayerPrefs.GetInt ("LoreScroll1Bool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("LoreScroll1Des");
				newItem.GetChild (0).GetComponent<Image> ().sprite = LoreScroll1;
			}
			if (PlayerPrefs.GetInt ("LoreScroll2Bool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("LoreScroll2Des");
				newItem.GetChild (0).GetComponent<Image> ().sprite = LoreScroll2;
			}
			if (PlayerPrefs.GetInt ("ScrapNoteBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("ScrapNoteDes");
				newItem.GetChild (0).GetComponent<Image> ().sprite = ScrapNote;
			}
		}

		//load cac spell
		if (this.gameObject.name == "SpellContent") {
			if (PlayerPrefs.GetInt ("Spell1Bool") == 1) {
				//Instantiate (Items, this.gameObject.transform).GetComponentInChildren<Text>().text = PlayerPrefs.GetString ("Spell1Des");
				Transform newSpell = Instantiate (Items, this.gameObject.transform);
				if (PlayerPrefs.GetString ("Spell1Image") == "Gear") {
					//newSpell.GetChild (0).GetComponent<Image> ().sprite = Gear;
				}
			}
		}

	}
}
