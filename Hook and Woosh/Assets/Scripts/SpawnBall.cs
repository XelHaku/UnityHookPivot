using UnityEngine;
using System.Collections;

public class SpawnBall : MonoBehaviour {
	public GameObject BlueBall;
	bool flag = true;
	// Use this for initialization
	void Start () {
	//Spawn Blueball
		GetComponent<SpriteRenderer>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Time.realtimeSinceStartup >= 2.0 && flag == true) {
			GameObject	activeBlueBall = Instantiate (BlueBall);
			activeBlueBall.GetComponent<Rigidbody2D> ().position = GetComponent<Rigidbody2D> ().position;
			flag = false;
		}
		if (Time.realtimeSinceStartup >= 5.5) {
			//Destroy (gameObject);
			GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}
