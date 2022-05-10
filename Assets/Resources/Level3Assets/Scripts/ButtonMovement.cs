using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMovement : MonoBehaviour
{
    public CellModeChange cell_mode;
    public Button left;
    public Button right;
    public Button up;
    public Button down;
    public Button forward;
    public Button mode;
    public Button shoot;

    public int moveSpeed = 50;
    public Transform cam;
    public Transform player;
    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        left.onClick.AddListener(moveLeft);
        right.onClick.AddListener(moveRight);
        up.onClick.AddListener(moveUp);
        down.onClick.AddListener(moveDown);
        forward.onClick.AddListener(moveForward);
        mode.onClick.AddListener(modeChange);
        shoot.onClick.AddListener(Shoot);

    }

    void Update()
    {
        if (CellModeChange.modeSwitch)
            shoot.gameObject.SetActive(false);
        else
            shoot.gameObject.SetActive(true);
    }

    void moveLeft()
    {
        rb.AddTorque(new Vector3(0, 0, (100.0f * moveSpeed) * Time.deltaTime));
    }

    void moveRight()
    {
        rb.AddTorque(new Vector3(0, 0, (-100.0f * moveSpeed) * Time.deltaTime));
    }

    void moveUp()
    {
        rb.AddTorque(new Vector3((-100.0f * moveSpeed) * Time.deltaTime, 0, 0));
    }

    void moveDown()
    {
        rb.AddTorque(new Vector3((100.0f * moveSpeed) * Time.deltaTime, 0, 0));
    }

    void modeChange()
    {
        cell_mode.switchMode();
    }

    void Shoot()
    {
        cell_mode.fireBullet();
    }

    void moveForward()
    {
        rb.velocity = cam.transform.forward * moveSpeed;
        if (rb.velocity.magnitude >= 100)
            rb.velocity = transform.forward * 100;
    }
}
