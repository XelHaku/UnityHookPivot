using UnityEngine;
using System.Collections;

public class ScrollerCommand : MonoBehaviour {
	public float ScrollerSpeed = -1f;
	// Use this for initialization
	void Start () {
		Rigidbody2D elementRigid = GetComponent<Rigidbody2D> ();
		elementRigid.velocity = new Vector2 (ScrollerSpeed,0.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
