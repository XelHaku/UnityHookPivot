using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;



public class BallPivotMechanicsOnTouch : MonoBehaviour {
	//public GameObject[] PivotsTagged;
	//public GameObject   FoodBullet;
	public static string BallState;
	public GameObject GravityGlow;
//	public SpriteRenderer sprenderMagentaGlow;
	//public bool BallClockwiseRotation;
	public float maxSpeed;
	GameObject  closestPivot ;
	public float GravityFactor;


	// Use this for initialization
	void Start () {
		//GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 100.0f, 0);
		GetComponent<DistanceJoint2D>().enabled = false;
		BallState = "Free";
		GravityGlow = GameObject.FindGameObjectWithTag("GravityGlow");

//		var taggedMagentaGlow = GameObject.FindGameObjectsWithTag("MagentaGlow");
//		foreach (GameObject objGlow in taggedMagentaGlow) {
//			sprenderMagentaGlow = 	objGlow.GetComponentInChildren<SpriteRenderer>();
//			sprenderMagentaGlow.enabled = false;
//		}

		//BallClockwiseRotation = true;
		 // closestPivot = GetNearestTaggedPivot(); 


	}

	
	// Update is called once per frame
	void Update () {
		ApplyGravityGlowForceToBall ();


	foreach (Touch touch in Input.touches) {

			RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
				
				GameObject RealCamera = GameObject.FindGameObjectWithTag ("MainCamera"); 
			//TouchSquare for PIVOT

			if( touch.phase == TouchPhase.Began && touch.phase == TouchPhase.Stationary ){
				
				closestPivot = GetNearestTaggedPivot();
				Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
				Vector2 touchPos = new Vector2 (wp.x, wp.y);
				if(BallState == "Free" ){
					
					if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved ) {
						

						if (closestPivot.GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPos)) {
						// NOW CHANGE GRAVITY FLOW TO PIVOT POSITION	ApplyGravityForceToBall (closestPivot);

						} else if(Vector3.Distance(GetComponent<Transform>().position,closestPivot.GetComponent<Transform>().position) <= 3.0f*closestPivot.GetComponent<Transform>().localScale.x){
							BallState = "Hooked";

							Debug.Log("Hooked to Pivot");
							GetComponent<DistanceJoint2D>().enabled = true;
							GetComponent<DistanceJoint2D>().distance = Vector3.Distance(GetComponent<Transform>().position,closestPivot.GetComponent<Transform>().position);
							GetComponent<DistanceJoint2D>().connectedAnchor = closestPivot.GetComponent<Transform>().position;

							Vector2 Force = PropulsionFromHook(closestPivot);
							GetComponent<Rigidbody2D> ().AddForce (Force);
						}

					}
			
				
				
				}else{
					if (closestPivot.GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPos)) {
						
					} else {
						GetComponent<DistanceJoint2D> ().enabled = false;
						BallState = "Free";
						Debug.Log ("Free");
					}
				}
			}

		

			
		}


		//FOR THE KEYBOARD
		
		if(Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0)){
			if(BallState == "Free" ){
				
				 closestPivot = GetNearestTaggedPivot();
				if(Vector3.Distance(GetComponent<Transform>().position,closestPivot.GetComponent<Transform>().position) <= 3.0f*closestPivot.GetComponent<Transform>().localScale.x){
					BallState = "Hooked";
					Debug.Log("Hooked to Pivot");
					GetComponent<DistanceJoint2D>().enabled = true;
					GetComponent<DistanceJoint2D>().connectedAnchor = closestPivot.GetComponent<Transform>().position;
					GetComponent<DistanceJoint2D>().distance = Vector3.Distance(GetComponent<Transform>().position,closestPivot.GetComponent<Transform>().position);
					Vector2 Force = PropulsionFromHook(closestPivot);
					GetComponent<Rigidbody2D> ().AddForce (Force);
				}		
			}else{
				
				GetComponent<DistanceJoint2D>().enabled = false;
				BallState = "Free";
				Debug.Log("Free");
			}
		}
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		GameObject[] activePivot = GameObject.FindGameObjectsWithTag ("Pivot");
		foreach( var pivotHover in activePivot){
			if(hit.collider == pivotHover.GetComponent<Collider2D>())
		{
			//Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			//Vector2 touchPos = new Vector2 (wp.x, wp.y);
				Debug.Log ("Target Position: " + hit.collider.gameObject.transform.position);

				GravityGlow.GetComponent<Rigidbody2D>().position = pivotHover.GetComponent<Rigidbody2D>().position;
			
			}
		}
	
		
	
		
		if (GetComponent<DistanceJoint2D> ().enabled == true) {
			GetComponent<DistanceJoint2D>().connectedAnchor = closestPivot.GetComponent<Transform>().position;
		}

	}//END UPDATE
	void FixedUpdate()
	{
		if(GetComponent<Rigidbody2D> ().velocity.magnitude > maxSpeed)
		{
			GetComponent<Rigidbody2D> ().velocity = GetComponent<Rigidbody2D> ().velocity.normalized * maxSpeed;
		}
	}
	#region COLLISION

	
	void OnTriggerEnter2D(Collider2D col) 
	{
		if(col.gameObject.tag == "Food")
		{			col.gameObject.SetActive(false);
			Debug.Log("Food collected...");
			//	transform.localScale+= new Vector3(col.gameObject.transform.localScale.x/4,col.gameObject.transform.localScale.y/4, 0);
			transform.localScale+= new Vector3(0.05f,0.05f, 0);
			//Add Score
		}
		

	}
	#endregion
	GameObject GetNearestTaggedPivot(){
		var nearestDistanceSqr = Mathf.Infinity;
		var taggedGameObjects = GameObject.FindGameObjectsWithTag("Pivot"); 
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

	void ApplyGravityGlowForceToBall(){
		double tempGravityX = 0;
		double tempGravityY = 0;

		float RvecX, RvecY;
		double Radius;


		//change gravity
		RvecX = GetComponent<Rigidbody2D> ().position.x - GravityGlow.GetComponent<SpriteRenderer> ().bounds.center.x;
		RvecY = GetComponent<Rigidbody2D> ().position.y - GravityGlow.GetComponent<SpriteRenderer> ().bounds.center.y;
		Radius = Math.Pow (RvecX, 2.0f) + Math.Pow (RvecY, 2.0f);
		Radius = Math.Pow (Radius, 0.5f);


		Radius = Math.Pow (Radius, 3f);

		if (Radius > GravityGlow.GetComponent<SpriteRenderer> ().bounds.size.x) {
			tempGravityX -= GravityFactor * GetComponent<SpriteRenderer> ().bounds.size.x * GetComponent<SpriteRenderer> ().bounds.size.x * RvecX / (Radius);
			tempGravityY -= GravityFactor * GetComponent<SpriteRenderer> ().bounds.size.y * GetComponent<SpriteRenderer> ().bounds.size.y * RvecY / (Radius);
		}




		Vector2 gravityForce = new Vector2 ((float)tempGravityX, (float)tempGravityY);
		GetComponent<Rigidbody2D> ().AddForce (gravityForce);

	}

	void ApplyGravityForceToBall(GameObject pivotType){
		double tempGravityX = 0;
		double tempGravityY = 0;
		
		float RvecX, RvecY;
		double Radius;
		
			
			//change gravity
			RvecX = GetComponent<Rigidbody2D> ().position.x - pivotType.GetComponent<SpriteRenderer> ().bounds.center.x;
			RvecY = GetComponent<Rigidbody2D> ().position.y - pivotType.GetComponent<SpriteRenderer> ().bounds.center.y;
			Radius = Math.Pow (RvecX, 2.0f) + Math.Pow (RvecY, 2.0f);
			Radius = Math.Pow (Radius, 0.5f);
			
			
			Radius = Math.Pow (Radius, 3f);
			
		if (Radius > pivotType.GetComponent<SpriteRenderer> ().bounds.size.x) {
				tempGravityX -= GravityFactor * GetComponent<SpriteRenderer> ().bounds.size.x * GetComponent<SpriteRenderer> ().bounds.size.x * RvecX / (Radius);
				tempGravityY -= GravityFactor * GetComponent<SpriteRenderer> ().bounds.size.y * GetComponent<SpriteRenderer> ().bounds.size.y * RvecY / (Radius);
								}
			
			
		
		
		Vector2 gravityForce = new Vector2 ((float)tempGravityX, (float)tempGravityY);
		GetComponent<Rigidbody2D> ().AddForce (gravityForce);

	}
	Vector2 PropulsionFromHook(GameObject closestPivot){
		var ballVec = new Vector3 ();
		var pivotVec = new Vector3 ();
		ballVec = GetComponent<Transform> ().position;
		pivotVec = closestPivot.transform.position;
		
		GameObject RealCamera = GameObject.FindGameObjectWithTag ("MainCamera"); 
		var BminusP = ballVec - pivotVec;

				var getSing = new Vector3 ();
				getSing = Vector3.Cross (new Vector3 (GetComponent<Rigidbody2D> ().velocity.x, GetComponent<Rigidbody2D> ().velocity.y, 0), BminusP);
				int Sing = -1;
				if (getSing.z <= 0) {
					Sing = 1;
					Debug.Log("Sing = -1");
				}
				
		var velocityDireccion = Sing *50.0f * closestPivot.transform.localScale.x * Vector3.Normalize (Vector3.Cross ( new Vector3 (0, 0, 1),BminusP));
				return new Vector2 (velocityDireccion.x, velocityDireccion.y);
			
	}


}
