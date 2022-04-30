using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dispScore : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Level4Controller lc = FindObjectOfType<Level4Controller>();
        GetComponent<TextMesh>().text = lc.getScore().ToString();
    }
}
