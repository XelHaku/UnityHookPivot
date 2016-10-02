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
			ScoreManager.score -= 30;
			Destroy (gameObject); 
		} else if (col.gameObject.tag == "Wallbrick" || col.gameObject.tag == "SpikeSeeker" ) {
			ScoreManager.score += 1;
			Destroy (gameObject); }
		}

	}

