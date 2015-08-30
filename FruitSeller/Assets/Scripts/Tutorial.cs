using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public float delay1 = 2f;
	public GameObject obj;

	// Update is called once per frame
	void Update () {
		if (Time.time > delay1) {
			InventoryGUI.SetInteractiveDisplay("Look at things. Press E to interact with them.", 3);
			Destroy (obj);
		}
	}
}
