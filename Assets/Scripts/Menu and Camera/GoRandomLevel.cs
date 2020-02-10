using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoRandomLevel : MonoBehaviour {
	

	public static void RandomLevel(){
		int LevelInt;
		string LevelName;
		bool FlagRigthLevel=true;
		do{
		LevelInt = Random.Range(GameDataTracker.ReachedLevels,4+GameDataTracker.ReachedLevels);
		LevelName = "Level_" +LevelInt.ToString();
			if (SceneManager.GetActiveScene ().name != LevelName || LevelInt<=14 ) {
				FlagRigthLevel =false;
			}
		}while(FlagRigthLevel);
		SceneManager.LoadScene (LevelName, LoadSceneMode.Single);

//		try{
//		SceneManager.LoadScene (LevelName, LoadSceneMode.Single);
//		}catch(UnityException ex){
//			Debug.Log (ex);
//			RandomLevel ();
//		}
	}
}
