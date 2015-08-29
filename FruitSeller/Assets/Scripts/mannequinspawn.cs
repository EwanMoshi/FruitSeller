using UnityEngine;
using System.Collections;

public class mannequinspawn : MonoBehaviour {

	public Transform spawnPoint;
	public GameObject prefab;
	private Vector3 spawned;
	// Use this for initialization
	void Start () {
		spawned = spawnPoint.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider other){

		if (other.gameObject.tag == "player") {
		
			Instantiate(prefab, spawned, transform.localRotation);
		
		}


	}
}
