using UnityEngine;
using System.Collections;

public class BlueBall : MonoBehaviour {

	// Use this for initialization
	private float minX, maxX, minY, maxY;
	private float playerRadius;

	void Start(){
		// If you want the min max values to update if the resolution changes 
		// set them in update else set them in Start
		CircleCollider2D playerCollider = GetComponent<CircleCollider2D>();
		playerRadius = playerCollider.bounds.extents.x;
		Rigidbody2D blueBallRigid = GetComponent<Rigidbody2D> ();

		blueBallRigid.AddForce( new Vector2 (8f, 0.0f));


		float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
		Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0,0, camDistance));
		Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1,1, camDistance));

		minX = bottomCorner.x + playerRadius;
		maxX = topCorner.x - playerRadius;
		minY = bottomCorner.y + playerRadius;
		maxY = topCorner.y - playerRadius;
	}

	void Update(){

		// Get current position
		Vector3 pos = transform.position;

		// Horizontal contraint
	//	if(pos.x < minX) pos.x = minX;
	//	if(pos.x > maxX) pos.x = maxX;

		// vertical contraint
	//	if(pos.y < minY) pos.y = minY;
		//if(pos.y > maxY) pos.y = maxY;

		// Update position
		transform.position = pos;
	}
}
