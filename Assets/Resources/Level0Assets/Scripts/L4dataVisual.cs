using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class L4dataVisual : MonoBehaviour
{
    [SerializeField]
    private WindowGraph window_graph;

    bool data_processed = false;

    [SerializeField]
    private string file_name = "level4Data.csv";

    private List<float> score;
    private List<int> num_matched;
    private List<int> num_incorrect_matched;
    private List<int> num_missed;
    private List<int> difficulty;
    [SerializeField]
    private bool[] shown_data;


    // Start is called before the first frame update

    void Awake()
    {
        score = new List<float>();
        num_matched = new List<int>();
        num_missed = new List<int>();
        num_incorrect_matched = new List<int>();
        difficulty = new List<int>();

        shown_data = new bool[5];
        for(int count = 0; count < shown_data.Length; count++)
        {
            shown_data[count] = true;
        }

        read_data();

        create_graph();


        data_processed = true;
    }

    private void read_data()
    {
        string file = Application.persistentDataPath + "/" + file_name;
        StreamReader writer = new StreamReader(file, true);
        string line;
        string[] contents;


        while (!writer.EndOfStream)
        {
            line = writer.ReadLine();
            contents = line.Split(',');

            if (contents.Length != 10) { continue; }

            difficulty.Add(int.Parse(contents[1]));
            score.Add(float.Parse(contents[2]));
            num_matched.Add(int.Parse(contents[6]));
            num_incorrect_matched.Add(int.Parse(contents[7]));
            num_missed.Add(int.Parse(contents[8]));
            


        }

        /*
        for(int count = 0; count < difficulty.Count; count++)
        {
            Debug.Log("==================");
            //Debug.Log(count + " Score: " + score[count]);
            Debug.Log(count + " difficulty: " + difficulty[count]);
            Debug.Log(count + " match: " + num_matched[count]);
            Debug.Log(count + " incorrect match: " + num_incorrect_matched[count]);
            Debug.Log(count + " missed: " + num_missed[count]);
        }
        */

        writer.Close();
    }

    public void show_graph(int num)
    {
        shown_data[num] = !shown_data[num];
        window_graph.remove_graph();
        create_graph();
    }

    public void create_graph()
    {
        Vector2 y = new Vector2(99999, -99999);

        if(shown_data[0])
        {
            y = y_min_max(y.x, y.y, score);
        }
        if (shown_data[1])
        {
            y = y_min_max(y.x, y.y, num_matched);
        }
        if (shown_data[2])
        {
            y = y_min_max(y.x, y.y, num_incorrect_matched);
        }
        if (shown_data[3])
        {
            y = y_min_max(y.x, y.y, num_missed);
        }
        if (shown_data[4])
        {
            y = y_min_max(y.x, y.y, difficulty);
        }

        window_graph.set_y_min_max(y.x + y.x * 0.1f, y.y + y.y * 0.1f);

        if(shown_data[0])
        {
            window_graph.add_graph(score, new Color(0, 0, 0), 0f);
        }
        if (shown_data[1])
        {
            window_graph.add_graph(num_matched, new Color(0, 1, 0), 0f);
        }
        if (shown_data[2])
        {
            window_graph.add_graph(num_incorrect_matched, new Color(1, 0, 0), 0f);
        }
        if (shown_data[3])
        {
            window_graph.add_graph(num_missed, new Color(0, 0, 1), 0f);
        }
        if (shown_data[4])
        {
            window_graph.add_graph(difficulty, new Color(1, 1, 0), 0f);
        }
    }

    private Vector2 y_min_max(float yMin, float yMax, List<int> values)
    {
        for(int count = 0; count < values.Count; count++)
        {
            if(values[count] > yMax)
            {
                yMax = values[count];
            }

            if(values[count] < yMin)
            {
                yMin = values[count];
            }
        }

        return new Vector2(yMin, yMax);
    }

    private Vector2 y_min_max(float yMin, float yMax, List<float> values)
    {
        for (int count = 0; count < values.Count; count++)
        {
            if (values[count] > yMax)
            {
                yMax = values[count];
            }

            if (values[count] < yMin)
            {
                yMin = values[count];
            }
        }

        return new Vector2(yMin, yMax);
    }
}
