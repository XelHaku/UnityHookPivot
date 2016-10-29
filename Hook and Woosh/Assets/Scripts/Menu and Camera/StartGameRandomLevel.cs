using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGameRandomLevel : MonoBehaviour {



	public  void RandomLevel(){
		int LevelInt = Random.Range(1,6);
		string LevelName = "Level_00" +LevelInt.ToString();
		Debug.Log(LevelName);
		//DELETE THIS LINE
		GameDataTracker.Lives = 6;
		//
		SceneManager.LoadScene (LevelName, LoadSceneMode.Single);

	}
}
