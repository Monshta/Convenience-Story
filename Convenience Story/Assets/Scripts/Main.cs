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

	public String[] randomWorkerNames = new string[31] {"Adam","Eve","Francis","Anthony","Josh","John",//This is the pool of names we will generate
	"Patrick","Patricia","Grace","Rjen","Tristan","Jack","Jill","Andrew","Chris","Kori","Jacob","Edward","Bella",// names from
	"Angel","Ethiopia","Caitlyn","Sharqueesha","Jasmine","Lewis","Antu","Jackie","Megan", "Arnold", "Zach","Cody"};
	public String placeHolderName;//temporarily holds name
	public String [] workerNames = new string[21] {" "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "};
	public float [] workerCost = new float[21]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};// All of these are placeholders for arrays
	public int [] workerEffect = new int[21]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	public int whichworker;

	public GameObject upgradePnl;
	public GameObject selectorPnl;

	public GameObject swagText;
	Text descText;
	public bool isDescInUse = false;
	void Start () {
		yesBtn = GameObject.Find ("yesButton");
		yesBtn.SetActive (false);
		noBtn = GameObject.Find ("noButton");
		noBtn.SetActive (false);
		fireBtn = GameObject.Find ("fireButton");
		fireBtn.SetActive (false);
		selectorPnl = GameObject.Find ("SelectorPanel");
		upgradePnl = GameObject.Find ("UpgradePanel");
		upgradePnl.SetActive (false);
		swagText = GameObject.Find ("descriptionText");
		descText = swagText.GetComponent<Text> ();
		swagText.SetActive (false);
	}
	

	void Update () {
		if (customerRate >= 1) {
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
		if (eventHire > 10 && workerCount<21) {//Temporary condition to check stuff
			chancesHire = UnityEngine.Random.Range ( 0, 100);
			if(chancesHire > 0 && chancesHire < 50){
			placeHolderName = randomWorkerNames[(int)UnityEngine.Random.Range(0,31)];
			swagText.SetActive (true);
			descText.text = "Would you like to hire " + placeHolderName + "?";
				yesBtn.SetActive(true);
				noBtn.SetActive(true);
			isDescInUse = true;
			}
			eventHire = 0;
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
		workerEffect [workerCount] = (int)UnityEngine.Random.Range (fame - 5, fame + 5);
	}
	public void noButton(){
		yesBtn.SetActive (false);
		noBtn.SetActive (false);
		isDescInUse = false;
		descText.text = " ";
	}
	public void fireButton(){// to fire the workers, itll be set active when the user clicks on a worker
		//whichworker = slected; //slected will return when a worker is selected
		workerCost [20] = 0;
		workerEffect [20] = 0;
		workerNames [20] = " ";
		workerCost [whichworker] = -1;
		for (int i = 0; i<21; i++) {
			if(workerCost[i] == -1){
				for (int j = 0; j < (21-i);j++){
					workerCost[i] = workerCost[i+1];
					workerEffect[i] = workerEffect[i+1];
					workerNames[i] = workerNames[i+1];
				}
			}
		}
		workerCount --;
		fireBtn.SetActive (false);
	}
	public void toUpgradePanel(){
		selectorPnl.SetActive (false);
		upgradePnl.SetActive (true);
	}
	public void backButton(){
		selectorPnl.SetActive (true);
		upgradePnl.SetActive (false);
	}

	}

