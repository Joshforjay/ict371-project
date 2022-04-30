using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellModeChange : MonoBehaviour
{
    //Mode 1 (Plasma cell)
    public Material mat1;
    public GameObject projectile;
    public Camera cam;
    public Transform attackPoint;

    public float shotForce = 5;

    //Mode 2 (Memory cell)
    public Material mat2;


    //mode check
    public static bool modeSwitch = true;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            modeSwitch = !modeSwitch;
            if (modeSwitch)
                this.GetComponentInChildren<MeshRenderer>().material = mat1;
            else
                this.GetComponentInChildren<MeshRenderer>().material = mat2;
        }

        if (!modeSwitch)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                GameObject currentBullet = Instantiate(projectile, transform.position, Quaternion.identity);
                currentBullet.GetComponent<Rigidbody>().AddForce(attackPoint.forward.normalized * shotForce, ForceMode.Impulse);
            }
        }

    }
}
