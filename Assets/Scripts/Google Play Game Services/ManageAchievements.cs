using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
public class ManageAchievements : MonoBehaviour {

	// Use this for initialization
	public static	void CheckLevelReached (int actualLevel) {
		if (actualLevel == 5) {
			Social.ReportProgress("CgkI7q_V8fMbEAIQAg", 100.0f, (bool success) => {
				// handle success or failure
			});
		} else if (actualLevel == 10) {
			Social.ReportProgress("CgkI7q_V8fMbEAIQAw", 100.0f, (bool success) => {
				// handle success or failure
			});
		}else if (actualLevel == 15) {
			Social.ReportProgress("CgkI7q_V8fMbEAIQBA", 100.0f, (bool success) => {
				// handle success or failure
			});
		}else if (actualLevel == 20) {
			Social.ReportProgress("CgkI7q_V8fMbEAIQBQ", 100.0f, (bool success) => {
				// handle success or failure
			});
		}else if (actualLevel == 25) {
			Social.ReportProgress("CgkI7q_V8fMbEAIQBw", 100.0f, (bool success) => {
				// handle success or failure
			});
		}else if (actualLevel == 30) {
			Social.ReportProgress("CgkI7q_V8fMbEAIQCA", 100.0f, (bool success) => {
				// handle success or failure
			});
		}else if (actualLevel == 40) {
			Social.ReportProgress("CgkI7q_V8fMbEAIQCQ", 100.0f, (bool success) => {
				// handle success or failure
			});
		}else if (actualLevel == 50) {
			Social.ReportProgress("CgkI7q_V8fMbEAIQCg", 100.0f, (bool success) => {
				// handle success or failure
			});
		}
	
	}
	
	// Update is called once per frame
	public static	void IncreaseSpawnedLevels () {
		#if UNITY_ANDROID && !UNITY_EDITOR
	//Increase by +1 each time the player spawn a level
		// increment achievement (achievement 100 Spawned Levels) by 1 steps
		PlayGamesPlatform.Instance.IncrementAchievement(
			"CgkI7q_V8fMbEAIQBg", 1, (bool success) => {
				// handle success or failure
			});

		// increment achievement (achievement 100 Spawned Levels) by 1 steps
		PlayGamesPlatform.Instance.IncrementAchievement(
			"CgkI7q_V8fMbEAIQCw", 1, (bool success) => {
				// handle success or failure
			});

		// increment achievement (achievement 100 Spawned Levels) by 1 steps
		PlayGamesPlatform.Instance.IncrementAchievement(
			"CgkI7q_V8fMbEAIQDQ", 1, (bool success) => {
				// handle success or failure
			});
		#endif
	}


	public static void ReportScoreToLeaderboard(int Score){
		// post score Score to leaderboard ID "CgkI7q_V8fMbEAIQAA" )
		#if UNITY_ANDROID && !UNITY_EDITOR
		Social.ReportScore(Score, "CgkI7q_V8fMbEAIQAA", (bool success) => {});
		#endif
	}
}
