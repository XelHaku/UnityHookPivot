using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGameRandomLevel : MonoBehaviour {


	public  void GoToRandomLevel(){
		GameDataTracker.Lives =3;
		if (GameDataTracker.AD_Reward) {
			GameDataTracker.Lives =6;
			GameDataTracker.AD_Reward=false;
		}
		int LevelInt = Random.Range(1,5);
		string LevelName = "Level_" +LevelInt.ToString();
		SceneManager.LoadScene (LevelName, LoadSceneMode.Single);
	}

	public static void RandomLevel(){
		GameDataTracker.Lives = 3;
		int LevelInt = Random.Range(1,5);
		string LevelName = "Level_" +LevelInt.ToString();
		SceneManager.LoadScene (LevelName, LoadSceneMode.Single);
	}





}
