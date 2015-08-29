using UnityEngine;
using System.Collections;

public class clickOnShit : MonoBehaviour {


	public float range = 2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.E)) {
			Ray ray = Camera.main.ScreenPointToRay(new Vector3( Screen.width / 2, Screen.height / 2, 0));
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				Debug.Log ("Name = " + hit.collider.name);
				Debug.Log ("Tag = " + hit.collider.tag);
				Debug.Log ("Hit Point = " + hit.point);
				Debug.Log ("Object position = " + hit.collider.gameObject.transform.position);
				Debug.Log ("--------------");

				if(hit.collider.tag.Equals("switch") && hit.distance < range){
				
					LightSwitch light = hit.collider.gameObject.GetComponent<LightSwitch>();
					light.clicked();

				}
			}
		}
	
	}
}
