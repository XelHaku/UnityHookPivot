using UnityEngine;
using System.Collections;
using StartApp;
public class PauseResumeGame : MonoBehaviour {

	public void PauseResume(){
		Debug.Log ("PauseResume");
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
			#if UNITY_ANDROID
			StartAppWrapper.removeBanner(StartAppWrapper.BannerPosition.TOP);
			#endif

		}
			else {
			#if UNITY_ANDROID
			StartAppWrapper.addBanner( 
				StartAppWrapper.BannerType.AUTOMATIC,
				StartAppWrapper.BannerPosition.TOP);
			#endif
				Time.timeScale=0;

		}
	}
}
