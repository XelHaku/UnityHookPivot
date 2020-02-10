using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;using StartApp;
public class GoSceneName : MonoBehaviour {
	public void goScene(string SceneName){
		#if UNITY_ANDROID
		StartAppWrapper.removeBanner(StartAppWrapper.BannerPosition.TOP);
		#endif
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneName, LoadSceneMode.Single);

	}
}
