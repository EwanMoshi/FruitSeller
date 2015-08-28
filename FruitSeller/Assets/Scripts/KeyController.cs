
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyController : MonoBehaviour {
	
	public InventoryGUI inventoryGUI;
	
	void Update() {
		if (Input.GetKeyDown (KeyCode.Return)) {
			Debug.Log ("Enter Key pressed");
		} else if (Input.GetKeyDown (KeyCode.Tab)) {
			inventoryGUI.toggleInventory();
		}
	}
	
}
