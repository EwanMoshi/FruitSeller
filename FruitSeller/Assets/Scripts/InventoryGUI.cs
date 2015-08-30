using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityStandardAssets.Characters.FirstPerson;

public class InventoryGUI : MonoBehaviour {
	
	// GUI drawing constants.
	const int LEFT_OFFSET = 100;
	const int BOTTOM_OFFSET = 20;
	const int ITEM_WIDTH = 50;
	const int GAP = 10;
	
	// Item tooltip constants.
	const int TOOLTIP_LEFT_OFFSET = LEFT_OFFSET;
	const int TOOLTIP_BOTTOM_OFFSET = ITEM_WIDTH + BOTTOM_OFFSET + 10;
	
	// Interactive display constants.
	const int INTERACTIVE_LEFT_OFFSET = LEFT_OFFSET;
	const int INTERACTIVE_BOTTOM_OFFSET = TOOLTIP_BOTTOM_OFFSET + 25;
	const int FADEOUT = 2; // how long it takes for description to fade out.
	
	// Interactive hint constants.
	const int HINT_LEFT_OFFSET = INTERACTIVE_LEFT_OFFSET;
	const int HINT_BOTTOM_OFFSET = INTERACTIVE_BOTTOM_OFFSET + 40;
	
	// Current interactive description being displayed.
	static string interactiveDisplay;
	static float timeToDisplay;
	static float timeStarted;
	
	// GUI stuff.
	private Rect inventoryWindowRect = new Rect(LEFT_OFFSET, Screen.height - 100, InventoryWidth (), 75);
	private bool inventoryOpen = false;
	
	// Inventory constants.
	static int NUM_ITEMS = 8;
	
	const int range = 2;
	
	// Convenience method for computing width of inventory based on screen.
	static int InventoryWidth() {
		return NUM_ITEMS * ITEM_WIDTH + (NUM_ITEMS - 1) * GAP;
	}
	
	// Items in inventory.
	static public Item[] Inventory = new Item[8];
	
	// Toggle whether inventory is visible on the GUI.
	public void toggleInventory () {
		if (!this.inventoryOpen) {
			this.inventoryOpen = true;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		} else {
			this.inventoryOpen = false;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}
	
	// Add an item to the inventory. Return 'true' if successful or 'false' otherwise.
	public static bool addItem (ItemBehaviour itemBehaviour) {
		for (int i = 0; i < Inventory.Length; i++) {
			if (Inventory[i] == null) {
				Inventory[i] = new Item(itemBehaviour.itemName,
				                        itemBehaviour.icon,
				                        itemBehaviour.description,
				                        itemBehaviour.itemHandler);
				return true;
			}
		}
		return false;
	}
	
	public static bool hasSpace () {
		for (int i = 0; i < Inventory.Length; i++) {
			if (Inventory[i] == null) return true;
		}
		return false;
	}
	
	bool interactive (string tag) {
		return tag.Equals ("interactive") || tag.Equals ("item + interactive") || tag.Equals ("torch");
	}
	
	bool pickupable (string tag) {
		return tag.Equals ("item") || tag.Equals ("item + interactive");
	}
	
	// Whenever the GUI redraws.
	void OnGUI() {
		
		// Raycast to check for interactive elements in front of you.
		Ray ray = Camera.main.ScreenPointToRay(new Vector3( Screen.width / 2, Screen.height / 2, 0));
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			if (interactive(hit.collider.tag) && hit.distance < range) {
				GameObject obj = hit.collider.gameObject;
				InteractiveBehaviour ib = obj.GetComponent<InteractiveBehaviour>();
				GUI.Label (new Rect(HINT_LEFT_OFFSET, Screen.height - HINT_BOTTOM_OFFSET, 100, 25), ib.hint);
			}
		}
		
		// Draw inventory.
		if (inventoryOpen) {
			for (int i = 0; i < NUM_ITEMS; i++) {
				
				// Compute position on screen to show item.
				Rect position = new Rect(LEFT_OFFSET + GAP*i + ITEM_WIDTH*i,
				                         Screen.height - ITEM_WIDTH - BOTTOM_OFFSET,
				                         ITEM_WIDTH, ITEM_WIDTH);
				
				// If there's an item in the slot get the content	.
				GUIContent content;
				if (Inventory[i] == null) content = new GUIContent();
				else content = new GUIContent(string.Empty, Inventory[i].icon, Inventory[i].description);
				
				// Make button, add listener.
				if (GUI.Button(position, content)) {
					if (Inventory[i] != null && Inventory[i].Usable()) {
						Inventory[i].Use ();
						if (Inventory[i].Consumable()) Inventory[i] = null;
					}
				}
			}
			
			// Display currently seleted tooltip (this is "GUI.tooltip").
			GUI.Label (new Rect (TOOLTIP_LEFT_OFFSET,
			                     Screen.height - TOOLTIP_BOTTOM_OFFSET - 15,
			                     InventoryWidth (),
			                     60), GUI.tooltip);
		}
		
		// Display current interactive display.
		if (interactiveDisplay != string.Empty) {
			
			// Check whether the display should be removed.
			float timeNow = Time.time;
			if (timeNow - timeStarted > timeToDisplay + FADEOUT) {
				interactiveDisplay = string.Empty;
			}
			
			// Display current interactive text.
			// Fade out if need be.
			else {
				
				// Position of interactive text.
				Rect position = new Rect(INTERACTIVE_LEFT_OFFSET,
				                         Screen.height - INTERACTIVE_BOTTOM_OFFSET - 15,
				                         InventoryWidth(), 60);
				
				// Set alpha based on time to fadeout.
				// Inject f : (0,FADEOUT) -> (0,1)
				// The input x is the amount of time of FADEOUT elapsed. 
				float x = (timeToDisplay + FADEOUT) - (timeNow - timeStarted);
				float alpha = x / FADEOUT;
				
				float r = GUI.color.r;
				float g = GUI.color.g;
				float b = GUI.color.b;
				GUI.color = new Color(r,g,b,alpha);
				GUI.Label(position, interactiveDisplay);
				GUI.color = new Color(r,g,b,1);
			}
			
		}
		
		
		
	}
	
	// Set some text to be displayed on the gui.
	// text : what should be displayed
	// displayTime : how long to display (in seconds)
	public static void SetInteractiveDisplay (string text, float displayTime) {
		interactiveDisplay = text;
		timeToDisplay = displayTime;
		timeStarted = Time.time;
	}
	
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		interactiveDisplay = string.Empty;
		timeToDisplay = 0f;
		timeStarted = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public class Item {
		public string name;
		public string description;
		public Texture2D icon;
		public ItemHandler handler;
		
		public Item (string name_, Texture2D icon_, string description_, ItemHandler handler_) {
			name = name_;
			description = description_;
			icon = icon_;
			handler = handler_;
		}
		
		public void Use () {
			handler.Use ();
		}
		
		public bool Consumable () {
			return handler.Consumes();
		}
		
		public bool Usable () {
			return handler.Usable ();
		}
	}
	
}
