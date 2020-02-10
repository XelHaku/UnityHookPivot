using UnityEngine;
using System.Collections;

public class DestroyOnContactTRAP : MonoBehaviour {
	public GameObject thisParticleEffect,burnParticleEffect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	//var score : int = 10;

	void OnTriggerEnter2D(Collider2D col) {

		if (col.gameObject.tag == "Ball") {
			//GameDataTracker.GameScore -= 50;
			if (GetComponent<Transform> ().CompareTag ("SpikeSeeker")) {
				Instantiate(thisParticleEffect,col.GetComponent<Transform>().position,Quaternion.identity );
				GameDataTracker.Lives -= 1;
				Destroy (gameObject);
			} else if (GetComponent<Transform> ().CompareTag ("Blackhole")) {
				GameDataTracker.Lives = 0;
			}
		} else if (col.gameObject.tag == "SpikeSeeker" && GetComponent<Transform> ().CompareTag ("SpikeSeeker")) {
			GameDataTracker.GameScore += 1;
			Instantiate(thisParticleEffect,col.GetComponent<Transform>().position,Quaternion.identity );
			Destroy (gameObject);
		} else if (col.gameObject.tag == "BlueWall") {
			Destroy (gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D col) {
		Debug.Log ("Collision" + gameObject.tag);

		if (col.gameObject.tag == "Ball") {
			if (GetComponent<Transform> ().CompareTag ("RedWall")) {
				Instantiate(burnParticleEffect,col.gameObject.transform.position,Quaternion.identity );
				GameDataTracker.Lives -= 1;
			}
		}
	}

	}

