using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
public class L1dataVisual : MonoBehaviour
{
    [SerializeField]
    private WindowGraph window_graph;

    bool data_processed = false;

    [SerializeField]
    private string file_name = "level1Data.csv";

    private List<int> collected;
    private List<float> time;
    private List<float> num_per_min;

    bool show_time = true;

    // Start is called before the first frame update
    void Awake()
    {
        collected = new List<int>();
        time = new List<float>();
        num_per_min = new List<float>();

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

            Debug.Log("L1 contents size = " + contents.Length);
            if (contents.Length != 4) { continue; }
            Debug.Log(contents[2]);
            collected.Add(int.Parse(contents[2]));
            time.Add(float.Parse(contents[1]));
            num_per_min.Add(time[time.Count - 1] / 60 * collected[collected.Count-1]);
        }

        writer.Close();
    }

    public void turn_off_time()
    {
        show_time = !show_time;
    }
    public void create_graph()
    {
        window_graph.remove_graph();
        Vector2 y = new Vector2(99999, -99999);
        y = y_min_max(y.x, y.y, collected);
        y = y_min_max(y.x, y.y, num_per_min);

        if(show_time)
        {
            y = y_min_max(y.x, y.y, time);
        }

        window_graph.set_y_min_max(y.x + y.x * 0.1f, y.y + y.y * 0.1f);
        
        window_graph.add_graph(collected, new Color(0, 0, 0), 0f);
        window_graph.add_graph(num_per_min, new Color(0, 1, 0), 0f);
        
        if (show_time)
        {
            window_graph.add_graph(time, new Color(1, 0, 0), 0f);
        }
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
