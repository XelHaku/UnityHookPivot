using UnityEngine;
using System.Collections;

public class ScrollerCommand : MonoBehaviour {
	public float ScrollerSpeed;
	public GameObject BallPlayer;
	Rigidbody2D elementRigid; 
	// Use this for initialization
	void Start () {
		 elementRigid = GetComponent<Rigidbody2D> ();
		//elementRigid.velocity = new Vector2 (ScrollerSpeed,0.0f);
		BallPlayer = GameObject.FindGameObjectWithTag("Ball");
	}
	
	// Update is called once per frame
	void Update () {
		
		elementRigid.position = new Vector2 (BallPlayer.GetComponent<Rigidbody2D> ().position.x,0.0f);
	}
}
