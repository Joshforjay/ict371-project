using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    private LungCellSpawner lungCount = new LungCellSpawner();
    public SceneController sceneController;
    public ScoreController scoreController;
    public Text displayText1, displayText2;
    public static bool instructionsBool = true;
    public static int infectedCellsLeft;
    float elapsedTime = 0;
    private bool endLevel = true;
    char rank;
    int difficuluty;

    void Awake()
    {
        infectedCellsLeft = LungCellSpawner.numberOfObjects;
        difficuluty = PlayerPrefs.GetInt("difficulty");
        if (difficuluty == 0)
            difficuluty = 1;
        lungCount.setNoOfObjects(5 * difficuluty);
    }

    // Update is called once per frame
    void Update()
    {
        if (infectedCellsLeft != 0)
        {
            elapsedTime += Time.deltaTime;
        }
        else if(endLevel)
        {
            ScoreCalculator();
            SendDataToFile("Level3Data.csv");
            scoreController.set_score_value(elapsedTime);
            scoreController.set_rank_value(rank);
            sceneController.ShowScoreMenu();
            endLevel = false;
        }
         

        displayText1.text = "Time: " + elapsedTime.ToString();
        displayText2.text = "Remaining infected cells: " + infectedCellsLeft.ToString();
            
    }

    void ScoreCalculator()
    {

        if (elapsedTime < 20)
            rank = 'S';
        else if (elapsedTime < 30)
            rank = 'A';
        else if (elapsedTime < 40)
            rank = 'B';
        else if (elapsedTime < 50)
            rank = 'C';
        else if (elapsedTime < 60)
            rank = 'D';
        else if (elapsedTime < 70)
            rank = 'E';
        else if (elapsedTime >= 80)
            rank = 'F';

    }

    void SendDataToFile(string fileName)
    {
        string file = Application.persistentDataPath + "/" + fileName;
        StreamWriter writer = new StreamWriter(file, true);
        string str = System.DateTime.Now.ToString() + ", " +
            difficuluty.ToString() + ", " + elapsedTime.ToString()
            + ", " + rank.ToString();

        writer.WriteLine(str);
        //writer.WriteLine("\nLevel 3 data: ");
        //writer.WriteLine("Completed time: " + System.DateTime.Now.ToString());
        //writer.WriteLine("Difficulty: " + difficuluty.ToString());
        //writer.WriteLine("Overall time: " + elapsedTime.ToString());
        //writer.WriteLine("Ranking: " + rank.ToString());

        //Debug.Log(Application.persistentDataPath);

        writer.Close();
    }
}


