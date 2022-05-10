using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3 : MonoBehaviour
{
    public int moveSpeed = 70;
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
        {
            if (rb.velocity.magnitude < 100)
                rb.velocity = transform.forward * moveSpeed;
        }
        else if (Input.GetButtonUp("Fire1"))
           rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);

        rb.MoveRotation(cam.rotation);
    }

}

