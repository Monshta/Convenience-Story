using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class InformationUI : MonoBehaviour {

	public int seconds;
	public int minutes;
	public int hours;
	public float timer;
	public GameObject cashUI;
	private Main main;
	private GameObject Swag;
	private GameObject Swag2;
	private GameObject Swag3;
	private GameObject Swag4;
	private GameObject Swag5;
	private GameObject swag6;
	Text cashTxt;	
	Text fameTxt;
	Text timeTxt;
	Text priceTxt;
	Text levelTxt;
	Text upKeepTxt;

	void Start () {

		Swag = GameObject.Find("Swag");
		main = Swag.GetComponent<Main>();
		cashTxt =  gameObject.GetComponent<Text>();
		Swag2 = GameObject.Find("fameUI");
		fameTxt =  Swag2.GetComponent<Text>();
		Swag3 = GameObject.Find("timeUI");
		timeTxt =  Swag3.GetComponent<Text>();
		Swag4 = GameObject.Find("priceUI");
		priceTxt =  Swag4.GetComponent<Text>();
		Swag5 = GameObject.Find ("storeLevelUI");
		levelTxt = Swag5.GetComponent<Text> ();
		swag6 = GameObject.Find ("upKeepUI");
		upKeepTxt = swag6.GetComponent<Text> ();


	}
	
	void Update () {
		timer += Time.deltaTime;
		seconds = Mathf.FloorToInt (timer);    
		if (seconds > 59) {
			minutes ++;
			timer = 0; 
		}
		if (minutes > 59) {
			hours ++;
			timer = 0;
		}

		cashTxt.text = "Cash: $" +  (Mathf.Round(main.cash * 100f) / 100f);
		fameTxt.text = "Fame: " + main.fame;
		timeTxt.text = "Time Elapsed: "+ hours+":"+minutes+":"+seconds;//time elapsed
		priceTxt.text = "Price: $" + main.price;// price of materials
		levelTxt.text = "Store Level: " + main.storeUpgradeCounter;// to keep tracj of store levels
		upKeepTxt.text = "Upkeep Cost: " + (Mathf.Round(main.maintaneinceCosts* 100f) / 100f);

}
}
