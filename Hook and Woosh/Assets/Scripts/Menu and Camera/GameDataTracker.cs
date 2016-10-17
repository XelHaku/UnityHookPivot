using UnityEngine;
using System.Collections;

public class GameDataTracker : MonoBehaviour {
	public static int GameScore=0;
	public static int Lives = 2;
	public static int ReachedLevels=1;
	void start(){
		Reset ();
		DontDestroyOnLoad (gameObject);
	}
	public static void Reset(){
		ReachedLevels = 1;
		Lives=2;
		GameScore = 0;
	}


}
