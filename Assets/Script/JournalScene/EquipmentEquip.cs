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
				}
			} else {
				if (this.gameObject.name != "Consumable1" ||
					this.gameObject.name != "Consumable2" ||
					this.gameObject.name != "Consumable3") {
					image = ItemEquip.EquipmentImage;
					transform.parent.GetComponent<Image> ().sprite = image;
				}
			}
		}
	}
}
