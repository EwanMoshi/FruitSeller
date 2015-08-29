using UnityEngine;
using System.Collections;

public class LightSwitch : MonoBehaviour {


	public Light theLight;
	private bool on = true;
	private float original_size;

	// Use this for initialization
	void Start () {
	
		original_size = theLight.intensity;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void clicked(){
		print ("switched");
		theLight.enabled = !theLight.enabled;
	}
}
