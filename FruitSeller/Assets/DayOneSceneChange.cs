using UnityEngine;
using System.Collections;

public class DayOneSceneChange : MonoBehaviour {

	public bool levelComplete = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeScene(){

		if(levelComplete){
			Application.LoadLevel("Dont_Turn_On_Lights");
		}

		else if(!levelComplete){

			Application.LoadLevel("DayOne");
		}


	}
}
