﻿using UnityEngine;
using System.Collections;

public class mannequinspawn : MonoBehaviour {

	public Transform spawnPoint;
	public GameObject prefab;
	public Light[] turnOff;

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

			for (int i = 0; i < turnOff.Length; i++) {
				turnOff[i].enabled = false;
			}

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
