using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinMovement : MonoBehaviour
{

    [SerializeField]
    private GameObject go;
    private Vector3 basePos;
    private Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        basePos = go.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1;
        newPos = basePos;
        newPos.y += Mathf.Sin(Time.time) / 5;

        go.transform.position = newPos;
    }
}
