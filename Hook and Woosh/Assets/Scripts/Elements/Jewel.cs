using UnityEngine;
using System.Collections;

public class Jewel : MonoBehaviour {
	//public GameController gameController;
	public int scoreValue;
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
			GameDataTracker.GameScore +=scoreValue;
			//gameController.AddScore (scoreValue);
			Destroy(gameObject); 
		}
	}

}




		
	
