using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableCrosshair : MonoBehaviour
{
    public PauseController pause;
    public StartController start;
    public GameObject child;

    // Update is called once per frame
    void Update()
    {
        if (!start.is_active() || pause.isPaused)
        {
            child.SetActive(false);
        }
        else
            child.SetActive(true);
    }
}
