using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;


public class Pivot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	//	GetComponent<Animator> ().SetInteger("1",1);
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Animator> ().SetInteger("PivotMagenta_1",0);
		//http://answers.unity3d.com/questions/577314/how-to-detect-if-a-sprite-was-object-was-touched-i.html
			foreach (Touch touch in Input.touches) {
				if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved ) {
				Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
				Vector2 touchPos = new Vector2 (wp.x, wp.y);

					if (GetComponent<Collider2D> () == Physics2D.OverlapPoint (touchPos)) {
				
						//////////////////
						ApplyGravityForceToBall ("Ball");
						
						
					} else {
					
					}
			
			}


		}
		// For MOUSE
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		if(hit.collider == GetComponent<Collider2D>())
		{
			
			Debug.Log ("Target Position: " + hit.collider.gameObject.transform.position);
			ApplyGravityForceToBall ("Ball");


		} else {
			
		}
	
	}

	void ApplyGravityForceToBall(string ballType){
		
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
				tempGravityX += 50.0f * ballTag.GetComponent<SpriteRenderer> ().bounds.size.x * GetComponent<SpriteRenderer> ().bounds.size.x * RvecX / (Radius);
				tempGravityY += 50.0f * ballTag.GetComponent<SpriteRenderer> ().bounds.size.y * GetComponent<SpriteRenderer> ().bounds.size.y * RvecY / (Radius);
			}

			Vector2 gravityForce = new Vector2 ((float)tempGravityX, (float)tempGravityY);
			ballTag.GetComponent<Rigidbody2D> ().AddForce (gravityForce);
		}


	}
}
