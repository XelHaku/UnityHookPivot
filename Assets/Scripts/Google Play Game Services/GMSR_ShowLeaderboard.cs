using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GMSR_ShowLeaderboard : MonoBehaviour {

	// Use this for initialization
	public void ShowLeaderboard () {
		//Social.ShowLeaderboardUI();
		#if UNITY_ANDROID && !UNITY_EDITOR
		PlayGamesPlatform.Instance.ShowLeaderboardUI ("CgkI7q_V8fMbEAIQAA");
		#endif
	}
	

}
