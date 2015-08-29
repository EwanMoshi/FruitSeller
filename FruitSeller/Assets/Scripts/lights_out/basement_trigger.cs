using UnityEngine;
using System.Collections;

public class basement_trigger : MonoBehaviour {

	public Light turnOff;
	private bool onePlay = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		print ("entered trigger");

		if (onePlay) {
			print ("turning light off");
			turnOff.enabled = !turnOff.enabled;
			onePlay = false;
		}

	}
}
