using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
public class gameStats : MonoBehaviour {

	public int level;
	public Text winText;
	public Toggle hintText;
	private int inGameState = false;
	private int numGameLaunchesCounterQ1;
	private int numLevelsPlayedCounterQ2;
	private int numPlanetsLaunchedCounterQ3;
	private int numHintsToggleCounterQ4;

	//
	void Start () {
		var input = gameObject.GetComponent<InputField>();
		var se= new InputField.SubmitEvent();
		se.AddListener(SubmitName);
		input.onEndEdit = se;
	}

		private void SubmitName(string arg0){
			Debug.Log(arg0);
			if (File.Exists ("data.txt")) {
			File.AppendAllText ("data.txt", "\n" + arg0 + ",");
			} else {
				File.WriteAllText("data.txt", "Name,numGameLaunchesCounterQ1,numLevelsPlayedCounterQ2,numPlanetsLaunchedCounterQ3,numHintsToggleCounterQ4\n");
				File.AppendAllText ("data.txt", arg0 + ",");
			}
		}

	// Update is called once per frame
	void Update () {
		
		//check if projectile has been spawned.
		detectProjectileOnSpawn ();

		//check to see if hints are toggled on.
		//When the hints are toggled on, the hint counter is incremented.
		detectHintToggle (hintText);

		collectQ3Q4Data ();
	}


	//Question 1:
	//The game will keep a counter of how many times the same user will play the game. This would is an integer value.

	//Question 2:
	//When a level is completed, a counter should be incremented for the play session. This would be an integer value.

	//Question 3:
	//Each time the player launches a planet or any object, some counter increments for the current play session. This value is an integer value.

	//Question 4:
	//Each time the hints are toggled on or off, increment a counter for the play session. This is an integer value.
				

	//BELOW IS DATA COLLECTION FUNCTIONS FOR COLLECTING DATA IN REGARDS TO Q1 TO Q4


	//HANDLES DATA COLELCTION FOR Q1 AND Q2
	void collectQ3Q4Data(){
		if (level >= 1) {
			if(inGameState == false){
				//game has begun and player is in level a level, hopefully level 1 to start game.
				//increment game counter by 1
				numGameLaunchesCounterQ1++;
				//game state has become true, so do not increment game launch counter anymore this game state.
				inGameState = true;
			}
			if (SceneManager.activeSceneChanged == true) {
				//scene change detected. So the player must have went to the next level. So add 1 to the num levels counter.
				numLevelsPlayedCounterQ2++;
			}
		}
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
	void detectHintToggle(Toggle toggleInput){
		if (toggleInput.enabled == true && toggleInput.onValueChanged == true) {
			//hints toggled on, increment hint counter by 1.
			numHintsToggleCounterQ4++;
		}
	}
}
