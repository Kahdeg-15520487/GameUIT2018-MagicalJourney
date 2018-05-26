using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalTabName : MonoBehaviour {

	private Text JournalName;

	void Awake()
	{
		JournalName = GameObject.Find ("JournalTabName").GetComponent<Text> ();;
	}
	public void JournalNameOnClick()
	{
		if (this.gameObject.name == "SpellDeck") {
			JournalName.text = "Spell Deck";
		}
		if (this.gameObject.name == "Equipment") {
			JournalName.text = "Equipment";
		}
		if (this.gameObject.name == "KeyItem") {
			JournalName.text = "Key Items";
		}
		if (this.gameObject.name == "Status") {
			JournalName.text = "Player's Status";
		}
			
	}
}
