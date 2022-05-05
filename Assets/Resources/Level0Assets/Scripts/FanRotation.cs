using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotation : MonoBehaviour
{
    public Transform fan1;
    public Transform fan2;
    public Transform fan3;
    public Transform fan4;
    public float fan1Speed = 0;
    public float fan2Speed = 0;
    public float fan3Speed = 0;
    public float fan4Speed = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fan1.Rotate(new Vector3(0, 0, 1f * fan1Speed));
        fan2.Rotate(new Vector3(0, 0, 1f * fan2Speed));
        fan3.Rotate(new Vector3(0, 0, 1f * fan3Speed));
        fan4.Rotate(new Vector3(0, 0, 1f * fan4Speed));

    }
}
