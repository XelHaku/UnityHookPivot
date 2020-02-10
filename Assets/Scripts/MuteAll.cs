using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MuteAll : MonoBehaviour {
	public GameObject SoundONButton, SoundOFFButton;

	// Use this for initialization
	void Start () {
		GameObject BackgroundMusic = GameObject.FindGameObjectWithTag ("BackgroundMusic");
		if (AudioListener.volume != 0) {
			SoundONButton.GetComponent<Image> ().enabled = true;
			SoundOFFButton.GetComponent<Image> ().enabled = false;
		} else {
			SoundONButton.GetComponent<Image> ().enabled = false;
			SoundOFFButton.GetComponent<Image> ().enabled = true;
		}
		DontDestroyOnLoad (gameObject);
	}

	// Update is called once per frame
	public void SoundON(){
		SoundONButton.GetComponent<Image> ().enabled = true;
		SoundOFFButton.GetComponent<Image> ().enabled = false;
		GameObject BackgroundMusic = GameObject.FindGameObjectWithTag ("BackgroundMusic");
		AudioListener.volume = 1;
	}

	public void SoundOFF(){
		SoundOFFButton.GetComponent<Image> ().enabled = true;

		SoundONButton.GetComponent<Image> ().enabled = false;

		GameObject BackgroundMusic = GameObject.FindGameObjectWithTag ("BackgroundMusic");
		AudioListener.volume = 0;
	}
}