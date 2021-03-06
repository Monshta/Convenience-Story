﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class InformationUI : MonoBehaviour {


	public GameObject cashUI;
	private Main main;
	private GameObject Swag;
	private GameObject Swag2;
	private GameObject Swag4;
	private GameObject Swag5;
	private GameObject swag6;
	Text cashTxt;	
	Text fameTxt;
	Text priceTxt;
	Text levelTxt;
	Text upKeepTxt;
	public static bool loadedUI = false;
	public static bool saveUI = false;
	void Start () {

		Swag = GameObject.Find("Swag");
		main = Swag.GetComponent<Main>();
		cashTxt =  gameObject.GetComponent<Text>();
		Swag2 = GameObject.Find("fameUI");
		fameTxt =  Swag2.GetComponent<Text>();
		Swag4 = GameObject.Find("priceUI");
		priceTxt =  Swag4.GetComponent<Text>();
		Swag5 = GameObject.Find ("storeLevelUI");
		levelTxt = Swag5.GetComponent<Text> ();
		swag6 = GameObject.Find ("upKeepUI");
		upKeepTxt = swag6.GetComponent<Text> ();


	}
	
	void Update () {


		cashTxt.text = "Cash: $" +  (Mathf.Round(main.cash * 100f) / 100f);
		fameTxt.text = "Fame: " + main.fame;//time elapsed
		priceTxt.text = "Price: $" + main.price;// price of materials
		levelTxt.text = "Store Level: " + main.storeUpgradeCounter;// to keep tracj of store levels
		upKeepTxt.text = "Upkeep Cost: " + (Mathf.Round(main.maintaneinceCosts* 100f) / 100f);


}
}
