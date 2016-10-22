﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	public static int score;

	Text text;

	public float restartDelay = 2f;         // Time to wait before restarting the level
	Animator anim;                          // Reference to the animator component.
	float restartTimer;  
	// Use this for initialization
	void Awake () {
		GameObject HUDcanvas = GameObject.FindGameObjectWithTag ("HUDCanvas"); 
		anim =HUDcanvas.GetComponent <Animator> (); 
		text = GetComponent<Text> ();
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//text.text = "Score: " + score;
		text.text = "Score: " + GameDataTracker.GameScore;
		if(GameDataTracker.Lives <= 0)
		{
			GameObject BALL = GameObject.FindGameObjectWithTag ("Ball");
			DestroyObject (BALL);
			// ... tell the animator the game is over.
			anim.SetTrigger ("GameOver");

			// .. increment a timer to count up to restarting.
			restartTimer += Time.deltaTime;
			//ADD SUCCES SCREEN MOT GAMER OVER AND SHOW PROGRESS
			// .. if it reaches the restart delay...
			if(restartTimer >= restartDelay)
			{
				GameDataTracker.Reset ();
				// .. then reload the currently loaded level.
				//Application.LoadLevel(Application.loadedLevel);
				UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu",UnityEngine.SceneManagement.LoadSceneMode.Single);
			}

		}
	}
}