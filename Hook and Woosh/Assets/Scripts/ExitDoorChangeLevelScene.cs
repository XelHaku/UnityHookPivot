using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitDoorChangeLevelScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) 
	{
		Debug.Log("EXIT DOOR?");
		if (col.gameObject.tag == "ExitDoor") {

			//CheckJewell
			GameObject [] JewelsCount = GameObject.FindGameObjectsWithTag("Jewel");
			if (JewelsCount.Length == 0) {
			// IF THERE ARE NOT JEWELS GO TO NEXT RANDOM LEVEL
//				int LevelInt = Random.Range(1,2);
//				string LevelName = "Level_00" +LevelInt.ToString();
//				Debug.Log(LevelName);
//				SceneManager.LoadScene (LevelName, LoadSceneMode.Single);
				//StartGameRandomLevel.RandomLevel();
				GoRandomLevel.RandomLevel();
			}
		}



	}
}
