using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class DontdestroyOnLoad : MonoBehaviour {

	static bool AudioBegin = false; 
	void Awake()
	{
		if (!AudioBegin) {
			GetComponent<AudioSource>().Play();
			DontDestroyOnLoad (gameObject);
			AudioBegin = true;
		} 
	}
	void Update () {
//		if(Application.loadedLevelName == "Upgraded")
//		{
//			//audio.Stop();
//			AudioBegin = false;
//		}
	}
}
