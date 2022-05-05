using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeProtein : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.sqrMagnitude < 0.2f)
        {
            rb.AddForce(Random.rotation * Vector3.up, ForceMode.Impulse);
        }
    }
}
