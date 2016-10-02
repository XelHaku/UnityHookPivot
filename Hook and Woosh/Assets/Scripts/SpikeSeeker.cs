using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class SpikeSeeker : MonoBehaviour {
	public float GravityFactor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ApplyGravityForceToSpike(string ballType){

		double tempGravityX = 0;
		double tempGravityY = 0;

		float RvecX, RvecY;
		double Radius;

		GameObject[] BallTagged = GameObject.FindGameObjectsWithTag (ballType); 
		foreach (var ballTag in BallTagged) {

			//change gravity
			RvecX = GetComponent<Rigidbody2D> ().position.x - ballTag.GetComponent<SpriteRenderer> ().bounds.center.x;
			RvecY = GetComponent<Rigidbody2D> ().position.y - ballTag.GetComponent<SpriteRenderer> ().bounds.center.y;
			Radius = Math.Pow (RvecX, 2.0f) + Math.Pow (RvecY, 2.0f);
			Radius = Math.Pow (Radius, 0.5f);


			Radius = Math.Pow (Radius, 3f);

			if (Radius > ballTag.GetComponent<SpriteRenderer> ().bounds.size.x) {
				tempGravityX += GravityFactor * ballTag.GetComponent<SpriteRenderer> ().bounds.size.x * GetComponent<SpriteRenderer> ().bounds.size.x * RvecX / (Radius);
				tempGravityY += GravityFactor * ballTag.GetComponent<SpriteRenderer> ().bounds.size.y * GetComponent<SpriteRenderer> ().bounds.size.y * RvecY / (Radius);
			}

			Vector2 gravityForce = new Vector2 ((float)tempGravityX, (float)tempGravityY);
			GetComponent<Rigidbody2D> ().AddForce (gravityForce);
		}


	}
}
