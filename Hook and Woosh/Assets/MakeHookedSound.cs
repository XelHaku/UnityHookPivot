using UnityEngine;
using System.Collections;

public class MakeHookedSound : MonoBehaviour {
	public AudioClip HookedPivotSound;


	private AudioSource source;

	private float lowPitchRange = 0.75F;
	private float highPitchRange = 0.8f;
	void Awake () {

		source = GetComponent<AudioSource>();
	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (BallPivotMechanicsOnTouch.BallState == "Hooked" && !source.isPlaying) {
			source.pitch = Random.Range (lowPitchRange, highPitchRange);
			float hitVol = Random.Range (0.1f, 0.3f);
			source.PlayOneShot (HookedPivotSound, hitVol);
		
		} else if(BallPivotMechanicsOnTouch.BallState == "Free") {
			source.Stop();
		}
	}
}
