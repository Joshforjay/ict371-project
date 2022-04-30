using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragMove : MonoBehaviour
{
    [SerializeField]
    GamepadCursor gamepadCursor;
    [SerializeField]
    InputAction mouseClick;
    [SerializeField]
    float mouseDragSpeed;
    WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

    Camera mainCamera;
    bool controllerUsed = false;

    private void Update()
    {
        //Debug.Log("update");
        Mouse virtualMouse = gamepadCursor.getMouse();
        if (Gamepad.current.aButton.IsPressed())
        {
            controllerUsed = true;
            //Debug.Log("aButton");
            Ray ray = mainCamera.ScreenPointToRay(virtualMouse.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    //Debug.Log("starting drag update");
                    StartCoroutine(DragUpdate(hit.collider.gameObject));
                }
            }
        }
        else { controllerUsed = false; }
    }

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        mouseClick.Enable();
        mouseClick.performed += MousePressed;
    }

    private void OnDisable()
    {
        mouseClick.performed -= MousePressed;
        mouseClick.Disable();
    }

    void MousePressed(InputAction.CallbackContext context)
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                StartCoroutine(DragUpdate(hit.collider.gameObject));
            }
        }
    }

    IEnumerator DragUpdate(GameObject clickedObject)
    {
        float initDist = Vector3.Distance(clickedObject.transform.position, mainCamera.transform.position);
        clickedObject.TryGetComponent<Rigidbody>(out var rb);
        while (mouseClick.ReadValue<float>() != 0)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (controllerUsed)
            {
                ray = mainCamera.ScreenPointToRay(gamepadCursor.getMouse().position.ReadValue());
            }
            if (rb != null)
            {
                Vector3 mouseDir = ray.GetPoint(initDist) - clickedObject.transform.position;
                mouseDir.y = 0;
                clickedObject.transform.position += mouseDir;
                yield return waitForFixedUpdate;
                
            }
            else
            {

                yield return null;
            }
        }
    }
}
