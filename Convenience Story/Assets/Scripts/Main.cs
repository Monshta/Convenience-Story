using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Main : MonoBehaviour {
	public float timer = 0.0f;
	public int customerRate = 1;
	public float price = 1f;
	public float cash = 0f;
	public Text cashUI;

	public int fame = 5;
	public Text fameUI; 
	public int advertisementCounter = 0;
	public float advertisementCost = 1f;
	public float storeUpgradeCost = 1f;
	public int storeUpgradeCounter = 0;

	public float merchandiceCost = 1f;
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

	public GameObject upgradePnl;
	public GameObject selectorPnl;
	public GameObject workerPnl;
	public GameObject buisinessPnl;

	public GameObject swagText;
	Text descText;
	public bool isDescInUse = false;

	public String [] randomCompanyNames = new String [16]{"Rito Games","Pysical Ent","Ubihard","Nintendont",
	"Jzepol","Sycooyes","Tairy Hesticles","Mushrooms","Chicken Alfredo","Unilevel","Yami STudios","Frantu","Kieth","Faker",
	"Ethernet Cable","Carlos"};
	public String [] buisinessName = new string[9]{" "," "," "," "," "," "," "," "," "};
	public float [] buisinessCost = new float[9]{0,0,0,0,0,0,0,0,0};
	public int buisinessOfferCount = 0;
	public float eventBuisiness = 0;
	public float buisinessChances = 0;
	public int [] offerType = new int[9]{0,0,0,0,0,0,0,0,0}; 

	public GameObject swagText2;
	Text buisinessText;

	 void Start () {
		yesBtn = GameObject.Find ("yesButton");
		yesBtn.SetActive (false);
		noBtn = GameObject.Find ("noButton");
		noBtn.SetActive (false);
		fireBtn = GameObject.Find ("fireButton");
		fireBtn.SetActive (false);
		okayBtn = GameObject.Find ("okayButton");
		okayBtn.SetActive (false);
		selectorPnl = GameObject.Find ("SelectorPanel");
		upgradePnl = GameObject.Find ("UpgradePanel");
		upgradePnl.SetActive (false);
		workerPnl = GameObject.Find ("WorkerPanel"); 
		workerPnl.SetActive (false);
		buisinessPnl = GameObject.Find ("BuisinessPanel");
		buisinessPnl.SetActive (false);
		swagText = GameObject.Find ("descriptionText");
		descText = swagText.GetComponent<Text> ();
		swagText.SetActive (false);
		swagText2 = GameObject.Find ("BuisinessTxt");
		buisinessText = swagText2.GetComponent<Text> ();
	}
	

	void Update () {
		if (customerRate >= 1) {
			eventBuisiness += Time.deltaTime;
			timer += Time.deltaTime;
			eventDisaster += Time.deltaTime;
			if(!isDescInUse){
			eventHire += Time.deltaTime;
			}
		}
		if (timer > 10) {//transactions happen every 10s
			cash += (price * customerRate);
			timer = 0.0f;
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
		}
		if (fame > 50 && fame < 200) {
			eventRobbery = eventRobbery + (Time.deltaTime * 0.5f);
		}
		if (fame > 200) {
			eventRobbery = eventRobbery + (Time.deltaTime * 0.25f);
		}

		if (eventDisaster > 60) {
			chancesDisaster = UnityEngine.Random.Range (0, 300);
			if (chancesDisaster > 0 && chancesDisaster < 5) { //This is a tsunami
				storeUpgradeCounter--;					// it nageates the store upgrade.
				customerRate -= 1;
				disasterCounter++;
			}
			if (chancesDisaster > 5 && chancesDisaster < 10) { 
				merchandiceCounter--;		//this is a earthquake
				price -= 1;					// it ruins the merchandise
				disasterCounter++;
			}
			if (chancesDisaster > 5 && chancesDisaster < 10) {  //i wana put a volcano here
				disasterCounter++;							// but we havnt figured out the
			}												// other mechanics
			eventDisaster = 0;	


			eventDisaster += Time.deltaTime;//Disasters need rely on fame, they got no chill
		}
		if (eventRobbery > 60) {
			chancesRobbery = UnityEngine.Random.Range (0,100);
			if(chancesRobbery > 0	&&	chancesRobbery < 5){
				cash = cash - (cash * 0.1f);
				robberyCounter ++;
			}
			eventRobbery = 0;
		}
		if (eventHire > 2 && workerCount<51) {//Temporary condition to check stuff
			chancesHire = UnityEngine.Random.Range ( 0, 100);
			if(chancesHire > 0 && chancesHire < 50){
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
		if (eventBuisiness > 20 && buisinessOfferCount < 9) {
			buisinessChances = UnityEngine.Random.Range(1,100);
			if(buisinessChances > 0 && buisinessChances < 3){
				buisinessName[buisinessOfferCount] = randomCompanyNames[(int)UnityEngine.Random.Range(0,15)];
				buisinessCost[buisinessOfferCount] = UnityEngine.Random.Range (fame*1/7, fame * 2/7);
				offerType[buisinessOfferCount] = 1;
			}
			if(buisinessChances > 3 && buisinessChances < 6){
				buisinessName[buisinessOfferCount] = randomCompanyNames[(int)UnityEngine.Random.Range(0,15)];
				buisinessCost[buisinessOfferCount] = UnityEngine.Random.Range (fame*1/7, fame * 2/7);
				offerType[buisinessOfferCount] = 2;
				
			}
			if(buisinessChances > 6 && buisinessChances < 9){
				buisinessName[buisinessOfferCount] = randomCompanyNames[(int)UnityEngine.Random.Range(0,15)];
				buisinessCost[buisinessOfferCount] = UnityEngine.Random.Range (fame*1/7, fame * 2/7);
				offerType[buisinessOfferCount] = 3;
				
			}
			if(buisinessChances > 9 && buisinessChances < 12){
				buisinessName[buisinessOfferCount] = randomCompanyNames[(int)UnityEngine.Random.Range(0,15)];
				buisinessCost[buisinessOfferCount] = UnityEngine.Random.Range (fame*1/7, fame * 2/7);
				offerType[buisinessOfferCount] = 4;
				
			}
		}
	}


	public void storeUpgrade(){// basic shit y'know how it goes fam
		if (storeUpgradeCost < cash) {
			customerRate+=1;
			cash-=storeUpgradeCost;
			storeUpgradeCost*=1;
			storeUpgradeCounter++;
		}
	}
	public void merchandiceUpgrade(){
		if (merchandiceCost < cash) {
			price += 1;
			cash -= merchandiceCost;
			merchandiceCost*=1;
			merchandiceCounter++;
				}
			}
	public void advertisementUpgrade(){// fame upgrade
		if (advertisementCost < cash) {
			fame += 1;
			cash -= advertisementCost;
			advertisementCost*=1;
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
		workerCost [workerCount] = UnityEngine.Random.Range (fame - 5, fame + 5);
		workerEffect [workerCount] = (int)UnityEngine.Random.Range (fame - 4, fame + 5);
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
			"Customer rate increased by: "+ workerEffect[0];
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
				"Customer rate increased by: "+ workerEffect[1];
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
				"Customer rate increased by: "+ workerEffect[2];
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
				"Customer rate increased by: "+ workerEffect[3];
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
				"Customer rate increased by: "+ workerEffect[4];
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
				"Customer rate increased by: "+ workerEffect[5];
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
				"Customer rate increased by: "+ workerEffect[6];
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
				"Customer rate increased by: "+ workerEffect[7];
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
				"Customer rate increased by: "+ workerEffect[8];
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
				"Customer rate increased by: "+ workerEffect[9];
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
				"Customer rate increased by: "+ workerEffect[10];
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
				"Customer rate increased by: "+ workerEffect[11];
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
				"Customer rate increased by: "+ workerEffect[12];
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
				"Customer rate increased by: "+ workerEffect[13];
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
				"Customer rate increased by: "+ workerEffect[14];
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
				"Customer rate increased by: "+ workerEffect[15];
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
				"Customer rate increased by: "+ workerEffect[16];
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
				"Customer rate increased by: "+ workerEffect[17];
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
				"Customer rate increased by: "+ workerEffect[18];
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
				"Customer rate increased by: " + workerEffect [19];
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

		}
		if (offerType [0] == 2) {
			
		}
		if (offerType [0] == 3) {
			
		}
		if (offerType [0] == 4) {
			
		}
	}


	}

