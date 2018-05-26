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

	//spell
	public Sprite Fireball;
	public Sprite Firepit;
	public Sprite SummonRock;
	public Sprite MagicMissle;


	void Start () {

		//load cac item
		if (this.gameObject.name == "ItemContent") {
			if (PlayerPrefs.GetInt ("SapphireBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetChild (0).GetComponent<Image> ().sprite = Sapphire;
				newItem.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("SapphireName");
			}
			if (PlayerPrefs.GetInt ("RubyBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetChild (0).GetComponent<Image> ().sprite = Ruby;
				newItem.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("RubyName");
			}
			if (PlayerPrefs.GetInt ("AetherBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetChild (0).GetComponent<Image> ().sprite = Aether;
				newItem.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("AetherName");
			}
			if (PlayerPrefs.GetInt ("HerbalBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetChild (0).GetComponent<Image> ().sprite = Herbal;
				newItem.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("HerbalName");
			}
			if (PlayerPrefs.GetInt ("ZephyrBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetChild (0).GetComponent<Image> ().sprite = Zephyr;
				newItem.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("ZephyrName");
			}
			if (PlayerPrefs.GetInt ("HermesBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetChild (0).GetComponent<Image> ().sprite = Hermes;
				newItem.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("HermesName");
			}
			if (PlayerPrefs.GetInt ("RainbowBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetChild (0).GetComponent<Image> ().sprite = Rainbow;
				newItem.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("RainbowName");
			}
			if (PlayerPrefs.GetInt ("AntiqueBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetChild (0).GetComponent<Image> ().sprite = Antique;
				newItem.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("AntiqueName");
			}
			if (PlayerPrefs.GetInt ("MilkBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetChild (0).GetComponent<Image> ().sprite = Milk;
				newItem.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("MilkName");
			}
			if (PlayerPrefs.GetInt ("CustardBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetChild (0).GetComponent<Image> ().sprite = Custard;
				newItem.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("CustardName");
			}
			if (PlayerPrefs.GetInt ("ChocolateBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetChild (0).GetComponent<Image> ().sprite = Chocolate;
				newItem.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("ChocolateName");
			}
			if (PlayerPrefs.GetInt ("CurseBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetChild (0).GetComponent<Image> ().sprite = Curse;
				newItem.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("CurseName");
			}
				
		}
		//load cac keyitem
		if (this.gameObject.name == "KeyItemContent") {
			if (PlayerPrefs.GetInt ("GuildBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetChild (0).GetComponent<Image> ().sprite = GuildAmulet;
				newItem.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("GuildName");
			}
			if (PlayerPrefs.GetInt ("DenverBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetChild (0).GetComponent<Image> ().sprite = DenverSeal;
				newItem.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("SapphireName");
			}
			if (PlayerPrefs.GetInt ("NecroticBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetChild (0).GetComponent<Image> ().sprite = NecroticSeal;
				newItem.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("NecroticName");
			}
			if (PlayerPrefs.GetInt ("TeabagBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetChild (0).GetComponent<Image> ().sprite = TeaBag;
				newItem.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("WitchName");
			}
			if (PlayerPrefs.GetInt ("WitchBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetChild (0).GetComponent<Image> ().sprite = WitchSeal;
				newItem.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("SapphireName");
			}
			if (PlayerPrefs.GetInt ("SecretKeyBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetChild (0).GetComponent<Image> ().sprite = SecretKey;
				newItem.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("SecretKeyName");
			}
			if (PlayerPrefs.GetInt ("LoreScroll1Bool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetChild (0).GetComponent<Image> ().sprite = LoreScroll1;
				newItem.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("LoreScroll1Name");
			}
			if (PlayerPrefs.GetInt ("LoreScroll2Bool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetChild (0).GetComponent<Image> ().sprite = LoreScroll2;
				newItem.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("LoreScroll2Name");
			}
			if (PlayerPrefs.GetInt ("ScrapNoteBool") == 1) {
				Transform newItem = Instantiate (Items, this.gameObject.transform);
				newItem.GetChild (0).GetComponent<Image> ().sprite = ScrapNote;
				newItem.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("ScrapNoteName");
			}
		}

		//load cac spell
		if (this.gameObject.name == "SpellContent") {
			//load 4 spell
			Transform newSpell1 = Instantiate (Items, this.gameObject.transform);
			newSpell1.GetChild (0).GetComponent<Image> ().sprite = Fireball;
			newSpell1.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("Spell1Name");

			Transform newSpell2 = Instantiate (Items, this.gameObject.transform);
			newSpell2.GetChild (0).GetComponent<Image> ().sprite = Firepit;
			newSpell2.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("Spell2Name");

			Transform newSpell3 = Instantiate (Items, this.gameObject.transform);
			newSpell3.GetChild (0).GetComponent<Image> ().sprite = SummonRock;
			newSpell3.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("Spell3Name");

			Transform newSpell4 = Instantiate (Items, this.gameObject.transform);
			newSpell4.GetChild (0).GetComponent<Image> ().sprite = MagicMissle;
			newSpell4.GetChild (1).GetComponent<Text> ().text = PlayerPrefs.GetString ("Spell4Name");
		}

	}
}
