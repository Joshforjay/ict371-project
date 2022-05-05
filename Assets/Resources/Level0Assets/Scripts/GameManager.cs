using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int difficulty = 1;
    public Text diffLabel;
    public SceneController sc;
    private void OnEnable()
    {
        PlayerPrefs.SetInt("difficulty", difficulty);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DifficultySelect(int selection)
    {
        difficulty = selection;
        switch (difficulty)
        {
            case 1:
                diffLabel.text = "Difficulty: Booster.";
                break;
            case 2:
                diffLabel.text = "Difficulty: Double Vax.";
                break;
            case 3:
                diffLabel.text = "Difficulty: Single Vax.";
                break;
            default:
                break;
        }
        PlayerPrefs.SetInt("difficulty", difficulty);
    }

    public void LoadScene(int l)
    {
        sc.LoadScene(l);
    }
}
