using UnityEngine;
using System.Collections;

public class WaveMovement : MonoBehaviour {
	public float Xratio; //screen Factor Movement in X
	public float Yratio; //screen Factor Movement in X
	public float Speed;
	private Vector3 initPos;
	Rigidbody2D ThisObject;
	float ScreenHeight;

	private int Xpositive,Ypositive;
	// Use this for initialization
	void Start () {
		ScreenHeight =Camera.main.orthographicSize;
		initPos = GetComponent<Rigidbody2D> ().position;
		ThisObject = GetComponent<Rigidbody2D> ();
		Xpositive = 1;
		Ypositive = 1;
		if (Xratio < 0) {Xpositive = -1;
		}
		if (Yratio < 0) {Ypositive = -1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Xratio == 0) {
			Xpositive = 0;
		}
		if (Yratio == 0) {
			Ypositive = 0;
		}
		Debug.Log (Mathf.Sign(Xratio));
		GetComponent<Rigidbody2D> ().velocity =new Vector2(Speed * Xpositive,Speed * Ypositive);

		if (GetComponent<Rigidbody2D> ().position.x > initPos.x + ScreenHeight *Mathf.Abs( Xratio)) {
			Xpositive = -1;
		} else if (GetComponent<Rigidbody2D> ().position.x < initPos.x - ScreenHeight *Mathf.Abs( Xratio)) {
			Xpositive = 1;
		}

		if (GetComponent<Rigidbody2D> ().position.y > initPos.y + ScreenHeight *Mathf.Abs( Yratio)) {
			Ypositive = -1;
		} else if (GetComponent<Rigidbody2D> ().position.y < initPos.y - ScreenHeight *Mathf.Abs( Yratio)) {
			Ypositive = 1;
		}
	
	}
}
