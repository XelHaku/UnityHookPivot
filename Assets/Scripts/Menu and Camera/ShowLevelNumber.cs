﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ShowLevelNumber : MonoBehaviour {
	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		text.text = "Level " + GameDataTracker.ReachedLevels;
	}
}