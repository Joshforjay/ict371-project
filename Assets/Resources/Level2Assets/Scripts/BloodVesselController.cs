using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BloodVesselController : MonoBehaviour {
	public static float moveSpeed = 10f;
	public static float moveSpeedIncrement;

	[SerializeField]
	float despawnPosition;

	// Start is called before the first frame update
	void Start() {
		int difficulty = PlayerPrefs.GetInt("difficulty");

		switch (difficulty) {
			case 1:
				moveSpeedIncrement = 0.001f;
				break;

			case 2:
				moveSpeedIncrement = 0.002f;
				break;

			case 3:
				moveSpeedIncrement = 0.003f;
				break;
		}
	}

	// Update is called once per frame
	void Update() {
		transform.position -= new Vector3(0, 0, moveSpeed * Time.deltaTime);

		if (transform.position.z < despawnPosition) {
			Destroy(gameObject);
		}
	}

	private void FixedUpdate() {
		moveSpeed += moveSpeedIncrement;
	}
}
