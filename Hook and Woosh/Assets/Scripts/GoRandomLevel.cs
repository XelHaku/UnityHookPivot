using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoRandomLevel : MonoBehaviour {


	public static void RandomLevel(){
		int LevelInt = Random.Range(1,2);
		string LevelName = "Level_00" +LevelInt.ToString();
		Debug.Log(LevelName);
		SceneManager.LoadScene (LevelName, LoadSceneMode.Single);

	}
}
