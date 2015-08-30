using UnityEngine;
using System.Collections;

public class ItemDay2Tape2 : ItemHandler {
	
	public AudioClip sound2play;
	public GameObject radio;
	public int range = 2;
	
	// What to do when this item gets used.
	public override void Use() {
		AudioSource.PlayClipAtPoint(sound2play, Camera.main.transform.position);

		DayTwoController control = GameObject.FindGameObjectWithTag("controller").GetComponent<DayTwoController>();
		control.complete = true;

	}
	
	public override bool Consumes() {
		return true;
	}
	
	public override bool Usable() {
		return Vector3.Distance (Camera.main.transform.position, radio.transform.position) < range;
	}
	
}
