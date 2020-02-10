using UnityEngine;
using System.Collections;

public class LivesScreenCounter : MonoBehaviour {
	public int ThisElementLiveNumber;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameDataTracker.Lives < ThisElementLiveNumber) {
			GetComponent<CanvasRenderer> ().SetAlpha(0);
		} else {
			GetComponent<CanvasRenderer> ().SetAlpha(1);
		}
	
	}
}
