using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Description : MonoBehaviour {
	private GameObject Swag;
	private Main main;
	Text buttonText;
	// Use this for initialization
	void Start () {
		buttonText = GetComponent<Text> ();
		Swag = GameObject.Find ("Swag");
		main = Swag.GetComponent<Main> ();
	}
	public void storeUpgradeMsg(string S){
		buttonText.text = "Cost : $" + main.storeUpgradeCost +
			"\n increase customer rate by 2 and fame by 2";
	}
	public void merchandiceUpgradeMsg(string M){
		buttonText.text = "Cost : $" + main.maintaneinceCosts +
			"\n increase price by $1.50 and fame by 2";
	}
	public void advertisementUpgradeMsg( string A){
		buttonText.text = "Cost : $" + main.advertisementCost +
			"\ninccrease fame by " + (main.fame * 2);
	}

}
