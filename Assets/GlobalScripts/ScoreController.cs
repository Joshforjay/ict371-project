using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI ScoreText, RankText;
    [SerializeField]
    char rank_ = 'F';
    [SerializeField]
    GameObject FailButton, PASSButton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rank_ == 'F')
        {

        }
        else
        {

        }



    }

    public void set_score_value(float val)
    {
        ScoreText.text = "Score\t: " + val;
    }

    public void set_rank_value(char rank)
    {
        rank_ = rank;
        RankText.text = "Rank\t: " + rank;

    }

}
