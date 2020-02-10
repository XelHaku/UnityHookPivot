using UnityEngine;
using System.Collections;

public class Jewel : MonoBehaviour {
	//public GameController gameController;
	public GameObject thisParticleEffect;
	int scoreValue = 10;
	// Use this for initialization
	void Start () {
		//scoreValue = 10;
//		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
//		if (gameControllerObject != null)
//		{
//			gameController = gameControllerObject.GetComponent <GameController>();
//		}
//		if (gameController == null)
//		{
//			Debug.Log ("Cannot find 'GameController' script");
//		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//var score : int = 10;

	void OnTriggerEnter2D(Collider2D col) {

		if (col.gameObject.tag == "Ball") {
			//PENDING ADD SCORE
			GameDataTracker.GameScore +=((int)(scoreValue+GameDataTracker.ReachedLevels-1));
			//Debug.Log( (int)Mathf.RoundToInt(0.9f+GameDataTracker.ReachedLevels*0.1,0));
			//gameController.AddScore (scoreValue);

			Instantiate(thisParticleEffect,GetComponent<Transform>().position,Quaternion.identity );
			//GameObject [] RemainingJewels = GameObject.FindGameObjectsWithTag ("Jewel");
			//Debug.Log ("hey  "+GameObject.FindGameObjectsWithTag ("Jewel").Length);
			if (GameObject.FindGameObjectsWithTag ("Jewel").Length == 1) {
				GameObject ExitDoor = GameObject.FindGameObjectWithTag ("ExitDoor");
				ExitDoor.GetComponent<SpriteRenderer> ().color = new Color (0.32f,0.945f, 0.375f);
				//ExitDoor.GetComponent<SpriteRenderer> ().color = new Color (82,242,96);
			
			}
			Destroy(gameObject); 


			
		}
	}

}




		
	
