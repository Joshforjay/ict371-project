using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public float yPos = 1;

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(Camera.main.transform);
        gameObject.transform.eulerAngles = new Vector3(90f, 0f, 0f);
        Vector3 pos = gameObject.transform.parent.gameObject.transform.position;
        pos.y = 1f;
        gameObject.transform.position = pos;
    }
}
