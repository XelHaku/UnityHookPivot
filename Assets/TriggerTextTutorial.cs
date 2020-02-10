using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TriggerTextTutorial : MonoBehaviour {
	public GameObject Text;
		// Use this for initialization

	void Update(){
		
	}
	void OnTriggerEnter2D(Collider2D col)
	{Debug.Log ("Collider");
		if (col.gameObject.tag == "Ball") {
			
			Text.GetComponent<Text> ().enabled = true;
			StartCoroutine (DissapearText (10));
		}

	}

	IEnumerator	DissapearText(float SecondsTime){
		//Debug.Log("Slider colider deacti");

		yield return new WaitForSeconds(SecondsTime);
		Text.GetComponent<Text> ().enabled = false;
	}


}
