﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public void OnClick(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

}
