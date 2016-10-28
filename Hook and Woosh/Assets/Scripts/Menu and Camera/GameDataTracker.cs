using UnityEngine;
using System.Collections;

public class GameDataTracker : MonoBehaviour {
	public static int GameScore=0;
	public static int Lives = 3;
	public static int ReachedLevels=1;
	public static int GameRuns=1;
	public static bool AD_AlreadyShown;
	void start(){
		Reset ();
		DontDestroyOnLoad (gameObject);

	}
	public static void Reset(){
		ReachedLevels = 1;
		Lives=3;
		GameScore = 0;
		GameRuns += 1;
		AD_AlreadyShown = false;
	}


}
