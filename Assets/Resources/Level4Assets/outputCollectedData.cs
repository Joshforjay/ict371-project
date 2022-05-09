using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class outputCollectedData : MonoBehaviour
{
    public void outputData(string path, level4Scores l4)
    {
        l4.baseScores.numCollected = l4.correctMatches + l4.numberEscaped + l4.incorrectMatches;

        l4.incorrectMatches /= 2;
        l4.correctMatches /= 2;
        l4.baseScores.difficulty = PlayerPrefs.GetInt("difficulty");

        string file = Application.persistentDataPath + "/" + path;
        StreamWriter writer = new StreamWriter(file, true);
        writer.Write(System.DateTime.Now.ToString() + ',');
        writer.Write(l4.baseScores.difficulty.ToString() + ',');
        writer.Write(l4.baseScores.score.ToString() + ',');
        writer.Write(l4.baseScores.time.ToString() + ',');
        writer.Write(l4.baseScores.grade.ToString() + ',');
        writer.Write(l4.baseScores.numCollected.ToString() + ',');
        writer.Write(l4.correctMatches.ToString() + ',');
        writer.Write(l4.incorrectMatches.ToString() + ',');
        writer.Write(l4.numberEscaped.ToString() + ',');
        writer.Write("\n");

        /*
        writer.WriteLine("\n\n--Level 4 data--");
        writer.WriteLine("Completed on: " + System.DateTime.Now.ToString());
        writer.WriteLine("Difficulty: " + l4.baseScores.difficulty.ToString());
        writer.WriteLine("Overall score: " + l4.baseScores.score.ToString());
        writer.WriteLine("Overall time: " + l4.baseScores.time.ToString());
        writer.WriteLine("Ranking: " + l4.baseScores.grade.ToString());
        writer.WriteLine("Overall collected: " + l4.baseScores.numCollected.ToString());
        writer.WriteLine("Correct matches: " + l4.correctMatches.ToString());
        writer.WriteLine("Incorrect matches: " + l4.incorrectMatches.ToString());
        writer.WriteLine("Number escaped: " + l4.numberEscaped.ToString());
        */
        Debug.Log(Application.persistentDataPath);

        writer.Close();
    }
}
