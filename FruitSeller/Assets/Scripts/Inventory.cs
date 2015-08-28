
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public List<Item> inventory = new List<Item>();

	void Update() {
		if (Input.GetKeyDown (KeyCode.Return)) {
			Debug.Log ("Enter Key pressed");
		}
	}

}
