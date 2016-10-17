using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class GoSceneNumber : MonoBehaviour {

	public void goScene(int SceneNumber){
		SceneManager.LoadScene (SceneNumber, LoadSceneMode.Single);
		Time.timeScale = 1;
	}
}
