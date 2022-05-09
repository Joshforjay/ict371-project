using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2SceneController : MonoBehaviour {
	public static SceneController sceneController;

	void Awake() {
		BloodVesselController.moveSpeed = 10f;
		sceneController = FindObjectOfType<SceneController>();
	}

	// Update is called once per frame
	void Update() {
		if (sceneController.isPaused) {
			Time.timeScale = 0f;
		} else {
			Time.timeScale = 1f;
		}
	}
	public static bool isPaused() {
		return sceneController.isPaused;
	}
}
