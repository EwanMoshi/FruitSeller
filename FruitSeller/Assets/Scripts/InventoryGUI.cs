using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityStandardAssets.Characters.FirstPerson;

public class InventoryGUI : MonoBehaviour {
	
	// GUI drawing constants.
	static int WIDTH_INDENT = 100;
	static int ITEM_WIDTH = 50;

	// GUI stuff.
	private Rect inventoryWindowRect = new Rect(WIDTH_INDENT, Screen.height - 100, InventoryWidth (), 75);
	private bool inventoryOpen = false;

	// Camera.
	public Camera playerCam;
	public MouseLook mouselook;

	// Icons.
	public Texture2D iconRustyKey;

	// Inventory constants.
	static int NUM_ITEMS = 8;

	// Convenience method for computing width of inventory based on screen.
	static int InventoryWidth() {
		return Screen.width - 2 * WIDTH_INDENT;
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
	public bool addItem (Item itm) {
		for (int i = 0; i < Inventory.Length; i++) {
			if (Inventory[i] == null) {
				Inventory[i] = itm;
				return true;
			}
		}
		return false;
	}

	// Whenever the GUI redraws.
	void OnGUI() {

		GUI.Label (new Rect (50, 50, 100, 50), "Inventory (Tab)");

		// Transparent window.
		GUI.color = new Color (1, 1, 1, 0);
		if (inventoryOpen) {
			inventoryWindowRect = GUI.Window (0, inventoryWindowRect, MakeWindow, "Inventory");
		}
	}
	
	// Draw items in inventory window.
	void MakeWindow(int windowId) {
		
		GUILayout.BeginArea (new Rect (5, 20, InventoryWidth (), 100));
		GUILayout.BeginHorizontal ();

		Item keyItem = new Item (0, "Key", iconRustyKey, "This key is really rusty.");
		Inventory [0] = keyItem;

		for (int i = 0; i < NUM_ITEMS; i++) {
			if (Inventory [i] == null)
				GUILayout.Button (string.Empty, GUILayout.Height (ITEM_WIDTH), GUILayout.Width (ITEM_WIDTH));
			else
				GUILayout.Button (Inventory [i].icon, GUILayout.Height (ITEM_WIDTH), GUILayout.Width (ITEM_WIDTH));
		}
		
		GUILayout.EndHorizontal ();
		GUILayout.EndArea ();
		
	}
	
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
