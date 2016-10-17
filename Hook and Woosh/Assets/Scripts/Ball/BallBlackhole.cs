using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class BallBlackhole : MonoBehaviour {

	public float GravityFactor;
	GameObject  closestBlackhole ;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		closestBlackhole = GetNearestTaggedBlackhole ();
		if (closestBlackhole != null) {
			if (Vector3.Distance (GetComponent<Transform> ().position, closestBlackhole.GetComponent<Transform> ().position) <= 2.0f * closestBlackhole.GetComponent<Transform> ().localScale.x) {
				ApplyGravityForceToSpike (closestBlackhole);
			}
		}
	}

	GameObject GetNearestTaggedBlackhole(){
		var nearestDistanceSqr = Mathf.Infinity;
		var taggedGameObjects = GameObject.FindGameObjectsWithTag("Blackhole"); 
		//GameObject nearestObj;
		GameObject closestPivot = null;
		// loop through each tagged object, remembering nearest one found
		if (taggedGameObjects != null) {
			foreach (GameObject obj in taggedGameObjects) {
				var objectPos = obj.transform.position;
				var distanceSqr = (objectPos - transform.position).sqrMagnitude;
				if (distanceSqr < nearestDistanceSqr) {
					//nearestObj = obj.transform;
					nearestDistanceSqr = distanceSqr;
					closestPivot = obj;
				}
			}
		}
		return closestPivot;
	}

	void ApplyGravityForceToSpike(GameObject BlackholeObject){

		double tempGravityX = 0;
		double tempGravityY = 0;

		float RvecX, RvecY;
		double Radius;



		//change gravity
		RvecX = GetComponent<Rigidbody2D> ().position.x - BlackholeObject.GetComponent<SpriteRenderer> ().bounds.center.x;
		RvecY = GetComponent<Rigidbody2D> ().position.y - BlackholeObject.GetComponent<SpriteRenderer> ().bounds.center.y;
		Radius = Math.Pow (RvecX, 2.0f) + Math.Pow (RvecY, 2.0f);
		Radius = Math.Pow (Radius, 0.5f);


		Radius = Math.Pow (Radius, 3f);

		if (Radius > 0.1f*BlackholeObject.GetComponent<SpriteRenderer> ().bounds.size.x) {
			tempGravityX += GravityFactor * BlackholeObject.GetComponent<SpriteRenderer> ().bounds.size.x * GetComponent<SpriteRenderer> ().bounds.size.x * RvecX / (Radius);
			tempGravityY += GravityFactor * BlackholeObject.GetComponent<SpriteRenderer> ().bounds.size.y * GetComponent<SpriteRenderer> ().bounds.size.y * RvecY / (Radius);
		}

		Vector2 gravityForce = new Vector2 ((float)-tempGravityX, (float)-tempGravityY);
		GetComponent<Rigidbody2D> ().AddForce (gravityForce);



	}
}
