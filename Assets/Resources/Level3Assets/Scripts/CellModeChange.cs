using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellModeChange : MonoBehaviour
{
    //Mode 1 (Plasma cell)
    public GameObject model1;
    public GameObject model2;
    public GameObject projectile;
    public Camera cam;
    public Transform attackPoint;

    public float shotForce = 5;


    //mode check
    public static bool modeSwitch = true;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            switchMode();
        }

        if (!modeSwitch)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                fireBullet();
            }
        }

    }

    public void switchMode()
    {
        modeSwitch = !modeSwitch;
        model1.SetActive(modeSwitch);
        model2.SetActive(!modeSwitch);
    }

    public void fireBullet()
    {
        GameObject currentBullet = Instantiate(projectile, transform.position, Quaternion.identity);
        currentBullet.GetComponent<Rigidbody>().AddForce(cam.transform.forward.normalized * shotForce, ForceMode.Impulse);
    }
}
