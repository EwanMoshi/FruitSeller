using UnityEngine;
using System.Collections;

public class enterkitchentrigger : MonoBehaviour {


	public AudioSource playThis;
	private bool hasPlayed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		print ("walked into kitch");
		if(other.gameObject.tag == "Player" && !hasPlayed){
			print ("hear that scream?");
			playThis.Play();
			hasPlayed = true;
		}

	}
}
