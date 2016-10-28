using UnityEngine;
using System.Collections;

public class SpawnBall : MonoBehaviour {
	public GameObject BlueBall;
	public GameObject GravityGlow;
	bool flag = true;
	// Use this for initialization
	void Start () {
	//Spawn Blueball
		ManageAchievements.IncreaseSpawnedLevels();
		ManageAchievements.CheckLevelReached (GameDataTracker.ReachedLevels);
		GetComponent<SpriteRenderer>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Time.realtimeSinceStartup >= 2.0 && flag == true) {
			Instantiate (GravityGlow);
			GameObject	activeBlueBall = (Instantiate(BlueBall,GetComponent<Rigidbody2D>().position,Quaternion.identity) as GameObject);
			//activeBlueBall.GetComponent<Rigidbody2D> ().position = GetComponent<Rigidbody2D> ().position;
			flag = false;
		}
		if (Time.realtimeSinceStartup >= 5.5) {
			//Destroy (gameObject);
			GetComponent<SpriteRenderer>().enabled = false;
			GetComponentInParent<SpriteRenderer>().enabled = false;
			GetComponentInChildren<SpriteRenderer>().enabled = false;
		}
	}
}
