using UnityEngine;
using System.Collections;

public class Light_Flicker : MonoBehaviour {


	//private bool on = true;
	public Light theLight;
	public bool flickered = true;
	// Use this for initialization
	void Start () {
	
		theLight = GetComponent<Light>();

	}
	
	// Update is called once per frame
	void Update () {
	if (!flickered) {
			theLight.enabled = !theLight.enabled;
			flickered= true;
		} else {
			flickered = false;
		}
	}
}
