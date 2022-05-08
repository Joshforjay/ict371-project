using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2SceneController : MonoBehaviour {
	[SerializeField]
	SceneController sceneController;

	// Update is called once per frame
	void Update() {
		if (sceneController.isPaused) {
			Time.timeScale = 0f;
		} else {
			Time.timeScale = 1f;
		}
	}
}
