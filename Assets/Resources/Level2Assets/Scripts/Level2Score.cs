using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using System.IO;

public class Level2Score : MonoBehaviour {
	public static int score;
	public static float timeElapsed;

	[SerializeField]
	TMP_Text _timeText;

	[SerializeField]
	TMP_Text _bCellText;

	[SerializeField]
	ScoreController _scoreController;

	bool _isDeadState = false;
	baseScores _level2Score;

	// Start is called before the first frame update
	void Start() {
		_isDeadState = false;
		timeElapsed = 0;
		score = 0;
	}

	// Update is called once per frame
	void Update() {
		if (!_isDeadState) {
			timeElapsed += Time.deltaTime;
			timeElapsed = Mathf.Round(timeElapsed * 100f) / 100f;
		}

		_timeText.text = "Time Elapsed: " + timeElapsed.ToString() + "s";
		_bCellText.text = "Score: " + score.ToString();
	}

	void OnEnable() {
		TCellCollision.OnDead += EnterDeadState;
		TCellCollision.OnBCellCollect += IncrementBCellCount;
	}

	void OnDisable() {
		TCellCollision.OnDead -= EnterDeadState;
		TCellCollision.OnBCellCollect -= IncrementBCellCount;
	}

	void IncrementBCellCount() {
		++score;
	}

	void EnterDeadState() {
		_isDeadState = true;

		CalculateScore();
		WriteScoreData("level2Data.csv");

		_scoreController.set_rank_value(_level2Score.grade);
		_scoreController.set_score_value(_level2Score.score);
	}

	void CalculateScore() {
		_level2Score.numCollected = score;
		_level2Score.time = timeElapsed;
		_level2Score.score = score * timeElapsed;
		_level2Score.difficulty = PlayerPrefs.GetInt("difficulty");

		if (_level2Score.score >= 2000) {
			_level2Score.grade = 'S';
		} else if (_level2Score.score >= 1000) {
			_level2Score.grade = 'A';
		} else if (_level2Score.score >= 750) {
			_level2Score.grade = 'B';
		} else if (_level2Score.score >= 500) {
			_level2Score.grade = 'C';
		} else if (_level2Score.score >= 250) {
			_level2Score.grade = 'D';
		} else if (_level2Score.score >= 100) {
			_level2Score.grade = 'E';
		} else {
			_level2Score.grade = 'F';
		}
	}

	void WriteScoreData(string fileName) {
		string filePath = Application.persistentDataPath + "/" + fileName;

		StreamWriter writer = new StreamWriter(filePath, true);

		string csv = _level2Score.difficulty.ToString();
		csv += ", " + _level2Score.score.ToString();
		csv += ", " + _level2Score.time.ToString();
		csv += ", " + _level2Score.numCollected.ToString();
		csv += ", " + _level2Score.grade;

		writer.WriteLine(csv);

		writer.Close();
	}
}
