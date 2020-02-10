using UnityEngine;
using System.Collections;

public class GoToWebPage : MonoBehaviour {

	public string WebPage;
	// Use this for initialization
	public void GoToURL () {
		Application.OpenURL (WebPage);
	}

}
