using UnityEngine;
using System.Collections;

public class basement_trigger : MonoBehaviour {

	public Light turnOff;
	public Light torch;
	public Light torch2;
	public GameObject mannequin;
	private bool onePlay = true;
	private bool timed = false;

	public float timeToWait = 2f;
	public float timer = 0;

	private bool waited = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(timed){
			timer += Time.deltaTime;
			if(timer > timeToWait && waited){
				torch.enabled = !torch.enabled;
				torch2.enabled = !torch2.enabled;
				waited = false;
			}

		}

	}

	void OnTriggerEnter(Collider other){
		if(onePlay){
		torch.enabled = !torch.enabled;
			torch2.enabled = !torch2.enabled;
		}
	}

	void OnTriggerExit(Collider other){
		print ("entered trigger");

		if (onePlay) {
			print ("turning light off");
			turnOff.enabled = !turnOff.enabled;

			timed = true;
			//torch.enabled = !torch.enabled;

			Destroy(mannequin);
			onePlay = false;
		}

	}


}
