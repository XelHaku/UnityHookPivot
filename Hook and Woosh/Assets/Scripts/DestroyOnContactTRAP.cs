using UnityEngine;
using System.Collections;

public class DestroyOnContactTRAP : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	//var score : int = 10;

	void OnTriggerEnter2D(Collider2D col) {

		if (col.gameObject.tag == "Ball") {
			//GameDataTracker.GameScore -= 50;
			GameDataTracker.Lives -=1;
			Destroy (gameObject); 
		} else if (col.gameObject.tag == "asdWallbrick" || col.gameObject.tag == "SpikeSeeker" ) {
			GameDataTracker.GameScore += 1;
			Destroy (gameObject); }
		}

	}

