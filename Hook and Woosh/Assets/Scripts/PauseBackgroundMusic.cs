using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PauseBackgroundMusic : MonoBehaviour {
	public GameObject MusicONButton, MusicOFFButton;

	// Use this for initialization
	void Start () {
		GameObject BackgroundMusic = GameObject.FindGameObjectWithTag ("BackgroundMusic");
		if (BackgroundMusic.GetComponent<AudioSource> ().isPlaying) {
			MusicONButton.GetComponent<Image> ().enabled = true;
			MusicOFFButton.GetComponent<Image> ().enabled = false;
		} else {
			MusicONButton.GetComponent<Image> ().enabled = false;
			MusicOFFButton.GetComponent<Image> ().enabled = true;
		}
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	public void MusicON(){
		MusicONButton.GetComponent<Image> ().enabled = true;
		MusicOFFButton.GetComponent<Image> ().enabled = false;
		GameObject BackgroundMusic = GameObject.FindGameObjectWithTag ("BackgroundMusic");
		BackgroundMusic.GetComponent<AudioSource> ().Play ();
	}

	public void MusicOFF(){
		MusicOFFButton.GetComponent<Image> ().enabled = true;

		MusicONButton.GetComponent<Image> ().enabled = false;

		GameObject BackgroundMusic = GameObject.FindGameObjectWithTag ("BackgroundMusic");
		BackgroundMusic.GetComponent<AudioSource> ().Pause ();
	}
}
