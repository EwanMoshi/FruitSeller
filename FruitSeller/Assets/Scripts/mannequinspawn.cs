using UnityEngine;
using System.Collections;

public class mannequinspawn : MonoBehaviour {

	public Transform spawnPoint;
	public GameObject prefab;
	private Vector3 spawned;

	private bool hasPlayedEnter = false;
	private bool hasPlayedExit = false;
	// Use this for initialization
	void Start () {
		spawned = spawnPoint.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider other){

		if (other.gameObject.tag == "player" && !hasPlayedExit) {
		
			Instantiate(prefab, spawned, transform.localRotation);

			spawnPoint.GetComponent<AudioSource>().Play();
		    
			hasPlayedExit = true;
		}


	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "player" && !hasPlayedEnter) {
			
			AudioSource source = GetComponent<AudioSource>();

			source.Play();

			hasPlayedEnter =true;
			
		}

	}
}
