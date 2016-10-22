using UnityEngine;
using System.Collections;

public class ScrollerCommand : MonoBehaviour {
	public float ScrollerSpeed;
	 GameObject BallPlayer, Entrance;
	Rigidbody2D elementRigid; 
	private Vector2 refVelocity = Vector2.zero; 
	// Use this for initialization
	void Start () {
		elementRigid = GetComponent<Rigidbody2D> ();
		//elementRigid.velocity = new Vector2 (ScrollerSpeed,0.0f);
		Entrance = GameObject.FindGameObjectWithTag ("EntranceDoor");
		if (Entrance != null) {
			elementRigid.position = new Vector2 (Entrance.GetComponent<Rigidbody2D> ().position.x, 0.0f);
		}
	}

	// Update is called once per frame
	void Update () {
		
			if (BallPlayer != null) {
						if (BallPivotMechanicsOnTouch.BallState != "Hooked") {
							//elementRigid.position = new Vector2 (BallPlayer.GetComponent<Rigidbody2D> ().position.x, 0.0f);
							//elementRigid.MovePosition (new Vector2 (BallPlayer.GetComponent<Rigidbody2D> ().position.x, 0.0f));
				elementRigid.position = Vector2.SmoothDamp (elementRigid.position,new Vector2(BallPlayer.GetComponent<Rigidbody2D> ().position.x, 0.0f), ref refVelocity,0.3f);
			} else { elementRigid.position = Vector2.SmoothDamp (elementRigid.position,new Vector2(BallPivotMechanicsOnTouch.actualPivot.GetComponent<Rigidbody2D> ().position.x, 0.0f), ref refVelocity,1.0f);}
			} else {
				BallPlayer = GameObject.FindGameObjectWithTag ("Ball");
			}
		


		}
}
