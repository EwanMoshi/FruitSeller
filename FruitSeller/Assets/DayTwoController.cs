using UnityEngine;
using System.Collections;

public class DayTwoController : MonoBehaviour {


	public bool complete = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeScene(){

		if(complete){

			Application.LoadLevel("JudgementDay");
		}


		else if(!complete){

			Application.LoadLevel("Dont_Turn_On_Lights");
		}
	}
}
