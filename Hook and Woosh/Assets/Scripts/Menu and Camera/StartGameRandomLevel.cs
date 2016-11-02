using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGameRandomLevel : MonoBehaviour {


	public  void GoToRandomLevel(){
		int LevelInt = Random.Range(1,7);
		string LevelName = "Level_00" +LevelInt.ToString();
		SceneManager.LoadScene (LevelName, LoadSceneMode.Single);
	}

	public static void RandomLevel(){
		int LevelInt = Random.Range(1,7);
		string LevelName = "Level_00" +LevelInt.ToString();
		SceneManager.LoadScene (LevelName, LoadSceneMode.Single);
	}





}
