using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class L3dataVisual : MonoBehaviour
{
    [SerializeField]
    private WindowGraph window_graph;

    bool data_processed = false;

    [SerializeField]
    private string file_name = "level3Data.csv";

    private List<float> time;
    private List<int> neutralised;
    private List<int> difficulty;
    bool show_time = true;


    // Start is called before the first frame update
    void Awake()
    {
        time = new List<float>();
        neutralised = new List<int>();
        difficulty = new List<int>();

        read_data();

        create_graph();


        data_processed = true;
    }

    private void Update()
    {
        window_graph.remove_graph();
        create_graph();
    }

    private void OnDisable()
    {
        window_graph.remove_graph();
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

            if (contents.Length != 5) { continue; }

            Debug.Log("L3 data size = " + contents.Length); 
            difficulty.Add(int.Parse(contents[1]));
            time.Add(float.Parse(contents[2]));
            neutralised.Add(int.Parse(contents[4]));

        }

        writer.Close();
    }

    public void show_time_graph(int num)
    {
        show_time = !show_time;
    }

    public void create_graph()
    {
        window_graph.remove_graph();
        Vector2 y = new Vector2(99999, -99999);

        if (show_time)
        {
            y = y_min_max(y.x, y.y, time);
        }
        y = y_min_max(y.x, y.y, neutralised);
        y = y_min_max(y.x, y.y, difficulty);

        window_graph.set_y_min_max(y.x + y.x * 0.1f, y.y + y.y * 0.1f);

        if (show_time)
        {
            window_graph.add_graph(time, new Color(0, 0, 0), 0f);
        }

        window_graph.add_graph(neutralised, new Color(1, 0, 0), 0f);
        window_graph.add_graph(difficulty, new Color(1, 1, 0), 0f);
    }

    private Vector2 y_min_max(float yMin, float yMax, List<int> values)
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

