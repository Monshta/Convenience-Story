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
		descriptionText.text = "Cost : $" + (Mathf.Round(main.storeUpgradeCost*100)/100) +
			"\n increase customer rate by 2 and fame by "+(Mathf.Round( ((main.fame*1.3f+2)-main.fame)*1)/1);
	}
	public void merchandiceUpgradeMsg(string M){
		descriptionText.text = "Cost : $" + (Mathf.Round(main.merchandiceCost*100)/100) +
					"\n increase price by $1.50 and fame by " + (Mathf.Round(((main.fame*1.3f+1)-main.fame)*1)/1);
	}
	public void advertisementUpgradeMsg( string A){
		descriptionText.text = "Cost : $" + (Mathf.Round(main.advertisementCost*100)/100) +
			"\ninccrease fame to " + (main.fame * 2);
	}

}
