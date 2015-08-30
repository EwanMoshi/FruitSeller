using UnityEngine;
using System.Collections;

public class clickOnShit : MonoBehaviour {
	
	public AudioClip pickupSound;
	public AudioClip paperSound;
	
	public float range = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	bool interactive (string tag) {
		return tag.Equals ("interactive") || tag.Equals ("item + interactive");
	}
	
	bool pickupable (string tag) {
		return tag.Equals ("item") || tag.Equals ("item + interactive");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.E)) {
			Ray ray = Camera.main.ScreenPointToRay(new Vector3( Screen.width / 2, Screen.height / 2, 0));
			RaycastHit hit;
			
			if (Physics.Raycast(ray, out hit)) {
				
				/*
				Debug.Log ("Name = " + hit.collider.name);
				Debug.Log ("Tag = " + hit.collider.tag);
				Debug.Log ("Hit Point = " + hit.point);
				Debug.Log ("Object position = " + hit.collider.gameObject.transform.position);
				Debug.Log ("--------------");
				*/
<<<<<<< HEAD

				if(hit.collider.tag == "torch" && hit.distance < range){

					Destroy(hit.collider.gameObject);
					GameObject torch= GameObject.FindGameObjectWithTag("flashlight");

					if(torch!=null){
					Light light = torch.GetComponent<Light>();
						light.enabled = !light.enabled;
					}
				}


				if(hit.collider.tag.Equals("door")){
					door door = hit.collider.gameObject.GetComponent<door>();
					door.OpenClose();

				}

=======
				/*
>>>>>>> bc478438df0cf479507b8d3515e93010d6e5bed2
				if(hit.collider.tag.Equals("switch") && hit.distance < range){

					InteractiveLight light = hit.collider.gameObject.
					LightSwitch light = hit.collider.gameObject.GetComponent<LightSwitch>();
					light.clicked();
					
				}
				*/
				
				if (interactive(hit.collider.tag) && hit.distance < range) {
					GameObject obj = hit.collider.gameObject;
					InteractiveBehaviour ib = obj.GetComponent<InteractiveBehaviour>();
					InventoryGUI.SetInteractiveDisplay(ib.interactiveDescription, ib.timeToDisplay);
					Debug.Log ("inteact");
					ib.exec ();
				}
				
				if (pickupable(hit.collider.tag) && hit.distance < range){
					GameObject obj = hit.collider.gameObject;
					ItemBehaviour item = obj.GetComponent<ItemBehaviour>();
					
					// Attempt to pick up item. If successful, remove item from game world.
					// Play pick-up sound.
					
					if (InventoryGUI.hasSpace()) {
						InventoryGUI.addItem(item);
						AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
						Destroy(obj);
					}
					
				}
				
			}
		}
	}
	
	
}
