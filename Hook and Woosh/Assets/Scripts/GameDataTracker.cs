using UnityEngine;
using System.Collections;

public class GameDataTracker : MonoBehaviour {
	public static int GameScore;
	public static int Lives = 2;
	public static int ReachedLevels;
	void start(){
		Reset ();
		DontDestroyOnLoad (gameObject);
	}
	public static void Reset(){
		ReachedLevels = 0;
		Lives=2;
		GameScore = 0;
	}


}
