using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level2Score : MonoBehaviour {
	public static uint score;
	public static float timeElapsed;

	[SerializeField]
	TMP_Text _timeText;

	[SerializeField]
	TMP_Text _bCellText;

	// Start is called before the first frame update
	void Start() {
		score = 0;
	}

	// Update is called once per frame
	void Update() {
		timeElapsed = Time.time;

		_timeText.text = "Time Elapsed: " + timeElapsed.ToString();
		_bCellText.text = "B Cells Count: " + score.ToString();
	}

	void OnEnable() {
		TCellCollision.OnDead += EnterDeadState;
		TCellCollision.OnBCellCollect += IncrementBCellCount;
	}

	void OnDisable() {
		TCellCollision.OnDead -= EnterDeadState;
		TCellCollision.OnBCellCollect -= IncrementBCellCount;
	}

	void EnterDeadState() {
		enabled = false;
	}
	void IncrementBCellCount() {
		++score;
	}
}
