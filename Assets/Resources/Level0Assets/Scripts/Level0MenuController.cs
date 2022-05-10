using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;

public class Level0MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject waypoint_;
    [SerializeField]
    private GameObject player_;

    private bool startUI_ = false;
    private bool start_screen_ = true;
    private bool start_info_ = true;

    [SerializeField]
    private GameObject backing_;

    [SerializeField]
    private GameObject start_screen_obj_;
    [SerializeField]
    private GameObject start_screen_obj_button_;

    [SerializeField]
    private GameObject start_info_obj_;
    [SerializeField]
    private GameObject start_info_first_button_;


    [SerializeField]
    private GameObject[] data_screens;
    [SerializeField]
    private GameObject[] first_data_screen_button_;

    private int data_screen_active = 0;

    [SerializeField]
    private GameObject graph;
    
    // Start is called before the first frame update
    void Start()
    {
        start_screen_obj_.SetActive(false);
        start_info_obj_.SetActive(false);
        for (int count = 0; count < data_screens.Length; count++)
        {
            data_screens[count].SetActive(false);
        }
        backing_.SetActive(false);
        graph.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (in_waypoint_area() && startUI_ == false)
        {
            startUI_ = true;
            Cursor.visible = true;
        }

        if (startUI_)
        {
            backing_.SetActive(true);

            if (start_screen_)
            {
                if (start_info_)
                {
                    start_info_update();
                }
                else
                {
                    start_screen_update();
                }
            }
            else
            {
                data_screen_update();
            }
        }


    }

    public void exit_program()
    {
        Application.Quit();
    }

    private void start_info_update()
    {
        if (!start_info_obj_.activeSelf)
        {
            start_info_obj_.SetActive(true);
            set_first_button_active(start_info_first_button_);
        }
    }
    private void start_screen_update()
    {
        if (!start_screen_obj_.activeSelf)
        {
            start_screen_obj_.SetActive(true);
            set_first_button_active(start_screen_obj_button_);
        }

        if(graph.activeSelf)
        {
            graph.SetActive(false);
        }
    }
    private void data_screen_update()
    {
        if(!graph.activeSelf)
        {
            graph.SetActive(true);
        }
    }

    public void next_data_screen()
    {
        for (int count = 0; count < data_screens.Length; count++)
        {
            data_screens[count].SetActive(false);
        }
        data_screen_active++;
        data_screen_active = Mathf.Clamp(data_screen_active, 0, data_screens.Length - 1);
        data_screens[data_screen_active].SetActive(true);
        set_first_button_active(first_data_screen_button_[data_screen_active]);
    }

    public void previous_data_screen()
    {
        for (int count = 0; count < data_screens.Length; count++)
        {
            data_screens[count].SetActive(false);
        }
        data_screen_active--;
        data_screen_active = Mathf.Clamp(data_screen_active, 0, data_screens.Length - 1);
        data_screens[data_screen_active].SetActive(true);
        set_first_button_active(first_data_screen_button_[data_screen_active]);

    }

    public void close_start_info()
    {
        start_info_ = false;
        start_info_obj_.SetActive(false);
    }


    public void show_data_collection()
    {
        start_screen_ = false;
        data_screens[0].SetActive(true);
        start_screen_obj_.SetActive(false);
        set_first_button_active(first_data_screen_button_[0]);
    }
    public void close_data_collection()
    {
        start_screen_ = true;
        for(int count = 0; count < data_screens.Length; count++)
        {
            data_screens[count].SetActive(false);
        }
        start_screen_obj_.SetActive(true);
        set_first_button_active(start_screen_obj_button_);
        data_screen_active = 0;
    }

    private bool in_waypoint_area()
    {
        Vector3 wpp = waypoint_.transform.position;
        Vector3 pp = player_.transform.position;

        Vector2 wp = new Vector2(wpp.x, wpp.z);
        Vector2 p = new Vector2(pp.x, pp.z);

        float distance = Vector2.Distance(wp, p);
        if(distance < 0.5)
        {
            return true;
        }

        return false;
    }

    private void set_first_button_active(GameObject go)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(go);
    }




    void read_level4_data()
    {
        string file = Application.persistentDataPath + "/level4Data.csv";
        StreamReader st = new StreamReader(file);

        Debug.Log(st.ReadLine());
        
    }



















}
