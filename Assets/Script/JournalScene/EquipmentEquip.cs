using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentEquip : MonoBehaviour {

	private Sprite image;

	public void EquipmentClick()
	{
		if (ItemEquip.EquipmentType != null && ItemEquip.EquipmentImage != null) {
			if (ItemEquip.EquipmentType == "Consumable") {
				if (this.gameObject.name == "Consumable1" ||
				    this.gameObject.name == "Consumable2" ||
				    this.gameObject.name == "Consumable3") {
					image = ItemEquip.EquipmentImage;
					transform.parent.GetComponent<Image> ().sprite = image;
					if (this.gameObject.name == "Consumable1") {
						PlayerPrefs.SetString ("Consumable1", transform.parent.GetComponent<Image> ().sprite.name);
					//	Debug.Log(PlayerPrefs.GetString("Consumable1"));
					}

					if (this.gameObject.name == "Consumable2") {
						PlayerPrefs.SetString ("Consumable2", transform.parent.GetComponent<Image> ().sprite.name);
					//	Debug.Log(PlayerPrefs.GetString("Consumable2"));
					}

					if (this.gameObject.name == "Consumable3") {
						PlayerPrefs.SetString ("Consumable3", transform.parent.GetComponent<Image> ().sprite.name);
					//	Debug.Log(PlayerPrefs.GetString("Consumable3"));
					}
				}
			} else if (ItemEquip.EquipmentType == "Equipment") {
				if (this.gameObject.name != "Consumable1" &&
					this.gameObject.name != "Consumable2" &&
					this.gameObject.name != "Consumable3") {
					image = ItemEquip.EquipmentImage;
					transform.parent.GetComponent<Image> ().sprite = image;

					if (this.gameObject.name == "Equipment1") {
						PlayerPrefs.SetString ("Equipment1", transform.parent.GetComponent<Image> ().sprite.name);
						//Debug.Log(PlayerPrefs.GetString("Equipment1"));
					}

					if (this.gameObject.name == "Equipment2") {
						PlayerPrefs.SetString ("Equipment2", transform.parent.GetComponent<Image> ().sprite.name);
						//Debug.Log(PlayerPrefs.GetString("Equipment2"));
					}

					if (this.gameObject.name == "Equipment3") {
						PlayerPrefs.SetString ("Equipment3", transform.parent.GetComponent<Image> ().sprite.name);
					//	Debug.Log(PlayerPrefs.GetString("Equipment3"));
					}

					if (this.gameObject.name == "Equipment4") {
						PlayerPrefs.SetString ("Equipment4", transform.parent.GetComponent<Image> ().sprite.name);
					//	Debug.Log(PlayerPrefs.GetString("Equipment4"));
					}
				}
			}
		}
	}
}
