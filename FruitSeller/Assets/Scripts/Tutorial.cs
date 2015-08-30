using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public bool fired = false;
	public float delay1 = 2f;
	public GameObject obj;

	public Light[] lights;

	// Update is called once per frame
	void Update () {

		if (!fired) {
			fired = true;

			for (int i = 0; i < lights.Length; i++) {
				if (lights[i] != null) lights[i].enabled = false;
			}

		}

		if (Time.time > delay1) {
			InventoryGUI.SetInteractiveDisplay("Look at things. Press E to interact with them.", 3);
			Destroy (obj);
		}
	}
}
