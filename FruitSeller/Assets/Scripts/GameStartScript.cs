using UnityEngine;
using System.Collections;

// Called from TitleScreen, starts Game
// Ensure this is linked to correct game scene

public class GameStartScript : MonoBehaviour {

	public void StartGame () {
		Application.LoadLevel("Neal_Test");
	}

	void Start () {
	}

}
