using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	void start(){
	}

	void Update () {
	
	}

	public void newGame(){
		Application.LoadLevel("ConvinientHer");
		Main.newGame = true;
}
	public void loadGame(){
		Application.LoadLevel ("ConvinientHer");
		Main.loadGame = true;
		InformationUI.loadedUI = true;
	}
}
