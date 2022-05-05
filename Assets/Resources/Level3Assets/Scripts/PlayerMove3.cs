using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3 : MonoBehaviour
{
    public int moveSpeed = 5;
    public Transform cam;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
            rb.transform.position += transform.forward * moveSpeed * Time.deltaTime;

        rb.MoveRotation(cam.rotation);
    }
}

