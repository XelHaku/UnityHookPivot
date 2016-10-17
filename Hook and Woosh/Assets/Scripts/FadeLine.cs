using UnityEngine;
using System.Collections;

public class FadeLine : MonoBehaviour {
	float StartTime;
	// Use this for initialization
	void Start () {
		StartTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if ( Time.time- StartTime >0.01) {
			Destroy (gameObject);}
	
	}
}
