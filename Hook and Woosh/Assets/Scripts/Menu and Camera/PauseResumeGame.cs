using UnityEngine;
using System.Collections;

public class PauseResumeGame : MonoBehaviour {

	public void PauseResume(){
		Debug.Log ("PauseResume");
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}
			else {
				Time.timeScale=0;

		}
	}
}
