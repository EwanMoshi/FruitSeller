using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public string name;
	public string description;
	public Texture2D icon;

	public void ItemPickup(){
		Debug.Log ("Pick up");
	}

}
