using UnityEngine;
using System.Collections;
using StartApp;
using UnityEngine.SceneManagement;

public class StartApp_Init : MonoBehaviour {

	// Use this for initialization
	void Start () {
		#if UNITY_ANDROID
		StartAppWrapper.init();
		#endif
	}

	void OnGUI () {
		#if UNITY_ANDROID
		StartAppWrapper.showSplash(new StartAppWrapper.SplashConfig()
			.setTheme(StartAppWrapper.SplashConfig.Theme.OCEAN)
			.setAppName("Hook and Woosh")
			//.setLogo("XonderSquare360")
			.setOrientation(StartAppWrapper.SplashConfig.Orientation.AUTO)             
		);

		StartAppWrapper.showSplash();

		StartAppWrapper.init();
		//StartAppWrapper.loadAd();
		StartAppWrapper.loadAd(StartAppWrapper.AdMode.REWARDED_VIDEO);

		#endif
	}

}
