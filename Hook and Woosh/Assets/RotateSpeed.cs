using UnityEngine;
using System.Collections;

public class RotateSpeed : MonoBehaviour {
	public float rotationsPerminute;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (0,0, 6.0f * rotationsPerminute * Time.deltaTime);
	}
}
