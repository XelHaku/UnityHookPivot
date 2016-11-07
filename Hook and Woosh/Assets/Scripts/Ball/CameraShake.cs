using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
	private Vector3 refVelocity = Vector3.zero;
	GameObject Camera;
	Vector2 A;
	float K;
	float omega,TimeExponential;
	Vector3 PiCam;
	bool StartShake= false;
	// Use this for initialization


	GameObject BallPlayer,Entrance;
	Rigidbody2D elementRigid; 

	void Awake(){
	
		Camera = GameObject.FindGameObjectWithTag ("MainCamera");
		omega = 80;
		K = 2.0f;

		elementRigid = Camera.GetComponent<Rigidbody2D> ();
		//elementRigid.velocity = new Vector2 (ScrollerSpeed,0.0f);
	//	Entrance = GameObject.FindGameObjectWithTag ("EntranceDoor");
		if (Entrance != null) {
		//	elementRigid.position = new Vector3 (Entrance.GetComponent<Rigidbody2D> ().position.x, 0.0f,-10f);
					}
		//BallPlayer = GetComponent<GameObject> ();
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		

			if(BallPivotMechanicsOnTouch.BallState != "Hooked"){
			PiCam =GameObject.FindGameObjectWithTag("Ball").GetComponent<Transform> ().  position;
			}else{
			PiCam = BallPivotMechanicsOnTouch.actualPivot.GetComponent<Rigidbody2D> ().position;
					}	
		/////////////
		Camera.GetComponent<Transform> ().position =
			Vector3.SmoothDamp( Camera.GetComponent<Transform> ().position,
			new Vector3 (PiCam.x + A.x * Mathf.Exp (-K * TimeExponential) * Mathf.Cos (omega * TimeExponential),  
			A.y * Mathf.Exp (-K * Time.realtimeSinceStartup) * Mathf.Cos (omega * Time.realtimeSinceStartup), -10) ,ref refVelocity ,0.3f);
		////////

		//Debug.Log ("TimeExponential: "+TimeExponential);
		if (StartShake) {

			TimeExponential += Time.deltaTime;
			//
		} else {
			TimeExponential = 0;
//			if (BallPlayer != null) {
//				if (BallPivotMechanicsOnTouch.BallState != "Hooked") {
//					//elementRigid.position = new Vector2 (BallPlayer.GetComponent<Rigidbody2D> ().position.x, 0.0f);
//					//elementRigid.MovePosition (new Vector2 (BallPlayer.GetComponent<Rigidbody2D> ().position.x, 0.0f));
//					elementRigid.position = Vector3.SmoothDamp (elementRigid.position,new Vector3(GetComponent<Rigidbody2D> ().position.x, 0.0f), ref refVelocity,0.3f);
//				} else { elementRigid.position = Vector3.SmoothDamp (elementRigid.position,new Vector2(BallPivotMechanicsOnTouch.actualPivot.GetComponent<Rigidbody2D> ().position.x, 0.0f), ref refVelocity,1.0f);}
//			} else {
//				BallPlayer = GameObject.FindGameObjectWithTag ("Ball");
//			}
		}
	
	}

	void OnTriggerEnter2D(Collider2D col) {
		
		//Debug.Log ("Collision");
		StartShake = true;
		TimeExponential = 0;
		//A =0.2f*GameObject.FindGameObjectWithTag ("Ball").GetComponent<Rigidbody2D> ().velocity.magnitude;
		if (col.gameObject.tag == "SpikeSeeker") {
			Debug.Log ("CollisionSpikeSeeker");
			A =10.0f*GameObject.FindGameObjectWithTag ("Ball").GetComponent<Rigidbody2D> ().velocity;
		}else if (col.gameObject.tag == "RedWall") {
			A =5.0f*GameObject.FindGameObjectWithTag ("Ball").GetComponent<Rigidbody2D> ().velocity;
		}else if (col.gameObject.tag == "Jewel" || col.gameObject.tag == "Booster" ) {
			A = new Vector2 (0,0);
		}else if (col.gameObject.tag == "Blackhole") {
			A =0.50f*GameObject.FindGameObjectWithTag ("Ball").GetComponent<Rigidbody2D> ().velocity;
		}
	}


	void OnCollisionEnter2D(Collision2D col) {
		//Debug.Log ("Collision");
		StartShake = true;
		TimeExponential = 0;
		A =1.0f*GameObject.FindGameObjectWithTag ("Ball").GetComponent<Rigidbody2D> ().velocity;
		if (col.gameObject.tag == "RedWall") {
			A =5.8f*GameObject.FindGameObjectWithTag ("Ball").GetComponent<Rigidbody2D> ().velocity;
		}else if (col.gameObject.tag == "Jewel"  || col.gameObject.tag == "Booster"  ) {
			A = new Vector2 (0,0);
		}
	}
}
