using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WindowGraph : MonoBehaviour
{

    private RectTransform m_graphContainer;
    [SerializeField] //dot sprite
    private Sprite m_pointSprit;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;
    private List<GameObject> graphOBJs;
    private bool xLabelCreated = false;
    private bool yLabelCreated = false;

    private float y_max = 10;
    private float y_min = 0;

    private void Awake()
    {
        m_graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>(); //gets rect transform of graph container
        labelTemplateX = m_graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = m_graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();

        graphOBJs = new List<GameObject>();


        List<int> values = new List<int>() { 5, 98, 56, 45, 30, 22, 17, 15, 13, 17, 25, 37, 40, 36, 33 };
        //List<int> values = new List<int>() { 5533, 5652, 3553, 1542, 5361, 8881, 4747, 5564 };

        //show_graph(values, new Color(0, 0, 0));
    }

    public void set_y_min_max(float yMin, float yMax)
    {
        y_min = yMin;
        y_max = yMax;
    }

    public void add_graph(List<int> values, Color color, float yOffset)
    {
        show_graph(values, color, yOffset);
    }

    public void add_graph(List<float> values, Color color, float yOffset)
    {
        show_graph(values, color, yOffset);
    }

    public void remove_graph()
    {
        foreach (GameObject go in graphOBJs)
        {
            Destroy(go);
        }
        graphOBJs.Clear();

        xLabelCreated = false;
        yLabelCreated = false;

    }

    private void create_circle(Vector2 ancPos, Color color)
    {
        GameObject go = new GameObject("point", typeof(Image)); // create object
        go.transform.SetParent(m_graphContainer, false); //set parent, set to false, to use parent transform
        go.GetComponent<Image>().sprite = m_pointSprit; //set sprite
        go.GetComponent<Image>().color = color;

        RectTransform rectTrans = go.GetComponent<RectTransform>();
        rectTrans.anchoredPosition = ancPos; //Set position
        rectTrans.sizeDelta = new Vector2(25, 25); //Size of point
        rectTrans.anchorMin = new Vector2(0, 0); //Set to bottom left corner to 0, 0
        rectTrans.anchorMax = new Vector2(0, 0); //Set to upper left corner to 0, 0

        graphOBJs.Add(go);
    }

    private void show_graph(List<int> values, Color color, float yOffset)
    {
        int listSize = values.Count;
        float xSize = 50; //Disance on x axis between each node

        Vector2 yMINMAX = min_max_from_list(values);
        float yMax = yMINMAX.y; //Max y value
        float yMin =  yMINMAX.x; //Min y value
        //yMin = 0f;
        yMin = y_min;
        yMax = y_max;
        
        xSize = m_graphContainer.sizeDelta.x / values.Count; //change xSize (x offset per node) dynamically

        float graphHeight = m_graphContainer.sizeDelta.y; //Size of actual graph container

        create_y_labels(yMin, yMax);

        float xPos, yPos;
        Vector2 prevPos = new Vector2(-9999, -9999);
        for(int count = 0; count < listSize; count++)
        {
            xPos = 25 + count * xSize;
            yPos = ((values[count] - yMin) / (yMax - yMin)) * graphHeight + yOffset;
            create_circle(new Vector2(xPos, yPos), color);
            
            //Create connections
            if(prevPos.x != -9999)
            {
                create_dot_connection(prevPos, new Vector2(xPos, yPos), new Color(color.r, color.g, color.b, 0.5f));
            }
            prevPos.x = xPos;
            prevPos.y = yPos;

            //x label
            create_x_label(xPos, count.ToString());
        }

        xLabelCreated = true;
        yLabelCreated = true;

    }

    private void show_graph(List<float> values, Color color, float yOffset)
    {
        int listSize = values.Count;
        float xSize = 50; //Disance on x axis between each node

        Vector2 yMINMAX = min_max_from_list(values);
        float yMax = yMINMAX.y; //Max y value
        float yMin = yMINMAX.x; //Min y value
        //yMin = 0f;
        yMin = y_min;
        yMax = y_max;

        xSize = m_graphContainer.sizeDelta.x / values.Count; //change xSize (x offset per node) dynamically

        float graphHeight = m_graphContainer.sizeDelta.y; //Size of actual graph container

        create_y_labels(yMin, yMax);

        float xPos, yPos;
        Vector2 prevPos = new Vector2(-9999, -9999);
        for (int count = 0; count < listSize; count++)
        {
            xPos = 25 + count * xSize;
            yPos = ((values[count] - yMin) / (yMax - yMin)) * graphHeight + yOffset;
            create_circle(new Vector2(xPos, yPos), color);

            //Create connections
            if (prevPos.x != -9999)
            {
                create_dot_connection(prevPos, new Vector2(xPos, yPos), new Color(color.r, color.g, color.b, 0.5f));
            }
            prevPos.x = xPos;
            prevPos.y = yPos;

            //x label
            create_x_label(xPos, count.ToString());
        }

        xLabelCreated = true;
        yLabelCreated = true;

    }
    private void create_dot_connection(Vector2 aPos, Vector2 bPos, Color color)
    {
        GameObject go = new GameObject("connector", typeof(Image)); // create object
        go.transform.SetParent(m_graphContainer, false); //set parent, set to false, to use parent transform
        go.GetComponent<Image>().color = color;

        float dist = Vector2.Distance(aPos, bPos);

        RectTransform rectTrans = go.GetComponent<RectTransform>();
        rectTrans.sizeDelta = new Vector2(dist, 6); //now a bar
        rectTrans.anchorMin = new Vector2(0, 0);
        rectTrans.anchorMax = new Vector2(0, 0);

        Vector2 dir = (bPos - aPos).normalized; //get direction vector
        float angle = get_angle(dir);
        rectTrans.anchoredPosition = aPos + dir * (dist / 2); //Set position to be in center of two points
        rectTrans.localEulerAngles = new Vector3(0, 0, angle); //Set rotation

        graphOBJs.Add(go);
    }

    private float get_angle(Vector2 dir)
    {
        float ang = Mathf.Atan(dir.y / dir.x);
        ang = ang * (180 / Mathf.PI);

        return ang;
    }
    public Vector2 min_max_from_list(List<int> values)
    {
        int listSize = values.Count;

        float yMax = -99999999; //Max y value
        float yMin = 99999999;
        for (int count = 0; count < listSize; count++)
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
        yMax = yMax + yMax * 0.1f; //add buffer above tallest node
        yMin = yMin - yMin * 0.1f; //add buffer below lowest node

        return new Vector2(yMin, yMax);

    }

    public Vector2 min_max_from_list(List<float> values)
    {
        int listSize = values.Count;

        float yMax = -99999999; //Max y value
        float yMin = 99999999;
        for (int count = 0; count < listSize; count++)
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
        yMax = yMax + yMax * 0.1f; //add buffer above tallest node
        yMin = yMin - yMin * 0.1f; //add buffer below lowest node

        return new Vector2(yMin, yMax);

    }

    private void create_x_label(float xPos, string label)
    {
        if(xLabelCreated) //If already created for current graph
        {
            return;
        }

        RectTransform labelX = Instantiate(labelTemplateX);
        labelX.SetParent(m_graphContainer);
        labelX.gameObject.SetActive(true);
        labelX.anchoredPosition = new Vector2(xPos, 0);
        labelX.GetComponent<TextMeshProUGUI>().text = label;



        GameObject go = new GameObject("xLabelLine", typeof(Image)); // create object
        go.transform.SetParent(m_graphContainer, false); //set parent, set to false, to use parent transform
        go.GetComponent<Image>().color = new Color(0, 0, 0, 0.25f);

        RectTransform rectTrans = go.GetComponent<RectTransform>();
        float size = m_graphContainer.sizeDelta.y;
        rectTrans.sizeDelta = new Vector2(6, size); //now a bar
        rectTrans.anchorMin = new Vector2(0, 0);
        rectTrans.anchorMax = new Vector2(0, 0);
        rectTrans.anchoredPosition = new Vector2(xPos, size / 2); //Set position to be in center of two points

        graphOBJs.Add(go);
        graphOBJs.Add(labelX.gameObject);
    }


    private void create_y_labels(float minY, float maxY)
    {
        if(yLabelCreated) //If already created for current graph
        {
            return;
        }

        float value, labelPos, sizeCon = m_graphContainer.sizeDelta.x;
        int size = 10;
        for(int count = 0; count < size; count++)
        {
            value = minY + maxY * (count * 1f / size); 

            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(m_graphContainer);
            labelY.gameObject.SetActive(true);
            labelPos = (count * 1f) / size;
            labelPos = ((value - minY) / (maxY - minY));// * graphHeight;
            labelY.anchoredPosition = new Vector2(-5, labelPos * m_graphContainer.sizeDelta.y);
            labelY.GetComponent<TextMeshProUGUI>().text = (Mathf.Round(value * 10f) / 10f).ToString();


            GameObject go = new GameObject("yLabelLine", typeof(Image)); // create object
            go.transform.SetParent(m_graphContainer, false); //set parent, set to false, to use parent transform
            go.GetComponent<Image>().color = new Color(0, 0, 0, 0.25f);

            RectTransform rectTrans = go.GetComponent<RectTransform>();
            rectTrans.sizeDelta = new Vector2(sizeCon, 6); //now a bar
            rectTrans.anchorMin = new Vector2(0, 0);
            rectTrans.anchorMax = new Vector2(0, 0);
            rectTrans.anchoredPosition = new Vector2(sizeCon / 2, labelPos * m_graphContainer.sizeDelta.y); //Set position to be in center of two points


            graphOBJs.Add(go);
            graphOBJs.Add(labelY.gameObject);
        }
    }
}
