using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialTextManagement : MonoBehaviour {
	public GameObject TextNo_01;
	public GameObject TextNo_02;
	public GameObject TextNo_03;
	public GameObject TextNo_04;
	public GameObject TextNo_05;
	public GameObject TextNo_06;
	public GameObject TextNo_07;
	public GameObject TextNo_08;
	public GameObject TextNo_09;

	static bool flag1 = true;
	static bool flag2 = true;
	void Start () {
		TextNo_01.GetComponent<Text> ().enabled = false;
		TextNo_02.GetComponent<Text> ().enabled = false;
		TextNo_03.GetComponent<Text> ().enabled = false;
		TextNo_04.GetComponent<Text> ().enabled = false;
		TextNo_05.GetComponent<Text> ().enabled = false;
		TextNo_06.GetComponent<Text> ().enabled = false;
		TextNo_07.GetComponent<Text> ().enabled = false;
		TextNo_08.GetComponent<Text> ().enabled = false;
		TextNo_09.GetComponent<Text> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (BallPivotMechanicsOnTouch.BallState == "Free") {
			if (flag1) {
				TextNo_01.GetComponent<Text> ().enabled = true;
			} else {
				TextNo_01.GetComponent<Text> ().enabled = false;
			}
			TextNo_02.GetComponent<Text> ().enabled = false;
			TextNo_04.GetComponent<Text> ().enabled = false;
			TextNo_05.GetComponent<Text> ().enabled = false;

		}else if(BallPivotMechanicsOnTouch.BallState == "Hooked"){
			if (flag1) {
				TextNo_02.GetComponent<Text> ().enabled = true;
			}else {
				TextNo_02.GetComponent<Text> ().enabled = false;
			}
			TextNo_01.GetComponent<Text> ().enabled = false;
		
		}else if(BallPivotMechanicsOnTouch.BallState == "Sliding" && flag2){
			TextNo_01.GetComponent<Text> ().enabled = false;
			TextNo_02.GetComponent<Text> ().enabled = false;
			TextNo_03.GetComponent<Text> ().enabled = false;

			TextNo_04.GetComponent<Text> ().enabled = true;
			TextNo_05.GetComponent<Text> ().enabled = true;

		}
	
		if (TextNo_06.GetComponent<Text> ().enabled == true) {
			flag2 = false;
			flag1 = false;
		}
	}



}
