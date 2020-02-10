using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TurnOFFAdReward : MonoBehaviour {
	public GameObject Text2X;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameDataTracker.AD_Reward) {
			GetComponent<Button> ().enabled = false;
			GetComponent<Image> ().enabled = false ;
			Text2X.GetComponent<Text> ().enabled = true;
		} else {
			GetComponent<Button> ().enabled = true;
			GetComponent<Image> ().enabled = true ;
			Text2X.GetComponent<Text> ().enabled = false;
		}
	}
}
