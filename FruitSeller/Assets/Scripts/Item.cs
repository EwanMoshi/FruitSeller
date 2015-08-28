using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public string name;
	public string description;
	public Texture2D icon;
	public int id;

	public void ItemPickup(){
		Debug.Log ("Pick up");
	}

	public Item (int id_, string name_, Texture2D icon_, string description_) {
		id = id_;
		name = name_;
		icon = icon_;
		description = description_;
	}

}
