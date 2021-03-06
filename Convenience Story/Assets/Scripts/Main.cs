﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public class Disaster{
	public float chancesDisaster;
	public Disaster(){
	}
	public int which(){
		chancesDisaster = UnityEngine.Random.Range (0, 10);
		if (chancesDisaster >= 0 && chancesDisaster < 2) {
			return 1;
		}
		if (chancesDisaster >= 2 && chancesDisaster < 4) {
			return 2;
		}
		if (chancesDisaster >= 4 && chancesDisaster < 6) {
			return 3;
		} else 
			return 0;
	}


}
public class Main : MonoBehaviour {
	public bool start = true;
	public float timer = 0.0f;
	public int customerRate = 2;
	public float price = 2f;
	public float cash = 0f;
	public Text cashUI;
	public float maintaneinceCosts;

	public int fame = 5;
	public Text fameUI; 
	public int advertisementCounter = 0;
	public float advertisementCost = 3f;
	public float storeUpgradeCost = 15f;
	public int storeUpgradeCounter = 0;

	public float merchandiceCost = 10f;
	public int merchandiceCounter =0;

	public float eventRobbery= 0;
	public float chancesRobbery;
	public int robberyCounter = 0;

	public float eventDisaster= 0;
	public float chancesDisaster;
	public int disasterCounter = 0;

	public bool fameEvent1 = true;
	public bool fameEvent2 = true;
	public bool fameEvent3 = true;

	public float eventHire = 0;//increases with delta time
	public float chancesHire = 0;
	public int workerCount = 0;
	public GameObject yesBtn;
	public GameObject noBtn;
	public GameObject fireBtn;
	public GameObject okayBtn;

	public String[] randomWorkerNames = new string[31] {"Adam","Eve","Francis","Anthony","Josh","John",//This is the pool of names we will generate
	"Patrick","Patricia","Grace","Rjen","Tristan","Jack","Jill","Andrew","Chris","Kori","Jacob","Edward","Bella",// names from
	"Angel","Ethiopia","Caitlyn","Sharqueesha","Jasmine","Lewis","Antu","Jackie","Megan", "Arnold", "Zach","Cody"};
	public String placeHolderName;//temporarily holds name
	public String [] workerNames = new string[22] {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "};
	public float [] workerCost = new float[22]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};// All of these are placeholders for arrays
	public int [] workerEffect = new int[22]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	public int whichworker;
	public int workerBenifit;
	public float workerPay;

	public GameObject upgradePnl;
	public GameObject selectorPnl;
	public GameObject workerPnl;
	public GameObject buisinessPnl;
	public GameObject alertPnl;

	public GameObject swagText;
	Text descText;
	public bool isDescInUse = false;

	public String [] randomCompanyNames = new String [16]{"Rito Games","Pysical Ent","Ubihard","Nintendont",
	"Jzepol","Sycooyes","Tairy Hesticles","Mushrooms","Chicken Alfredo","Unilevel","Yami STudios","Frantu","Kieth","Faker",
	"Ethernet Cable","Carlos"};
	public String [] buisinessName = new string[13]{" "," "," "," "," "," "," "," "," "," "," "," "," "};
	public float [] buisinessCost = new float[13]{0.0f,0.0f,0.0f,0.0f,0.0f,0.0f,0.0f,0.0f,0.0f,0.0f,0.0f,0.0f,0.0f};
	public int buisinessOfferCount = 0;
	public float eventBuisiness = 0;
	public float buisinessChances = 0;
	public int [] offerType = new int[13]{0,0,0,0,0,0,0,0,0,0,0,0,0}; 
	public float costHolder ;
	public int whichOffer;

	public GameObject swagText2;
	public GameObject swagText3;
	Text buisinessText;
	Text AlertText;
	public float alertTimer;
	public bool alertActive;

	public float buff9Timer;
	public float buff8Timer;
	public float buff7Timer;
	public float buff6Timer;
	public float buff5Timer;
	public float buff4Timer;
	public float buff3Timer;
	public float buff2Timer;
	public float buff1Timer;
	public float eventScam;

	public float fameTimer;
	public GameObject swag6;
	Text upKeepTxt;
	public float saveTime;

	public float realTime;
	public static bool newGame = false;
	public static bool loadGame = false;
	public float overTimer;

	public int seconds;
	public int minutes;
	public int hours;
	public float gametimer;
	private GameObject Swag3;
	Text timeTxt;
    public int highscore;

	 void Start () {

		yesBtn = GameObject.Find ("yesButton");
		noBtn = GameObject.Find ("noButton");
		fireBtn = GameObject.Find ("fireButton");
		okayBtn = GameObject.Find ("okayButton");
		selectorPnl = GameObject.Find ("SelectorPanel");
		upgradePnl = GameObject.Find ("UpgradePanel");
		workerPnl = GameObject.Find ("WorkerPanel"); 
		buisinessPnl = GameObject.Find ("BuisinessPanel");
		alertPnl = GameObject.Find ("AlertPanel");
		swagText = GameObject.Find ("descriptionText");
		descText = swagText.GetComponent<Text> ();
		buisinessText = swagText2.GetComponent<Text> ();
		swagText = GameObject.Find ("BuisinessTxt");
		swagText3 = GameObject.Find ("AlertTxt");
		AlertText = swagText3.GetComponent<Text> ();
		Swag3 = GameObject.Find("timeUI");
		timeTxt =  Swag3.GetComponent<Text>();

	}
	

	void Update () {
		if(loadGame == true){
			fame = PlayerPrefs.GetInt ("fame");
			cash = PlayerPrefs.GetFloat ("cash");
			customerRate = PlayerPrefs.GetInt("customerRate");
			price= PlayerPrefs.GetFloat ("price");
			advertisementCost = PlayerPrefs.GetFloat ("advertisementCost");
			storeUpgradeCost = PlayerPrefs.GetFloat ("storeupgradeCost");
			merchandiceCost = PlayerPrefs.GetFloat ("merchandiceUpgradeCost");
			workerCount = PlayerPrefs.GetInt ("workerCount");
			realTime = PlayerPrefs.GetFloat ("RealTime");
			seconds = PlayerPrefs.GetInt ("seconds");
			minutes = PlayerPrefs.GetInt ("minutes");
			hours = PlayerPrefs.GetInt ("hours");
			gametimer = PlayerPrefs.GetFloat ("gametimer");

			
			workerNames [0] = PlayerPrefs.GetString ("workerName1");
			workerCost [0] = PlayerPrefs.GetFloat ("workerCost1");
			workerEffect[0] = PlayerPrefs.GetInt("workerEffect1");
			workerNames[1] = PlayerPrefs.GetString ("workerName2");
			workerCost [1] = PlayerPrefs.GetFloat ("workerCost2");
			workerEffect[1] = PlayerPrefs.GetInt("workerEffect2");
			workerNames[2] = PlayerPrefs.GetString ("workerName3");
			workerCost [2] = PlayerPrefs.GetFloat ("workerCost3");
			workerEffect[2] = PlayerPrefs.GetInt("workerEffect3");
			workerNames[3] = PlayerPrefs.GetString ("workerName4");
			workerCost [3] = PlayerPrefs.GetFloat ("workerCost4");
			workerEffect[3] = PlayerPrefs.GetInt("workerEffect4");
			workerNames [4] = PlayerPrefs.GetString ("workerName5");
			workerCost [4] = PlayerPrefs.GetFloat ("workerCost5");
			workerEffect[4] = PlayerPrefs.GetInt("workerEffect5");
			workerNames[5] = PlayerPrefs.GetString ("workerName6");
			workerCost [5] = PlayerPrefs.GetFloat ("workerCost6");
			workerEffect[5] = PlayerPrefs.GetInt("workerEffect6");
			workerNames[6] = PlayerPrefs.GetString ("workerName7");
			workerCost [6] = PlayerPrefs.GetFloat ("workerCost7");
			workerEffect[6] = PlayerPrefs.GetInt("workerEffect7");
			workerNames[7] = PlayerPrefs.GetString ("workerName8");
			workerCost [7] = PlayerPrefs.GetFloat ("workerCost8");
			workerEffect[7] = PlayerPrefs.GetInt("workerEffect8");
			workerNames [8] = PlayerPrefs.GetString ("workerName9");
			workerCost [8] = PlayerPrefs.GetFloat ("workerCost9");
			workerEffect[8] = PlayerPrefs.GetInt("workerEffect9");
			workerNames[9] = PlayerPrefs.GetString ("workerName10");
			workerCost [9] = PlayerPrefs.GetFloat ("workerCost10");
			workerEffect[9] = PlayerPrefs.GetInt("workerEffect10");
			workerNames[10] = PlayerPrefs.GetString ("workerName11");
			workerCost [10] = PlayerPrefs.GetFloat ("workerCost11");
			workerEffect[10] = PlayerPrefs.GetInt("workerEffect11");
			workerNames[11] = PlayerPrefs.GetString ("workerName12");
			workerCost [11] = PlayerPrefs.GetFloat ("workerCost12");
			workerEffect[11] = PlayerPrefs.GetInt("workerEffect12");
			workerNames [12] = PlayerPrefs.GetString ("workerName13");
			workerCost [12] = PlayerPrefs.GetFloat ("workerCost13");
			workerEffect[12] = PlayerPrefs.GetInt("workerEffect13");
			workerNames[13] = PlayerPrefs.GetString ("workerName14");
			workerCost [13] = PlayerPrefs.GetFloat ("workerCost14");
			workerEffect[13] = PlayerPrefs.GetInt("workerEffect14");
			workerNames[14] = PlayerPrefs.GetString ("workerName15");
			workerCost [14] = PlayerPrefs.GetFloat ("workerCost15");
			workerEffect[14] = PlayerPrefs.GetInt("workerEffect15");
			workerNames[15] = PlayerPrefs.GetString ("workerName16");
			workerCost [15] = PlayerPrefs.GetFloat ("workerCost16");
			workerEffect[15] = PlayerPrefs.GetInt("workerEffect16");
			workerNames[16] = PlayerPrefs.GetString ("workerName17");
			workerCost [16] = PlayerPrefs.GetFloat ("workerCost17");
			workerEffect[16] = PlayerPrefs.GetInt("workerEffect17");
			workerNames [17] = PlayerPrefs.GetString ("workerName18");
			workerCost [17] = PlayerPrefs.GetFloat ("workerCost18");
			workerEffect[17] = PlayerPrefs.GetInt("workerEffect18");
			workerNames[18] = PlayerPrefs.GetString ("workerName19");
			workerCost [18] = PlayerPrefs.GetFloat ("workerCost19");
			workerEffect[18] = PlayerPrefs.GetInt("workerEffect19");
			workerNames[19] = PlayerPrefs.GetString ("workerName20");
			workerCost [19] = PlayerPrefs.GetFloat ("workerCost20");
			workerEffect[19] = PlayerPrefs.GetInt("workerEffect20");
			
			buisinessName [0] = PlayerPrefs.GetString ("offername1");
			offerType [0] = PlayerPrefs.GetInt ("offertype1");
			buisinessCost [0] = PlayerPrefs.GetFloat ("offercost1");
			buisinessName [1] = PlayerPrefs.GetString ("offername2");
			offerType [1] = PlayerPrefs.GetInt ("offertype2");
			buisinessCost [1] = PlayerPrefs.GetFloat ("offercost2");
			buisinessName [2] = PlayerPrefs.GetString ("offername3");
			offerType [2] = PlayerPrefs.GetInt ("offertype3");
			buisinessCost [2] = PlayerPrefs.GetFloat ("offercost3");
			buisinessName [3] = PlayerPrefs.GetString ("offername4");
			offerType [3] = PlayerPrefs.GetInt ("offertype4");
			buisinessCost [3] = PlayerPrefs.GetFloat ("offercost4");
			buisinessName [4] = PlayerPrefs.GetString ("offername5");
			offerType [4] = PlayerPrefs.GetInt ("offertype5");
			buisinessCost [4] = PlayerPrefs.GetFloat ("offercost5");
			buisinessName [5] = PlayerPrefs.GetString ("offername6");
			offerType [5] = PlayerPrefs.GetInt ("offertype6");
			buisinessCost [5] = PlayerPrefs.GetFloat ("offercost6");
			buisinessName [6] = PlayerPrefs.GetString ("offername7");
			offerType [6] = PlayerPrefs.GetInt ("offertype7");
			buisinessCost [6] = PlayerPrefs.GetFloat ("offercost7");
			buisinessName [7] = PlayerPrefs.GetString ("offername8");
			offerType [7] = PlayerPrefs.GetInt ("offertype8");
			buisinessCost [7] = PlayerPrefs.GetFloat ("offercost8");
			loadGame = false;
			Time.timeScale = 1;
		}
        if (highscore < fame)
        {
            highscore = fame;
        }

		saveTime += Time.deltaTime;
		if (saveTime > 60) {
			saveGame();
		}
		gametimer += Time.deltaTime;
		seconds = Mathf.FloorToInt (gametimer);    
		if (seconds > 59) {
			minutes ++;
			gametimer = 0; 
		}
		if (minutes > 59) {
			hours ++;
			gametimer = 0;
		}
		timeTxt.text = "Time Elapsed: "+ hours+":"+minutes+":"+seconds;
		realTime += Time.deltaTime;
		if (cash < -100) {
			overTimer +=Time.deltaTime;
			if(timer > 5){
			alertPnl.SetActive(true);
			AlertText.text = "GAME OVER!";
			Time.timeScale = 0;
			}
		}
		if (fame > 6) {
			maintaneinceCosts = ((fame * 1.3f) - 8.0f);
		}
		if (fame < 1) {
			fame = 1;
		}
		if (customerRate < 1) {
			customerRate = 1;
		}
		if (price < 1) {
			price = 1;
		}
		if (start == true) {
			yesBtn.SetActive (false);
			noBtn.SetActive (false);
			fireBtn.SetActive (false);
			okayBtn.SetActive (false);
			upgradePnl.SetActive (false);
			workerPnl.SetActive (false);
			buisinessPnl.SetActive (false);
			swagText.SetActive (false);
			start = false;
			alertPnl.SetActive (false);
			alertActive = false;
			Time.timeScale = 1;
		
		}

		if (alertActive) {
			alertTimer += Time.deltaTime;
			if(alertTimer > 10){
				alertPnl.SetActive(false);
				alertActive = false;
				alertTimer = 0;
			}
		}

		workerBenifit = (workerEffect [0] + workerEffect [1] + workerEffect [2] + workerEffect [3] + workerEffect [4] + 
			workerEffect [5] + workerEffect [6] + workerEffect [7] + workerEffect [8] + workerEffect [9] + 
			workerEffect [10] + workerEffect [11] + workerEffect [12] + workerEffect [13] + workerEffect [14] + 
			workerEffect [15] + workerEffect [16] + workerEffect [17] + workerEffect [18] + workerEffect [19] + workerEffect [20]);

		workerPay = (workerCost [0] + workerCost [1] + workerCost [2] + workerCost [3] + workerCost [4] + workerCost [5] +
			workerCost [6] + workerCost [7] + workerCost [8] + workerCost [9] + workerCost [10] + workerCost [11] +
			workerCost [12] + workerCost [13] + workerCost [14] + workerCost [15] + workerCost [16] + workerCost [17] +
			workerCost [18] + workerCost [19] + workerCost [20]);

		if (customerRate >= 1) {
			eventBuisiness += Time.deltaTime;
			timer += Time.deltaTime;
			fameTimer += Time.deltaTime;
			if(!isDescInUse){
			eventHire += Time.deltaTime;
			}
		}
		if (fameTimer > 20) {
			if(cash >0){
			fame +=1;
			advertisementCost=(fame* 3);
			fameTimer = 0.0f;
			}
			if(cash <0){
				fame -=1;
				advertisementCost=(fame* 3);
				fameTimer = 0.0f;
			}
			if( cash > 30){
				fame+=  1;
			}
			if(cash > 80){
				fame += 1;
			}
			if(cash > 150){
				fame +=1;
			}
			if(cash > 300){
				fame +=1;
			}
		}
		if (timer > 10) {//transactions happen every 10s
			cash += (price * customerRate);
			timer = 0.0f;
			cash -= workerPay;
			cash += workerBenifit;
			cash -= maintaneinceCosts;
		}

		if (fame > 50 && fame < 100 && (fameEvent1 == true)) {// these are events that happen
			customerRate += 1;//when fame goes up, i call them fameEvents
			fameEvent1 = false;// we can add some more stuff here but idk what to add so yeah kbye.
		}
		if (fame > 100 && fame < 200 && (fameEvent2 == true)) {
			customerRate += 1;
			fameEvent2 = false;
		}
		if (fame > 200 && fame < 300 && (fameEvent3 == true)) {
			customerRate += 1;
			fameEvent3 = false;
		}


		if (fame < 50) {//robbery with fame; if you can find a better method tellith me
			eventRobbery += Time.deltaTime;
			eventDisaster += Time.deltaTime;
		}
		if (fame > 50 && fame < 200) {
			eventRobbery = eventRobbery + (Time.deltaTime * 1.5f);
			eventDisaster += (Time.deltaTime*1.5f);
		}
		if (fame > 200) {
			eventDisaster += (Time.deltaTime*2.0f);
			eventRobbery = eventRobbery + (Time.deltaTime * 2.0f);
		}

		if (eventDisaster > 77) {
			chancesDisaster = UnityEngine.Random.Range (0, 100);
			Disaster distaster = new Disaster();
			if (distaster.which() == 1) { 
				merchandiceCounter--;		//this is a earthquake
				price -= 1;					// it ruins the merchandise
				disasterCounter++;
				alertPnl.SetActive(true);
				alertActive = true;
				AlertText.text = "EARTHQUAKE!";
				cash -= (float)(fame*1.5+ 10.0f);
			}
			if (distaster.which () == 2) {  //i wana put a volcano here
				disasterCounter++;	
				for(int i = 0; i< 8; i++){
					buisinessName[i] = " ";
					buisinessCost[i] = 0.0f;
					offerType[i] = 0;
				}
				buisinessOfferCount = 0;
				alertPnl.SetActive(true);
				alertActive = true;
				AlertText.text = "You just got melted by a volcano";// but we havnt figured out the
				cash -= (float)(fame*1.5+ 10.0f);
			}	
			if(distaster.which() == 3){
				customerRate -= 1;
				alertPnl.SetActive(true);
				alertActive = true;
				AlertText.text = "You got washed by a tsunami";
				cash -= (float)(fame*1.5+10.0f);
			}// other mechanics
			eventDisaster = 0;	

			//Disasters need rely on fame, they got no chill
		}
		if (eventRobbery > 73 && cash > 1) {
			chancesRobbery = UnityEngine.Random.Range (0,100);
			if(chancesRobbery > 0	&&	chancesRobbery < 50){
				cash = cash - (cash * 0.50f);
				robberyCounter ++;
				alertPnl.SetActive(true);
				alertActive = true;
				AlertText.text = "You just got robbed";
			}
			eventRobbery = 0;
		}
		if (eventHire > 51 && workerCount<51) {//Temporary condition to check stuff
			chancesHire = UnityEngine.Random.Range ( 0, 100);
			if(chancesHire > 0 && chancesHire < 41){
			placeHolderName = randomWorkerNames[(int)UnityEngine.Random.Range(0,30)];
			swagText.SetActive (true);
			descText.text = "Would you like to hire " + placeHolderName + "?";
			yesBtn.SetActive(true);
			noBtn.SetActive(true);
			okayBtn.SetActive(false);
			fireBtn.SetActive(false);
			isDescInUse = true;
			}
			eventHire = 0;
		}
		if (eventBuisiness >91  && buisinessOfferCount < 8 && cash > 2) {
			if(offerType[buisinessOfferCount] == 0){
				alertPnl.SetActive(false);
				alertActive = false;
			}
			buisinessChances = UnityEngine.Random.Range(0,100);
			if(buisinessChances > 0 && buisinessChances < 20){
				buisinessName[buisinessOfferCount] = randomCompanyNames[(int)UnityEngine.Random.Range(0,15)];
				buisinessCost[buisinessOfferCount] = (Mathf.Round(UnityEngine.Random.Range ((cash*0.7f), (cash*0.8f))*100)/100);
				offerType[buisinessOfferCount] = 1;
				buisinessOfferCount++;
				alertPnl.SetActive(true);
				alertActive = true;
				AlertText.text = "You just got a buisiness offer";
			}
			if(buisinessChances > 40 && buisinessChances < 60){
				buisinessName[buisinessOfferCount] = randomCompanyNames[(int)UnityEngine.Random.Range(0,15)];
				buisinessCost[buisinessOfferCount] = (Mathf.Round((UnityEngine.Random.Range (cash*0.7f, cash*0.8f))*100)/100);
				offerType[buisinessOfferCount] = 2;
				buisinessOfferCount++;
				alertPnl.SetActive(true);
				alertActive = true;
				AlertText.text = "You just got a buisiness offer";
			}
			if(buisinessChances > 60 && buisinessChances < 80){
				buisinessName[buisinessOfferCount] = randomCompanyNames[(int)UnityEngine.Random.Range(0,15)];
				buisinessCost[buisinessOfferCount] = (Mathf.Round((UnityEngine.Random.Range (cash*0.7f, cash*0.8f))*100)/100);
				offerType[buisinessOfferCount] = 3;
				buisinessOfferCount++;
				alertPnl.SetActive(true);
				alertActive = true;
				AlertText.text = "You just got a buisiness offer";
			}


			eventBuisiness = 0;

		}
	}


	public void storeUpgrade(){// basic shit y'know how it goes fam
		if (storeUpgradeCost < cash) {
			customerRate+= 2;
			cash-=storeUpgradeCost;
			storeUpgradeCost=(storeUpgradeCost*1.5f) +Mathf.Abs(cash*0.5f);
			storeUpgradeCounter++;
			fame = (int)(fame*1.3)+2;
		}
	}
	public void merchandiceUpgrade(){
		if (merchandiceCost < cash) {
			price += 1.5f;
			cash -= merchandiceCost;
			merchandiceCost=merchandiceCost*1.5f + Mathf.Abs (cash*0.5f);
			merchandiceCounter++;
			fame = (int)(fame*1.3)+1;
				}
			}
	public void advertisementUpgrade(){// fame upgrade
		if (advertisementCost < cash) {
			fame =(int)(fame*2);
			cash -= advertisementCost;
			advertisementCounter++;
		}
	}
	public void yesButton(){// yes button functionality
		yesBtn.SetActive (false);
		noBtn.SetActive (false);
		newWorker ();
		descText.text = " ";
		isDescInUse = false;
	}
	public void newWorker(){// setting up the workers
		workerNames [workerCount] = placeHolderName;
		workerCost [workerCount] = UnityEngine.Random.Range (fame*7/7, fame *13/7);
		workerEffect [workerCount] = (int)UnityEngine.Random.Range (fame* 14/7, fame + 15/7);
		workerCount ++;
	}
	public void noButton(){
		yesBtn.SetActive (false);
		noBtn.SetActive (false);
		isDescInUse = false;
		descText.text = " ";
	}
	public void fireButton(){// to fire the workers, itll be set active when the user clicks on a worker
		workerCost [20] = 0;
		workerEffect [20] = 0;
		workerNames [20] = " ";
		workerCost [whichworker] = -1;
		for (int i = 0; i<21; i++) {
			if(workerCost[i] == -1){
				for (int j = i; j < (20-j);j++){
					workerCost[j] = workerCost[j+1];
					workerEffect[j] = workerEffect[j+1];
					workerNames[j] = workerNames[j+1];
				}
			}
		}
		descText.text = " ";
		workerCount --;
		fireBtn.SetActive (false);
		okayBtn.SetActive (false);
		isDescInUse = false;
	}
	public void toUpgradePanel(){
		selectorPnl.SetActive (false);
		upgradePnl.SetActive (true);
	}
	public void backButton(){
		selectorPnl.SetActive (true);
		upgradePnl.SetActive (false);
		workerPnl.SetActive (false);
		buisinessPnl.SetActive (false);
	}
	public void toWorkerPanel(){
		workerPnl.SetActive (true);
		selectorPnl.SetActive (false);
	}
	public void okayButton(){
		descText.text = " ";
		okayBtn.SetActive (false);
		fireBtn.SetActive (false);
		isDescInUse = false;
	}
	public void w1(){
		if (workerEffect [0] != 0) {
		whichworker = 0;
		descText.text = "Name: " + workerNames[0] + "\n Cost for worker: " +workerCost[0]+ "\n" +
			"Worker help raises : "+ workerEffect[0];
			fireBtn.SetActive (true);
			okayBtn.SetActive (true);
			isDescInUse = true;
			yesBtn.SetActive(false);
			noBtn.SetActive(false);
		}
		else{
			descText.text = " ";
			isDescInUse = false;
			fireBtn.SetActive (false);
			okayBtn.SetActive (false);
		}
	}
	public void w2(){
		if (workerEffect [1] != 0) {
			whichworker = 1;
			descText.text = "Name: " + workerNames[1] + "\n Cost for worker: " +workerCost[1]+ "\n" +
				"Worker help raises : "+ workerEffect[1];
			fireBtn.SetActive (true);
			okayBtn.SetActive (true);
			isDescInUse = true;
			yesBtn.SetActive(false);
			noBtn.SetActive(false);
		}
		else{
			descText.text = " ";
			isDescInUse = false;
			fireBtn.SetActive (false);
			okayBtn.SetActive (false);
		}
	}
	public void w3(){
		if (workerEffect [2] != 0) {
			whichworker = 2;
			descText.text = "Name: " + workerNames[2] + "\n Cost for worker: " +workerCost[2]+ "\n" +
				"Worker help raises : "+ workerEffect[2];
			fireBtn.SetActive (true);
			okayBtn.SetActive (true);
			isDescInUse = true;
			yesBtn.SetActive(false);
			noBtn.SetActive(false);
		}
		else{
			descText.text = " ";
			isDescInUse = false;
			fireBtn.SetActive (false);
			okayBtn.SetActive (false);
		}
	}
	public void w4(){
		if (workerEffect [3] != 0) {
			whichworker = 3;
			descText.text = "Name: " + workerNames[3] + "\n Cost for worker: " +workerCost[3]+ "\n" +
				"Worker help raises : "+ workerEffect[3];
			fireBtn.SetActive (true);
			okayBtn.SetActive (true);
			isDescInUse = true;
			yesBtn.SetActive(false);
			noBtn.SetActive(false);
		}
		else{
			descText.text = " ";
			isDescInUse = false;
			fireBtn.SetActive (false);
			okayBtn.SetActive (false);
		}
	}
	public void w5(){
		if (workerEffect [4] != 0) {
			whichworker = 4;
			descText.text = "Name: " + workerNames[4] + "\n Cost for worker: " +workerCost[4]+ "\n" +
				"Worker help raises :  "+ workerEffect[4];
			fireBtn.SetActive (true);
			okayBtn.SetActive (true);
			isDescInUse = true;
			yesBtn.SetActive(false);
			noBtn.SetActive(false);
		}
		else{
			descText.text = " ";
			isDescInUse = false;
			fireBtn.SetActive (false);
			okayBtn.SetActive (false);
		}
	}
	public void w6(){
		if (workerEffect [5] != 0) {
			whichworker = 5;
			descText.text = "Name: " + workerNames[5] + "\n Cost for worker: " +workerCost[5]+ "\n" +
				"Worker help raises : "+ workerEffect[5];
			fireBtn.SetActive (true);
			okayBtn.SetActive (true);
			isDescInUse = true;
			yesBtn.SetActive(false);
			noBtn.SetActive(false);
		}
		else{
			descText.text = " ";
			isDescInUse = false;
			fireBtn.SetActive (false);
			okayBtn.SetActive (false);
		}
	}
	public void w7(){
		if (workerEffect [6] != 0) {
			whichworker = 6;
			descText.text = "Name: " + workerNames[6] + "\n Cost for worker: " +workerCost[6]+ "\n" +
				"Worker help raises : "+ workerEffect[6];
			fireBtn.SetActive (true);
			okayBtn.SetActive (true);
			isDescInUse = true;
			yesBtn.SetActive(false);
			noBtn.SetActive(false);
		}
		else{
			descText.text = " ";
			isDescInUse = false;
			fireBtn.SetActive (false);
			okayBtn.SetActive (false);
		}
	}
	public void w8(){
		if (workerEffect [7] != 0) {
			whichworker = 7;
			descText.text = "Name: " + workerNames[7] + "\n Cost for worker: " +workerCost[7]+ "\n" +
				"Worker help raises :  "+ workerEffect[7];
			fireBtn.SetActive (true);
			okayBtn.SetActive (true);
			isDescInUse = true;
			yesBtn.SetActive(false);
			noBtn.SetActive(false);
		}
		else{
			descText.text = " ";
			isDescInUse = false;
			fireBtn.SetActive (false);
			okayBtn.SetActive (false);
		}
	}
	public void w9(){
		if (workerEffect [8] != 0) {
			whichworker = 8;
			descText.text = "Name: " + workerNames[8] + "\n Cost for worker: " +workerCost[8]+ "\n" +
				"Worker help raises : "+ workerEffect[8];
			fireBtn.SetActive (true);
			okayBtn.SetActive (true);
			isDescInUse = true;
			yesBtn.SetActive(false);
			noBtn.SetActive(false);
		}
		else{
			descText.text = " ";
			isDescInUse = false;
			fireBtn.SetActive (false);
			okayBtn.SetActive (false);
		}
	}
	public void w10(){
		if (workerEffect [9] != 0) {
			whichworker = 9;
			descText.text = "Name: " + workerNames[9] + "\n Cost for worker: " +workerCost[9]+ "\n" +
				"Worker help raises : "+ workerEffect[9];
			fireBtn.SetActive (true);
			okayBtn.SetActive (true);
			isDescInUse = true;
			yesBtn.SetActive(false);
			noBtn.SetActive(false);
		}
		else{
			descText.text = " ";
			isDescInUse = false;
			fireBtn.SetActive (false);
			okayBtn.SetActive (false);
		}
	}
	public void w11(){
		if (workerEffect [10] != 0) {
			whichworker = 10;
			descText.text = "Name: " + workerNames[10] + "\n Cost for worker: " +workerCost[10]+ "\n" +
				"Worker help raises : "+ workerEffect[10];
			fireBtn.SetActive (true);
			okayBtn.SetActive (true);
			isDescInUse = true;
			yesBtn.SetActive(false);
			noBtn.SetActive(false);
		}
		else{
			descText.text = " ";
			isDescInUse = false;
			fireBtn.SetActive (false);
			okayBtn.SetActive (false);
		}
	}
	public void w12(){
		if (workerEffect [11] != 0) {
			whichworker = 11;
			descText.text = "Name: " + workerNames[11] + "\n Cost for worker: " +workerCost[11]+ "\n" +
				"Worker help raises : "+ workerEffect[11];
			fireBtn.SetActive (true);
			okayBtn.SetActive (true);
			isDescInUse = true;
			yesBtn.SetActive(false);
			noBtn.SetActive(false);
		}
		else{
			descText.text = " ";
			isDescInUse = false;
			fireBtn.SetActive (false);
			okayBtn.SetActive (false);
		}
	}
	public void w13(){
		if (workerEffect [12] != 0) {
			whichworker = 12;
			descText.text = "Name: " + workerNames[12] + "\n Cost for worker: " +workerCost[12]+ "\n" +
				"Worker help raises :  "+ workerEffect[12];
			fireBtn.SetActive (true);
			okayBtn.SetActive (true);
			isDescInUse = true;
			yesBtn.SetActive(false);
			noBtn.SetActive(false);
		}
		else{
			descText.text = " ";
			isDescInUse = false;
			fireBtn.SetActive (false);
			okayBtn.SetActive (false);
		}
	}
	public void w14(){
		if (workerEffect [13] != 0) {
			whichworker = 13;
			descText.text = "Name: " + workerNames[13] + "\n Cost for worker: " +workerCost[13]+ "\n" +
				"Worker help raises : "+ workerEffect[13];
			fireBtn.SetActive (true);
			okayBtn.SetActive (true);
			isDescInUse = true;
			yesBtn.SetActive(false);
			noBtn.SetActive(false);
		}
		else{
			descText.text = " ";
			isDescInUse = false;
			fireBtn.SetActive (false);
			okayBtn.SetActive (false);
		}
	}
	public void w15(){
		if (workerEffect [14] != 0) {
			whichworker = 14;
			descText.text = "Name: " + workerNames[14] + "\n Cost for worker: " +workerCost[14]+ "\n" +
				"Worker help raises : "+ workerEffect[14];
			fireBtn.SetActive (true);
			okayBtn.SetActive (true);
			isDescInUse = true;
			yesBtn.SetActive(false);
			noBtn.SetActive(false);
		}
		else{
			descText.text = " ";
			isDescInUse = false;
			fireBtn.SetActive (false);
			okayBtn.SetActive (false);
		}
	}
	public void w16(){
		if (workerEffect [15] != 0) {
			whichworker = 15;
			descText.text = "Name: " + workerNames[15] + "\n Cost for worker: " +workerCost[15]+ "\n" +
				"Worker help raises : "+ workerEffect[15];
			fireBtn.SetActive (true);
			okayBtn.SetActive (true);
			isDescInUse = true;
			yesBtn.SetActive(false);
			noBtn.SetActive(false);
		}
		else{
			descText.text = " ";
			isDescInUse = false;
			fireBtn.SetActive (false);
			okayBtn.SetActive (false);
		}
	}
	public void w17(){
		if (workerEffect [16] != 0) {
			whichworker = 16;
			descText.text = "Name: " + workerNames[16] + "\n Cost for worker: " +workerCost[16]+ "\n" +
				"Worker help raises : "+ workerEffect[16];
			fireBtn.SetActive (true);
			okayBtn.SetActive (true);
			isDescInUse = true;
			yesBtn.SetActive(false);
			noBtn.SetActive(false);
		}
		else{
			descText.text = " ";
			isDescInUse = false;
			fireBtn.SetActive (false);
			okayBtn.SetActive (false);
		}
	}
	public void w18(){
		if (workerEffect [17] != 0) {
			whichworker = 17;
			descText.text = "Name: " + workerNames[17] + "\n Cost for worker: " +workerCost[17]+ "\n" +
				"Worker help raises : "+ workerEffect[17];
			fireBtn.SetActive (true);
			okayBtn.SetActive (true);
			isDescInUse = true;
			yesBtn.SetActive(false);
			noBtn.SetActive(false);
		}
		else{
			descText.text = " ";
			isDescInUse = false;
			fireBtn.SetActive (false);
			okayBtn.SetActive (false);
		}
	}
	public void w19(){
		if (workerEffect [18] != 0) {
			whichworker = 18;
			descText.text = "Name: " + workerNames[18] + "\n Cost for worker: " +workerCost[18]+ "\n" +
				"Worker help raises :  "+ workerEffect[18];
			fireBtn.SetActive (true);
			okayBtn.SetActive (true);
			isDescInUse = true;
			yesBtn.SetActive(false);
			noBtn.SetActive(false);
		}
		else{
			descText.text = " ";
			isDescInUse = false;
			fireBtn.SetActive (false);
			okayBtn.SetActive (false);
		}
	}
	public void w20(){
		if (workerEffect [19] != 0) {
			whichworker = 19;
			descText.text = "Name: " + workerNames [19] + "\n Cost for worker: " + workerCost [19] + "\n" +
				"Worker help raises : " + workerEffect [19];
			fireBtn.SetActive (true);
			okayBtn.SetActive (true);
			isDescInUse = true;
			yesBtn.SetActive (false);
			noBtn.SetActive (false);
		}
		else{
			descText.text = " ";
			isDescInUse = false;
			fireBtn.SetActive (false);
			okayBtn.SetActive (false);
			}
		
	}
	public void offer1(){
		if (offerType [0] == 1) {
			buisinessText.text = "Hello Buisiness owner, we here at "+ buisinessName[0]+
				" would like to send you an offer to raise your customaer rate for " +
				buisinessCost[0] + "Thank you sire";
			whichOffer = 0;

		}
		if (offerType [0] == 2) {
			buisinessText.text = "Hello Buisiness owner, we here at "+ buisinessName[0]+
				" ewould like to send you an offer to raise your merchandice quality for " +
					buisinessCost[0] + "Thank you sire";
			whichOffer = 0;
			
		}
		if (offerType [0] == 3) {
			buisinessText.text = "Hello Buisiness owner, we here at "+ buisinessName[0]+
				" would like to send you an offer protect you from robery for " +
					buisinessCost[0] + "Thank you sire";
			whichOffer = 0;
			
		}
		if (offerType [0] == 0) {
			buisinessText.text = " ";
		}
	}
	public void acceptBtn(){
				if (offerType [whichOffer] == 1) {
					if (cash > buisinessCost [whichOffer]) {
						cash -= buisinessCost [whichOffer];
						buff9Timer += Time.deltaTime;
						customerRate = (int)(customerRate * 3 / 2);
						if (buff9Timer > 30) {
							customerRate = (int)(customerRate * 2 / 3);
						}
					}
				}
				if (offerType [whichOffer] == 2) {
					if (cash > buisinessCost [whichOffer]) {
						cash -= buisinessCost [whichOffer];
						buff9Timer += Time.deltaTime;
						price = (price * 3 / 2);
						if (buff9Timer > 30) {
							price = (price * 2 / 3);
						}
					
					}
				}
				if (offerType [whichOffer] == 3) {
					if (cash > buisinessCost [whichOffer]) {
						cash -= buisinessCost [whichOffer];
						;
						buff9Timer += Time.deltaTime;
							eventRobbery = 0;
						}
						
					}
				
		buisinessName [8] = " ";
		buisinessCost [8] = 0.0f;
		offerType [8] = 0;
		offerType [whichOffer] = -1;
		for (int i = 0; i<8; i++) {
			if (offerType [i] == -1) {
				for (int j = i; j <=(8-j); j++) {
					buisinessCost [j] = buisinessCost [j + 1];
					buisinessName [j] = buisinessName [j + 1];
					offerType[j] = offerType[j+1];
					buisinessText.text = " ";
				}
				buisinessOfferCount--;
			}
		}
}
			
			

		
	
	
	
public void declineButton(){
		buisinessName [8] = " ";
		buisinessCost [8] = 0.0f;
		offerType [8] = 0;
		offerType [whichOffer] = -1;
		for (int i = 0; i<8; i++) {
			if (offerType [i] == -1) {
				for (int j = i; j <=(8-j); j++) {
					buisinessCost [j] = buisinessCost [j + 1];
					buisinessName [j] = buisinessName [j + 1];
					offerType[j] = offerType[j+1];
					buisinessText.text = " ";
				}
				buisinessOfferCount--;
			}
		}
	}
	public void toBuisinessPnl(){
		buisinessPnl.SetActive (true);
		selectorPnl.SetActive (false);
	}
	public void offer2(){
		if (offerType [1] == 1) {
			buisinessText.text = "Hello Buisiness owner, we here at "+ buisinessName[1]+
				" would like to send you an offer to raise your customaer rate for " +
					buisinessCost[1] + "Thank you sire";
			whichOffer = 1;
			
		}
		if (offerType [1] == 2) {
			buisinessText.text = "Hello Buisiness owner, we here at "+ buisinessName[1]+
				" would like to send you an offer to raise your merchandice quality for " +
					buisinessCost[1] + "Thank you sire";
			whichOffer = 1;
		}
		if (offerType [1] == 3) {
			buisinessText.text = "Hello Buisiness owner, we here at "+ buisinessName[1]+
				" would like to send you an offer protect you from robery for " +
					buisinessCost[1] + "Thank you sire";
			whichOffer = 1;
			}
		if (offerType [1] == 0) {
			buisinessText.text = " ";
		}
	}
	public void offer3(){
		if (offerType [2] == 1) {
			buisinessText.text = "Hello Buisiness owner, we here at "+ buisinessName[2]+
				" would like to send you an offer to raise your customaer rate for " +
					buisinessCost[2] + "Thank you sire";
			whichOffer = 2;
			
		}
		if (offerType [2] == 2) {
			buisinessText.text = "Hello Buisiness owner, we here at "+ buisinessName[2]+
				" would like to send you an offer to raise your merchandice quality for " +
					buisinessCost[2] + "Thank you sire";
			whichOffer = 2;
		}
		if (offerType [2] == 3) {
			buisinessText.text = "Hello Buisiness owner, we here at "+ buisinessName[2]+
				" would like to send you an offer protect you from robery for " +
					buisinessCost[2] + "Thank you sire";
			whichOffer = 2;
			
		}
		if (offerType [2] == 0) {
			buisinessText.text = " ";
		}
	}
	public void offer4(){
		if (offerType [3] == 1) {
			buisinessText.text = "Hello Buisiness owner, we here at " + buisinessName [3] +
				" would like to send you an offer to raise your customaer rate for " +
				buisinessCost [3] + "Thank you sire";
			whichOffer = 3;
			
		}
		if (offerType [3] == 2) {
			buisinessText.text = "Hello Buisiness owner, we here at " + buisinessName [3] +
				" would like to send you an offer to raise your merchandice quality for " +
				buisinessCost [3] + "Thank you sire";
			whichOffer = 3;
		}
		if (offerType [3] == 3) {
			buisinessText.text = "Hello Buisiness owner, we here at " + buisinessName [3] +
				" would like to send you an offer protect you from robery for " +
				buisinessCost [3] + "Thank you sire";
			whichOffer = 3;
			
		}
		if (offerType [3] == 0) {
			buisinessText.text = " ";
		}
	}
		public void offer5(){
			if (offerType [4] == 1) {
				buisinessText.text = "Hello Buisiness owner, we here at "+ buisinessName[4]+
					" would like to send you an offer to raise your customaer rate for " +
						buisinessCost[4] + "Thank you sire";
				whichOffer = 4;
				
			}
			if (offerType [4] == 2) {
				buisinessText.text = "Hello Buisiness owner, we here at "+ buisinessName[4]+
					" would like to send you an offer to raise your merchandice quality for " +
						buisinessCost[4] + "Thank you sire";
				whichOffer = 4;
			}
			if (offerType [4] == 3) {
				buisinessText.text = "Hello Buisiness owner, we here at "+ buisinessName[4]+
					" would like to send you an offer protect you from robery for " +
						buisinessCost[4] + "Thank you sire";
				whichOffer = 4;
				
		}
		if (offerType [4] == 0) {
			buisinessText.text = " ";
		}
	}
	public void offer6(){
		if (offerType [5] == 1) {
			buisinessText.text = "Hello Buisiness owner, we here at "+ buisinessName[5]+
				" would like to send you an offer to raise your customaer rate for " +
					buisinessCost[5] + "Thank you sire";
			whichOffer = 5;
			
		}
		if (offerType [5] == 2) {
			buisinessText.text = "Hello Buisiness owner, we here at "+ buisinessName[5]+
				" would like to send you an offer to raise your merchandice quality for " +
					buisinessCost[5] + "Thank you sire";
			whichOffer = 5;
		}
		if (offerType [5] == 3) {
			buisinessText.text = "Hello Buisiness owner, we here at "+ buisinessName[5]+
				" would like to send you an offer protect you from robery for " +
					buisinessCost[5] + "Thank you sire";
			whichOffer = 5;
			
		}
		if (offerType [5] == 0) {
			buisinessText.text = " ";
		}
	}
	public void offer7(){
		if (offerType [6] == 1) {
			buisinessText.text = "Hello Buisiness owner, we here at "+ buisinessName[6]+
				" would like to send you an offer to raise your customaer rate for " +
					buisinessCost[6] + "Thank you sire";
			whichOffer = 6;
			
		}
		if (offerType [6] == 2) {
			buisinessText.text = "Hello Buisiness owner, we here at "+ buisinessName[6]+
				" would like to send you an offer to raise your merchandice quality for " +
					buisinessCost[6] + "Thank you sire";
			whichOffer = 6;
		}
		if (offerType [6] == 3) {
			buisinessText.text = "Hello Buisiness owner, we here at "+ buisinessName[6]+
				" would like to send you an offer protect you from robery for " +
					buisinessCost[6] + "Thank you sire";
			whichOffer = 6;
			
		}
		if (offerType [6] == 0) {
			buisinessText.text = " ";
		}
	}
	public void offer8(){
		if (offerType [7] == 1) {
			buisinessText.text = "Hello Buisiness owner, we here at "+ buisinessName[7]+
				" would like to send you an offer to raise your customaer rate for " +
					buisinessCost[7] + "Thank you sire";
			whichOffer = 7;
			
		}
		if (offerType [7] == 2) {
			buisinessText.text = "Hello Buisiness owner, we here at "+ buisinessName[7]+
				" would like to send you an offer to raise your merchandice quality for " +
					buisinessCost[7] + "Thank you sire";
			whichOffer = 7;
		}
		if (offerType [7] == 3) {
			buisinessText.text = "Hello Buisiness owner, we here at "+ buisinessName[7]+
				" would like to send you an offer protect you from robery for " +
					buisinessCost[7] + "Thank you sire";
			whichOffer = 7;
			
		}
		if (offerType [7] == 0) {
			buisinessText.text = " ";
		}
	}
	public void doubleSpeed(){
		Time.timeScale = 2;
	}
	public void tripleSpeed(){
		Time.timeScale = 3;
	}
	public void singleSpeed(){
		Time.timeScale = 1;
	}
	public void pauseButton(){
		Time.timeScale = 0;
	}
	public void saveButton(){
		saveGame ();
		InformationUI.saveUI = true;
	}
	public void backToMenu(){
		Application.LoadLevel("Main Menu");
	}
	public void saveGame(){
		PlayerPrefs.SetInt ("fame", fame);
		PlayerPrefs.SetFloat ("cash", cash);
		PlayerPrefs.SetInt ("customerRate", customerRate);
		PlayerPrefs.SetFloat ("price", price);
		PlayerPrefs.SetFloat ("advertisementCost",advertisementCost);
		PlayerPrefs.SetFloat ("storeupgradeCost", storeUpgradeCost);
		PlayerPrefs.SetFloat ("merchandiceUpgradeCost", merchandiceCost);
		PlayerPrefs.SetInt ("workerCount", workerCount);
		PlayerPrefs.SetFloat ("RealTime", realTime);
		PlayerPrefs.SetInt ("seconds", seconds);
		PlayerPrefs.SetInt ("minutes", minutes);
		PlayerPrefs.SetInt ("hours", hours);
		PlayerPrefs.SetFloat ("gametimer", gametimer);
		
		PlayerPrefs.SetString ("workerName1", workerNames [0]);
		PlayerPrefs.SetFloat ("workerCost1", workerCost [0]);
		PlayerPrefs.SetInt("workerEffect1", workerEffect[0]);
		PlayerPrefs.SetString ("workerName2", workerNames[1]);
		PlayerPrefs.SetFloat ("workerCost2", workerCost [1]);
		PlayerPrefs.SetInt("workerEffect2", workerEffect[1]);
		PlayerPrefs.SetString ("workerName3", workerNames[2]);
		PlayerPrefs.SetFloat ("workerCost3", workerCost [2]);
		PlayerPrefs.SetInt("workerEffect3", workerEffect[2]);
		PlayerPrefs.SetString ("workerName4", workerNames[3]);
		PlayerPrefs.SetFloat ("workerCost4", workerCost [3]);
		PlayerPrefs.SetInt("workerEffect4", workerEffect[3]);
		PlayerPrefs.SetString ("workerName5", workerNames [4]);
		PlayerPrefs.SetFloat ("workerCost5", workerCost [4]);
		PlayerPrefs.SetInt("workerEffect5", workerEffect[4]);
		PlayerPrefs.SetString ("workerName6", workerNames[5]);
		PlayerPrefs.SetFloat ("workerCost6", workerCost [5]);
		PlayerPrefs.SetInt("workerEffect6", workerEffect[5]);
		PlayerPrefs.SetString ("workerName7", workerNames[6]);
		PlayerPrefs.SetFloat ("workerCost7", workerCost [6]);
		PlayerPrefs.SetInt("workerEffect7", workerEffect[6]);
		PlayerPrefs.SetString ("workerName8", workerNames[7]);
		PlayerPrefs.SetFloat ("workerCost8", workerCost [7]);
		PlayerPrefs.SetInt("workerEffect8", workerEffect[7]);
		PlayerPrefs.SetString ("workerName9", workerNames [8]);
		PlayerPrefs.SetFloat ("workerCost9", workerCost [8]);
		PlayerPrefs.SetInt("workerEffect9", workerEffect[8]);
		PlayerPrefs.SetString ("workerName10", workerNames[9]);
		PlayerPrefs.SetFloat ("workerCost10", workerCost [9]);
		PlayerPrefs.SetInt("workerEffect10", workerEffect[9]);
		PlayerPrefs.SetString ("workerName11", workerNames[10]);
		PlayerPrefs.SetFloat ("workerCost11", workerCost [10]);
		PlayerPrefs.SetInt("workerEffect11", workerEffect[10]);
		PlayerPrefs.SetString ("workerName12", workerNames[11]);
		PlayerPrefs.SetFloat ("workerCost12", workerCost [11]);
		PlayerPrefs.SetInt("workerEffect12", workerEffect[11]);
		PlayerPrefs.SetString ("workerName13", workerNames [12]);
		PlayerPrefs.SetFloat ("workerCost13", workerCost [12]);
		PlayerPrefs.SetInt("workerEffect13", workerEffect[12]);
		PlayerPrefs.SetString ("workerName14", workerNames[13]);
		PlayerPrefs.SetFloat ("workerCost14", workerCost [13]);
		PlayerPrefs.SetInt("workerEffect14", workerEffect[13]);
		PlayerPrefs.SetString ("workerName15", workerNames[14]);
		PlayerPrefs.SetFloat ("workerCost15", workerCost [14]);
		PlayerPrefs.SetInt("workerEffect15", workerEffect[14]);
		PlayerPrefs.SetString ("workerName16", workerNames[15]);
		PlayerPrefs.SetFloat ("workerCost16", workerCost [15]);
		PlayerPrefs.SetInt("workerEffect16", workerEffect[15]);
		PlayerPrefs.SetString ("workerName17", workerNames[16]);
		PlayerPrefs.SetFloat ("workerCost17", workerCost [16]);
		PlayerPrefs.SetInt("workerEffect17", workerEffect[16]);
		PlayerPrefs.SetString ("workerName18", workerNames [17]);
		PlayerPrefs.SetFloat ("workerCost18", workerCost [17]);
		PlayerPrefs.SetInt("workerEffect18", workerEffect[17]);
		PlayerPrefs.SetString ("workerName19", workerNames[18]);
		PlayerPrefs.SetFloat ("workerCost19", workerCost [18]);
		PlayerPrefs.SetInt("workerEffect19", workerEffect[18]);
		PlayerPrefs.SetString ("workerName20", workerNames[19]);
		PlayerPrefs.SetFloat ("workerCost20", workerCost [19]);
		PlayerPrefs.SetInt("workerEffect20", workerEffect[19]);
		
		PlayerPrefs.SetString ("offername1", buisinessName [0]);
		PlayerPrefs.SetInt ("offertype1", offerType [0]);
		PlayerPrefs.SetFloat ("offercost1", buisinessCost [0]);
		PlayerPrefs.SetString ("offername2", buisinessName [1]);
		PlayerPrefs.SetInt ("offertype2", offerType [1]);
		PlayerPrefs.SetFloat ("offercost2", buisinessCost [1]);
		PlayerPrefs.SetString ("offername3", buisinessName [2]);
		PlayerPrefs.SetInt ("offertype3", offerType [2]);
		PlayerPrefs.SetFloat ("offercost3", buisinessCost [2]);
		PlayerPrefs.SetString ("offername4", buisinessName [3]);
		PlayerPrefs.SetInt ("offertype4", offerType [3]);
		PlayerPrefs.SetFloat ("offercost4", buisinessCost [3]);
		PlayerPrefs.SetString ("offername5", buisinessName [4]);
		PlayerPrefs.SetInt ("offertype5", offerType [4]);
		PlayerPrefs.SetFloat ("offercost5", buisinessCost [4]);
		PlayerPrefs.SetString ("offername6", buisinessName [5]);
		PlayerPrefs.SetInt ("offertype6", offerType [5]);
		PlayerPrefs.SetFloat ("offercost6", buisinessCost [5]);
		PlayerPrefs.SetString ("offername7", buisinessName [6]);
		PlayerPrefs.SetInt ("offertype7", offerType [6]);
		PlayerPrefs.SetFloat ("offercost7", buisinessCost [6]);
		PlayerPrefs.SetString ("offername8", buisinessName [7]);
		PlayerPrefs.SetInt ("offertype8", offerType [7]);
		PlayerPrefs.SetFloat ("offercost8", buisinessCost [7]);
		
		PlayerPrefs.Save ();
	}
}



