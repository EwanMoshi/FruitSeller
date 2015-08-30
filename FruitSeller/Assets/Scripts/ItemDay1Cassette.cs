using UnityEngine;
using System.Collections;


public class ItemDay1Cassette : ItemHandler {

	public AudioSource staticNoise;
	public AudioClip sound2play;
	public GameObject radio;
	public int range = 2;

	public void Start() {
		print ("started");
		GameObject obj = GameObject.FindGameObjectWithTag ("StaticNoise");
		staticNoise = obj.GetComponent<AudioSource>();
	}

	// What to do when this item gets used.
	public override void Use() {
		staticNoise.volume = 0f;
		if(staticNoise==null){print ("fugg");}
		AudioSource.PlayClipAtPoint(sound2play, Camera.main.transform.position);

		GameObject bed = GameObject.Find ("mattress_18");

		Destroy(bed.GetComponent <InteractiveBehaviour>());

		//InteractiveBehaviour behave = new InteractiveBehaviour ();

		bed.AddComponent <InteractiveBehaviour>(  );

		GameObject bed2 = GameObject.Find ("mattress_18");
		InteractiveBehaviour bedBehave = bed2.GetComponent<InteractiveBehaviour>();

		bedBehave.hint = "Go to sleep";
		print (bedBehave.hint+ " :should of hinted");
		bedBehave.interactiveDescription = "yolo it";
		bedBehave.timeToDisplay = 2.0f;

	}
	
	public override bool Consumes() {
		return true;
	}
	
	public override bool Usable() {
		return Vector3.Distance (Camera.main.transform.position, radio.transform.position) < range;
	}
	
}

