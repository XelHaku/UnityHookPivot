using UnityEngine;
using System.Collections;

public class PlayBallSounds : MonoBehaviour {
	public AudioClip JewelPing;
	public AudioClip WallBop;
	public AudioClip RedBurn;
	public AudioClip Explosion;
	
	private AudioSource source;
	private float lowPitchRange = .75F;
	private float highPitchRange = 1.5F;
	private float velToVol = .2F;
	private float velocityClipSplit = 10F;
	
	
	void Awake () {
	
		source = GetComponent<AudioSource>();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		source.pitch = Random.Range (lowPitchRange, highPitchRange);
		float hitVol = Random.Range (0.5f, 0.9f);
		if (col.gameObject.tag == "Jewel") {
			source.PlayOneShot (JewelPing, hitVol);
		}else if(col.gameObject.tag == "SpikeSeeker"){
			source.PlayOneShot (Explosion, hitVol);
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		source.pitch = Random.Range (lowPitchRange, highPitchRange);
		float hitVol = Random.Range (0.5f, 0.9f);
		//Debug.Log ("BOPSOUND");


		if (col.gameObject.tag == "RedWall") {
			source.PlayOneShot (RedBurn, hitVol);
		}
	}
}

//
//void OnCollisionEnter (Collision coll)
//{
//	source.pitch = Random.Range (lowPitchRange,highPitchRange);
//	float hitVol = coll.relativeVelocity.magnitude * velToVol;
//	if (coll.relativeVelocity.magnitude < velocityClipSplit)
//		source.PlayOneShot(crashSoft,hitVol);
//	else 
//		source.PlayOneShot(crashHard,hitVol);
//}
//
//}
