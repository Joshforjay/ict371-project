using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DifficultyChangeText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI difficultyText;

    // Update is called once per frame
    void Update()
    {
        int diff = PlayerPrefs.GetInt("difficulty");
        string text = "Difficulty selected: ";

        switch(diff)
        {
            case 1:
                text = text + "Easy";
                break;
            case 2:
                text = text + "Medium";
                break;
            case 3:
                text = text + "Hard";
                break;
            default:
                text = text + "Non selected";
                break;
        }

        difficultyText.text = text;
    }
}
