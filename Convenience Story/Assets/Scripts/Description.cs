using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Description : MonoBehaviour {
	private GameObject Swag;
	private Main main;
	public Text descriptionText;
	// Use this for initialization
	void Start () {
		Swag = GameObject.Find ("Swag");
		main = Swag.GetComponent<Main> ();
	}
	public void storeUpgradeMsg(string S){
		descriptionText.text = "Cost : $" + main.storeUpgradeCost +
			"\n increase customer rate by 2 and fame by 2";
	}
	public void merchandiceUpgradeMsg(string M){
		descriptionText.text = "Cost : $" + main.maintaneinceCosts +
			"\n increase price by $1.50 and fame by 2";
	}
	public void advertisementUpgradeMsg( string A){
		descriptionText.text = "Cost : $" + main.advertisementCost +
			"\ninccrease fame by " + (main.fame * 2);
	}

}
