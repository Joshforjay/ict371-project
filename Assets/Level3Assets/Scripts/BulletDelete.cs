using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDelete : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform obj;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, obj.position) >= 200)
        {
            Debug.Log("Deleted bullet");
            Destroy(this.gameObject);
        }
    }
}
