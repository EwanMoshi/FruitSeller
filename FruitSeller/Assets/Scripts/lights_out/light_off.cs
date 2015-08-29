using UnityEngine;
using System.Collections;

public class light_off : MonoBehaviour {

	//add all lights to this array you want off at start of day

	public Light[] lights;


	// Use this for initialization
	void Start () {

		foreach(Light lt in lights){

			lt.enabled = !lt.enabled;

		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
