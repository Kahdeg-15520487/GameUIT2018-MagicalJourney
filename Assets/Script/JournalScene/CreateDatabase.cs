using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDatabase : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("GuildBool", 1);
		PlayerPrefs.SetInt ("DenverBool", 1);
		PlayerPrefs.SetInt ("NecroticBool", 1);
		PlayerPrefs.SetInt ("TeabagBool", 1);
		PlayerPrefs.SetInt ("WitchBool", 1);
		PlayerPrefs.SetInt ("SecretKeyBool", 1);
		PlayerPrefs.SetInt ("LoreScroll1Bool", 1);
		PlayerPrefs.SetInt ("LoreScroll2Bool", 1);
		PlayerPrefs.SetInt ("ScrapNoteBool", 1);
		PlayerPrefs.SetInt ("SapphireBool", 1);
		PlayerPrefs.SetInt ("RubyBool", 1);
		PlayerPrefs.SetInt ("AetherBool", 1);
		PlayerPrefs.SetInt ("ZephyrBool", 1);
		PlayerPrefs.SetInt ("HermesBool", 1);
		PlayerPrefs.SetInt ("RainbowBool", 1);
		PlayerPrefs.SetInt ("AntiqueBool", 1);
		PlayerPrefs.SetInt ("HerbalBool", 1);
		PlayerPrefs.SetInt ("MilkBool", 1);
		PlayerPrefs.SetInt ("CustardBool", 1);
		PlayerPrefs.SetInt ("ChocolateBool", 1);
		PlayerPrefs.SetInt ("CurseBool", 1);
		PlayerPrefs.SetString ("GuildName", "Guild Amulet");
		PlayerPrefs.SetString ("DenverName", "Denver Seal");
		PlayerPrefs.SetString ("NecroticName", "Necrotic Seal");
		PlayerPrefs.SetString ("TeabagName", "Tea Bag");
		PlayerPrefs.SetString ("WitchName", "Witch Seal");
		PlayerPrefs.SetString ("SecretKeyName", "Secret Key");
		PlayerPrefs.SetString ("LoreScroll1Name", "Lore Scroll - Paragraph 1");
		PlayerPrefs.SetString ("LoreScroll2Name", "Lore Scroll - Paragraph 4");
		PlayerPrefs.SetString ("ScrapNoteName", "Scrap Note - Page 5");
		PlayerPrefs.SetString ("SapphireName", "Sapphire Necklace");
		PlayerPrefs.SetString ("RubyName", "Ruby Bracelet");
		PlayerPrefs.SetString ("AetherName", "Aether Ring");
		PlayerPrefs.SetString ("ZephyrName", "Zephyr Ring");
		PlayerPrefs.SetString ("HermesName", "Hermes Ring");
		PlayerPrefs.SetString ("RainbowName", "Rainbow Charm");
		PlayerPrefs.SetString ("AntiqueName", "Antique Necklace");
		PlayerPrefs.SetString ("HerbalName", "Herbal Tea");
		PlayerPrefs.SetString ("MilkName", "Milk Tea");
		PlayerPrefs.SetString ("CustardName", "Custard Pie");
		PlayerPrefs.SetString ("ChocolateName", "Chocolate Mint");
		PlayerPrefs.SetString ("CurseName", "Curse Seal");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
