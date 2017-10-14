using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	public int level;
	public int winSeconds;
	private bool resetTimer = false;
	public Text timerText;
	public Text winText;
	private float startTime;
	private bool winCondition = false;

	private int numLevels;

	// Use this for initialization
	void Start () {
		winText.enabled = false;
		numLevels = SceneManager.sceneCountInBuildSettings;
		Debug.Log ("Number of Levels Read: " + numLevels);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.anyKey && winCondition) {
			Debug.Log ("Win Condition: " + winCondition);
			if(level+1 < numLevels){
				Debug.Log("went into If");
				Debug.Log("level plus 1 = " + (level+1) + "   numLevels: " + numLevels);
				UnityEngine.SceneManagement.SceneManager.LoadScene(level+1); //go to next level
			}else{
				Debug.Log("went into Else");
				Debug.Log("level plus 1 = " + (level+1) + "   numLevels: " + numLevels);
				UnityEngine.SceneManagement.SceneManager.LoadScene(0); //go to Main Menu when no levels are left to be played
			}
		}
			
		
		checkIfProjectileSpawned ();
		if ((Input.GetButtonDown ("Fire1")) || (resetTimer)) {
			startTime = Time.time;
		}

		float t = Time.time - startTime; //amount of Time since the Timer has started
		int minutes = ((int) t / 60);
		string minStr = minutes.ToString();
		float seconds = (t % 60);
		string secStr = seconds.ToString ("f0");
		checkWinCondition (seconds);

		if (minutes < 1) {
			timerText.text = secStr;
		} else {
			timerText.text = minStr + " : " + secStr;
		}


	}



	//Does a check to determine if a projectile is in then scene.
	void checkIfProjectileSpawned(){
		if (GameObject.Find ("Projectile(Clone)") != null) {
			resetTimer = false;
			//Debug.Log ("Projectile On Scene");
		} else {
			resetTimer = true;
			//Debug.Log ("Projectile NOT On Scene");
		}
	}


	//does a check to determine if the win condition is met.
	//If the win condition is true, execute win condition code.
	void checkWinCondition(float numSeconds){
		if(numSeconds >= winSeconds){
			executeWin ();
		}
	}



	//When the win codition is met, these lines of code run.
	void executeWin(){
		winText.enabled = true;
		winCondition = true;
	}



}
