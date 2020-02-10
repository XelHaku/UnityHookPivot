using UnityEngine;
using System.Collections;

public class LevelGate : MonoBehaviour {
	public int ScoreRequirement;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameDataTracker.GameScore >= ScoreRequirement) {
			Destroy (gameObject);
		};
	}
}
