using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class BallSpikeSeekerMechanics : MonoBehaviour {
	public float GravityFactor;
	GameObject  closestSpikeSeeker ;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		closestSpikeSeeker = GetNearestTaggedSpike ();
		if (Vector3.Distance (GetComponent<Transform> ().position, closestSpikeSeeker.GetComponent<Transform> ().position) <= 4.0f * closestSpikeSeeker.GetComponent<Transform> ().localScale.x) {
			ApplyGravityForceToSpike (closestSpikeSeeker);
		}
	}

	GameObject GetNearestTaggedSpike(){
		var nearestDistanceSqr = Mathf.Infinity;
		var taggedGameObjects = GameObject.FindGameObjectsWithTag("SpikeSeeker"); 
		//GameObject nearestObj;
		GameObject closestPivot = null;
		// loop through each tagged object, remembering nearest one found
		foreach (GameObject obj in taggedGameObjects) {
			var objectPos = obj.transform.position;
			var distanceSqr = (objectPos - transform.position).sqrMagnitude;
			if (distanceSqr < nearestDistanceSqr) {
				//nearestObj = obj.transform;
				nearestDistanceSqr = distanceSqr;
				closestPivot = obj;
			}
		}

		return closestPivot;
	}

	void ApplyGravityForceToSpike(GameObject SpikeSeeker){

		double tempGravityX = 0;
		double tempGravityY = 0;

		float RvecX, RvecY;
		double Radius;



			//change gravity
		RvecX = GetComponent<Rigidbody2D> ().position.x - SpikeSeeker.GetComponent<SpriteRenderer> ().bounds.center.x;
		RvecY = GetComponent<Rigidbody2D> ().position.y - SpikeSeeker.GetComponent<SpriteRenderer> ().bounds.center.y;
			Radius = Math.Pow (RvecX, 2.0f) + Math.Pow (RvecY, 2.0f);
			Radius = Math.Pow (Radius, 0.5f);


			Radius = Math.Pow (Radius, 3f);

		if (Radius > SpikeSeeker.GetComponent<SpriteRenderer> ().bounds.size.x) {
			tempGravityX += GravityFactor * SpikeSeeker.GetComponent<SpriteRenderer> ().bounds.size.x * GetComponent<SpriteRenderer> ().bounds.size.x * RvecX / (Radius);
			tempGravityY += GravityFactor * SpikeSeeker.GetComponent<SpriteRenderer> ().bounds.size.y * GetComponent<SpriteRenderer> ().bounds.size.y * RvecY / (Radius);
			}

			Vector2 gravityForce = new Vector2 ((float)tempGravityX, (float)tempGravityY);
		SpikeSeeker.GetComponent<Rigidbody2D> ().AddForce (gravityForce);
		


	}
}
