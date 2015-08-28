using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryGUI : MonoBehaviour {
	
	// GUI drawing constants.
	static int WIDTH_INDENT = 100;
	static int ITEM_WIDTH = 50;
	
	// GUI stuff.
	private Rect inventoryWindowRect = new Rect(WIDTH_INDENT, Screen.height - 100, InventoryWidth (), 75);
	private bool inventoryOpen = false;
	
	// Convenience method for computing width of inventory based on screen.
	static int InventoryWidth() {
		return Screen.width - 2 * WIDTH_INDENT;
	}
	
	// Items in inventory.
	public List<Item> inventory = new List<Item>();
	
	// Toggle whether inventory is visible on the GUI.
	public void toggleInventory () {
		this.inventoryOpen = !this.inventoryOpen;
	}
	
	// Whenever the GUI redraws.
	void OnGUI() {
		GUI.Label (new Rect (50, 50, 100, 50), "Inventory (Tab)");
		GUI.color = new Color (1, 1, 1, 0);
		if (inventoryOpen) {
			inventoryWindowRect = GUI.Window (0, inventoryWindowRect, MakeWindow, "Inventory");
		}
	}
	
	// Draw items in inventory window.
	void MakeWindow(int windowId) {
		
		GUILayout.BeginArea (new Rect (5, 20, InventoryWidth (), 100));
		GUILayout.BeginHorizontal ();
		
		int numItems = 10;
		
		for (int i = 0; i < numItems; i++) {
			GUILayout.Button ("Item", GUILayout.Height (50), GUILayout.Width (50));
		}
		
		GUILayout.EndHorizontal ();
		GUILayout.EndArea ();
		
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
