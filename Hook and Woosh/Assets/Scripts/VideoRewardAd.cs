using UnityEngine;
using System.Collections;
using StartApp;





public class VideoRewardAd : MonoBehaviour {

	// Use this for initialization
	public void ShowAdd () {

		#if UNITY_ANDROID
		StartAppWrapper.init();
		StartAppWrapper.loadAd();

		StartAppWrapper.showAd();
		StartAppWrapper.loadAd();


		#endif
		GameDataTracker.Lives = 6;

		StartGameRandomLevel.RandomLevel ();
	}


}
