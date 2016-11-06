using UnityEngine;
using System.Collections;
using StartApp;

public class VideoRewardAd : MonoBehaviour {
	void Start () {
		#if UNITY_ANDROID
		var videoListener = new VideoListenerImplementation ();
		StartAppWrapper.setVideoListener (videoListener);
		StartAppWrapper.loadAd(StartAppWrapper.AdMode.REWARDED_VIDEO);
		#endif
	}
	// Use this for initialization
	public void ShowAdd () {
		
		#if UNITY_ANDROID
		StartAppWrapper.loadAd(StartAppWrapper.AdMode.REWARDED_VIDEO);
		StartAppWrapper.showAd();
		StartAppWrapper.loadAd(StartAppWrapper.AdMode.REWARDED_VIDEO);
		#endif

		#if UNITY_EDITOR
		GameDataTracker.AD_Reward=true;
		#endif

	
	}

	#if UNITY_ANDROID
	public class VideoListenerImplementation : StartAppWrapper.VideoListener {
	public void onVideoCompleted() {
	// Grant user with the reward
	GameDataTracker.AD_Reward=true;
	//Debug.Log (GameDataTracker.AD_Reward);


	}
	}
	#endif

}
