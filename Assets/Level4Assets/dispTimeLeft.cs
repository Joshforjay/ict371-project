using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dispTimeLeft : MonoBehaviour
{
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Level4Controller lc = FindObjectOfType<Level4Controller>();
        int timeLeft = (int)(lc.getlevelTimeLimit() - (Time.time - startTime));
        if(timeLeft < 0) { timeLeft = 0; }
        GetComponent<TextMesh>().text = timeLeft.ToString();
    }
}
