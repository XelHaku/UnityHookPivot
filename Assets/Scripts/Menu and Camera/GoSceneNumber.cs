using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;using StartApp;
public class GoSceneNumber : MonoBehaviour {

	public void goScene(int SceneNumber){
		#if UNITY_ANDROID
		StartAppWrapper.removeBanner(StartAppWrapper.BannerPosition.TOP);
		#endif
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneNumber, LoadSceneMode.Single);

	}
}
