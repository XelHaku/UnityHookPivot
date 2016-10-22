using UnityEngine;
using System.Collections;

public class GameDataTracker : MonoBehaviour {
	public static int GameScore=0;
	public static int Lives = 3;
	public static int ReachedLevels=1;
	void start(){
		Reset ();
		DontDestroyOnLoad (gameObject);

	}
	public static void Reset(){
		ReachedLevels = 1;
		Lives=3;
		GameScore = 0;
	}


}
