using UnityEngine;
using System.Collections;

public class ShowPauseCanvas : MonoBehaviour {

	public void ShowCanvas(){
		Debug.Log ("ShowCanvas");
		GameObject PauseCanvas = GameObject.FindGameObjectWithTag("PauseCanvas");
		PauseCanvas.GetComponent<Canvas> ().enabled = !PauseCanvas.GetComponent<Canvas> ().enabled;
		
		
	}
}
