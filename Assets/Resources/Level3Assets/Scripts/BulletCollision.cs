using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.name == "COVID19")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Score.covidCellsLeft--;
        }
    }
 }
