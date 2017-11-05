using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class gameStats : MonoBehaviour {

	public Toggle hintText;
	private int gameTimeSecQ1 = 0;
	private int numLevelsPlayedCounterQ2 = 0;
	private int numPlanetsLaunchedCounterQ3 = 0;
	private int numHintsToggleCounterQ4 = 0;
	private float startTime;
	float t;
	int interval = 1; 
	float nextTime = 0;
	bool appClosing = false;

	//This should execute when the application begins to close.
	void OnApplicationQuit(){
		playSessionEnd ();
		File.AppendAllText ("data.txt", "\n-,-,-,-");
		Debug.Log("Application ending after " + Time.time + " seconds");
		appClosing = true;
	}

	//This should execute when the script is destroyed. (Scene change)
	void OnDestroy(){
		if(appClosing == false){
			playSessionEnd ();
			Debug.Log("Level ending after " + Time.time + " seconds");
		}
	}

	//run this at the start of the load
	void Start () {
		//do not end this script on scene change.
		//DontDestroyOnLoad(this);
		startDataCollection ();
		startTime = Time.time;

		//set the stat values to 0 to start because this is a new session
		//gameTimeSecQ1;
		//numLevelsPlayedCounterQ2;
		//numPlanetsLaunchedCounterQ3;
		//numHintsToggleCounterQ4;
	}

		private void startDataCollection(){
			Debug.Log("Data Collection Begins");
			if (File.Exists ("data.txt")) {
			File.AppendAllText ("data.txt", "\n");
			} else {
				File.WriteAllText("data.txt", "gameTimeSecQ1,numLevelsPlayedCounterQ2,numPlanetsLaunchedCounterQ3,numSecHintsToggledQ4");
				File.AppendAllText ("data.txt", "\n");
			}
		}

	// Update is called once per frame
	void Update () {
		
		//update Q1 timer
		t = Time.time - startTime; //amount of Time since the Timer has started

		//check if projectile has been spawned.
		detectProjectileOnSpawn ();

		if (Time.time >= nextTime) {
			//check to see if hints are toggled on.
			//When the hints are toggled on, the hint counter is incremented.
			detectHintToggle ();
			nextTime += interval; 
		}
	}



	//Appends data collected to data.txt for storage.
	void storeAllData(int Q1, int Q2, int Q3, int Q4){
		if (File.Exists ("data.txt")) {
			File.AppendAllText ("data.txt", Q1 + "," +  Q2 + "," + Q3 + "," + Q4);
		} else {
			Debug.Log ("DATA COLLECTION ERROR: data.txt NOT FOUND");
		}
		Debug.Log ("DATA COLLECTION SUCCESS: data collection completed");
	}


	//finds active scene and determines if it is the main menu.
	void playSessionEnd(){
		gameTimeSecQ1 = (int) Mathf.Round(t);
		//Store all the data collected for this play session.
		storeAllData (gameTimeSecQ1, numLevelsPlayedCounterQ2, numPlanetsLaunchedCounterQ3, numHintsToggleCounterQ4);
	}

	//Reads data from data.txt
	//void readData(){
	//	string readText = File.ReadAllText ("data.txt");
	//}



	//Question 1:
	//The game will keep a counter of how many times the same user will play the game. This is an integer value.
	//REVISING THIS QUESTION
	//The game will keep track of the total time played in the session to calculate time per level.

	//Question 2:
	//When a level is completed, a counter should be incremented for the play session. This would be an integer value.

	//Question 3:
	//Each time the player launches a planet or any object, some counter increments for the current play session. This value is an integer value.

	//Question 4:
	//Each second the hints are on, count up that second.
				

	//BELOW IS DATA COLLECTION FUNCTIONS FOR COLLECTING DATA IN REGARDS TO Q1 TO Q4


	//HANDLES DATA COLELCTION FOR Q1 AND Q2
	//void collectQ2Data(){
			//This gets data for Q2 NOT WORKING AT THE MOMENT
			//SceneManager.activeSceneChanged += levelCount;	
	//}


	//Helper for collecting Q2 data
	void levelCount(Scene arg0, Scene arg1){
		//scene change detected. So the player must have went to the next level. So add 1 to the num levels counter.
		numLevelsPlayedCounterQ2++;
		Debug.LogFormat("[Arg1]{0} [Arg2]{1}", arg0.buildIndex, arg1.buildIndex);
	}


	//HANDLES DATA COLLECTION FOR Q3
	void detectProjectileOnSpawn(){
		if (Input.GetButtonDown ("Fire1") && Input.mousePosition.y > Screen.height * 0.0575) {
			//projectile must have been spawned on this criteria.
			//increment projectile Counter by 1.
			numPlanetsLaunchedCounterQ3++;
		}
	}


	//HANDLES DATA COLLECTION FOR Q4
	void detectHintToggle(){
		//Toggle hintToggle;
		//hintToggle = GameObject.FindGameObjectWithTag("hintToggle").GetComponent<Toggle>();
		if (hintText.isOn == true) {
			//hints toggled on, increment hint counter each second.
			numHintsToggleCounterQ4++;
		}
	}


	//Get hint text for current scene


//end of file
}
