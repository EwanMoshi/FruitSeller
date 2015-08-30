using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {

	public bool open = false;
	private AudioSource audio;
	// Use this for initialization
	void Start () {

		audio = gameObject.GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenClose (){
		print ("OPenClose called");
		if(!open){
			print ("open");



				


				gameObject.transform.Rotate(Vector3.up + new Vector3(0,90f,0));
				open = true;
				audio.Play();

			



		}
		else{
			print ("close");
		
				
				gameObject.transform.Rotate(Vector3.up - new Vector3(0,90f,0));
				open = false;
				audio.Play();
				

		}


	}




}
