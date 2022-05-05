using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBLoodCellMove : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.sqrMagnitude < 0.2f)
        {
            rb.AddForce(Random.rotation * Vector3.forward * Random.Range(0.0f, 1.0f));
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
