using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class SelectorManager : MonoBehaviour {// see SelectorFuckingMenu Script
	public SelectorMenu CurrentMenu;

	public void start(){
		showMenu (CurrentMenu);
	}
	public void showMenu(SelectorMenu menu){
		if (CurrentMenu != null)
			CurrentMenu.IsOpen = false;

		CurrentMenu = menu;
		CurrentMenu.IsOpen = true;
	}
}
