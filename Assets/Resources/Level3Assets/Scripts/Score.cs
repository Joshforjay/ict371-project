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
    public HUDController hudController;
    public static bool instructionsBool = true;
    public static int infectedCellsLeft;
    public static int covidCellsLeft = 3;
    private int totalCells;
    float elapsedTime = 0;
    private bool endLevel = true;
    char rank;
    int difficuluty;

    void Awake()
    {
        difficuluty = PlayerPrefs.GetInt("difficulty");
        if (difficuluty == 0)
            difficuluty = 1;
        lungCount.setNoOfObjects(5 * difficuluty);
        totalCells = 5 * difficuluty;
        infectedCellsLeft = LungCellSpawner.numberOfObjects;
        hudController.set_TLTwo_name("Time: ");
    }

    // Update is called once per frame
    void Update()
    {
        if (infectedCellsLeft != 0)
        {
            elapsedTime += Time.deltaTime;
            //time.GetComponent<TMPro.TextMeshProUGUI>().text
            hudController.set_TLOne_num(totalCells - infectedCellsLeft);
            hudController.set_TLTwo_num((int)elapsedTime);
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
            + ", " + rank.ToString() + ", " + (3 - covidCellsLeft) + "\n";

        writer.WriteLine(str);

        writer.Close();
    }
}


