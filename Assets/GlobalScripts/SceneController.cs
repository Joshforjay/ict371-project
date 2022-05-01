using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public struct baseScores
{
    public float score;
    public float time;
    public int numCollected;
    public char grade;
    public int difficulty;
}

public struct level3Scores
{
    public baseScores baseScores;
    public int covidCollected;
    public int infectedCollected;

}

public struct level4Scores
{
    public baseScores baseScores;
    public int correctMatches;
    public int incorrectMatches;
    public int numberEscaped;
}

public struct levelScores
{
    public baseScores level1;
    public baseScores level2;
    public level3Scores level3;
    public level4Scores level4;
}


public class SceneController : MonoBehaviour {
    levelScores scores;

    public GameObject scoreMenu, levelSelector;
    public GameObject scoreFirstButton, levelSelectorFirstButton;
    public levelScores Scores { get; }

    void Start() {
	}

	public void LoadScene(int index) {
		SceneManager.LoadScene(index);
	}

	public void NextScene() {
		LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void PreviousScene() {
		LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

	public void ShowScoreMenu() {
        scoreMenu.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);//clear selected obj
        EventSystem.current.SetSelectedGameObject(scoreFirstButton);

		//Instantiate(Resources.Load("ScoreMenu"));
    }

	public void HideScoreMenu() {
        scoreMenu.SetActive(false);
        //Destroy(GameObject.Find("ScoreMenu(Clone)"));
    }

	public void ShowLevelSelector() {
        levelSelector.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);//clear selected obj
        EventSystem.current.SetSelectedGameObject(levelSelectorFirstButton);

        //Debug.Log("showLevelSelector");
		//Instantiate(Resources.Load("LevelSelector"));
	}

	public void HideLevelSelector() {
        levelSelector.SetActive(false);
		//Destroy(GameObject.Find("LevelSelector(Clone)"));
	}

    public void SetLevel1Scores(baseScores bs)
    {
        scores.level1 = bs;
    }

    public void SetLevel2Scores(baseScores bs)
    {
        scores.level2 = bs;
    }

    public void SetLevel3Scores(level3Scores bs)
    {
        scores.level3 = bs;
    }

    public void SetLevel2Scores(level4Scores bs)
    {
        scores.level4 = bs;
    }
    

}
