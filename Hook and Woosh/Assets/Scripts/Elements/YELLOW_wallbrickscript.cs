using UnityEngine;
using System.Collections;

public class YELLOW_wallbrickscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	//	Destroy(gameObject); 
	}
	void OnCollisionEnter2D(Collision2D col) {
		Debug.Log ("Collision" + gameObject.tag);

		if (col.gameObject.tag == "Ball") {
			
			Destroy(gameObject); 
		}
	}
}
