using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using StartApp;

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


			#if UNITY_ANDROID
			StartAppWrapper.init();
			StartAppWrapper.loadAd();
			#endif
		

	}
	
	// Update is called once per frame
	void Update () {
		//text.text = "Score: " + score;
		text.text = "Score: " + GameDataTracker.GameScore;
		if(GameDataTracker.Lives <= 0)
		{   //SHOW STARTAPP INTERSTIATIAL EVERY 2 RUNS
			if(GameDataTracker.GameRuns%3 == 0 && GameDataTracker.AD_AlreadyShown == false){
				//if true => Show ad
				#if UNITY_ANDROID
				StartAppWrapper.showAd();
				StartAppWrapper.loadAd();
				#endif
				GameDataTracker.AD_AlreadyShown = true;
							
			}
			//Report Score to leaderboard
			ManageAchievements.ReportScoreToLeaderboard(GameDataTracker.GameScore);

			//
			GameObject ExitDoor = GameObject.FindGameObjectWithTag ("ExitDoor");
			Destroy(ExitDoor); 
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
