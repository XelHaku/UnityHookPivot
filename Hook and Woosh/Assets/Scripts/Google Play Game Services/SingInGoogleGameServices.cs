using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class SingInGoogleGameServices : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build;
			// enables saving game progress.
			//.EnableSavedGames()
			// registers a callback to handle game invitations received while the game is not running.
			//.WithInvitationDelegate(<callback method>)
			// registers a callback for turn based match notifications received while the
			// game is not running.
			//.WithMatchDelegate(<callback method>)
			// require access to a player's Google+ social graph (usually not needed)
			//.RequireGooglePlus()
			//.Build();

		//PlayGamesPlatform.InitializeInstance(config);
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate();


		Social.localUser.Authenticate ((bool success) => {
		});


		// unlock achievement Welcome to Hook and Dash! (achievement ID "Cfjewijawiu_QA")
		Social.ReportProgress("CgkI7q_V8fMbEAIQDA", 100.0f, (bool success) => {
			// handle success or failure
		});
	}
	

}
//<?xml version="1.0" encoding="utf-8"?>
//	<!--
//	Google Play game services IDs.
//	Save this file as res/values/games-ids.xml in your project.
//	-->
//	<resources>
//	<string name="app_id">958821390318</string>
//	<string name="package_name">com.XonderSquare.HookandWoosh</string>
//	<string name="achievement_level_5">CgkI7q_V8fMbEAIQAg</string>
//	<string name="achievement_level_10">CgkI7q_V8fMbEAIQAw</string>
//	<string name="achievement_level_15">CgkI7q_V8fMbEAIQBA</string>
//	<string name="achievement_level_20">CgkI7q_V8fMbEAIQBQ</string>
//	<string name="achievement_level_25">CgkI7q_V8fMbEAIQBw</string>
//	<string name="achievement_level_30">CgkI7q_V8fMbEAIQCA</string>
//	<string name="achievement_level_40">CgkI7q_V8fMbEAIQCQ</string>
//	<string name="achievement_level_50">CgkI7q_V8fMbEAIQCg</string>
//	<string name="achievement_spawned_in_100_levels">CgkI7q_V8fMbEAIQBg</string>
//	<string name="achievement_spawned_in_500_levels">CgkI7q_V8fMbEAIQCw</string>
//	<string name="achievement_spawned_in_1000_levels">CgkI7q_V8fMbEAIQDQ</string>
//	<string name="achievement_welcome_to_hook_and_woosh">CgkI7q_V8fMbEAIQDA</string>
//	<string name="leaderboard_score">CgkI7q_V8fMbEAIQAA</string>
//	</resources>