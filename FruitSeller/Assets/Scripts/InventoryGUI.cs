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

	// Tooltip constants.
	const int TOOLTIP_LEFT_OFFSET = LEFT_OFFSET;
	const int TOOLTIP_BOTTOM_OFFSET = ITEM_WIDTH + BOTTOM_OFFSET + 25;
	
	// GUI stuff.
	private Rect inventoryWindowRect = new Rect(LEFT_OFFSET, Screen.height - 100, InventoryWidth (), 75);
	private bool inventoryOpen = false;

	// Inventory constants.
	static int NUM_ITEMS = 8;

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

	// Whenever the GUI redraws.
	void OnGUI() {

		GUI.Label (new Rect (50, 50, 100, 50), "Inventory (Tab)");

		// Transparent window.
		//GUI.color = new Color (1, 1, 1, 0);
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

				// Display content.

				if (GUI.Button(position, content)) {
					if (Inventory[i] != null) Inventory[i].Use();
				}
			}

			// Display currently seleted tooltip (this is "GUI.tooltip").
			GUI.Label (new Rect (TOOLTIP_LEFT_OFFSET,
			                     Screen.height - TOOLTIP_BOTTOM_OFFSET - 15,
			                     InventoryWidth (),
			                     60), GUI.tooltip);
		}
	}

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
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
			description = name_ + "\n" + description_;
			icon = icon_;
			handler = handler_;
		}

		public void Use () {
			handler.Use ();
		}
	}

}
