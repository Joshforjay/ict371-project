using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class ObjectMovement : MonoBehaviour
{

    //OLD INPUT SYSTEM
    /*
    private Vector3 offSet;
    private float zPos;

    void OnMouseDown()
    {
        Debug.Log("Clicked");
        zPos = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        
        offSet = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zPos;
       
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    
    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + offSet;
    }
    */
    
    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.name == "Floor") { return; }

        Level4Controller.collisionResolution(collider.gameObject, this.gameObject);
    }
    
    /*
    //NEW INPUT SYSTEM
    
    [SerializeField]
    InputAction mouseClick;
    [SerializeField]
    float mouseDragSpeed = 1;
    WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

    Camera mainCamera;

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
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider != null)
            {
                StartCoroutine(DragUpdate(hit.collider.gameObject));
            }
        }
    }

    IEnumerator DragUpdate(GameObject clickedObject)
    {
        if(clickedObject == null) { yield return null; }
        float initDist = Vector3.Distance(clickedObject.transform.position, mainCamera.transform.position); 
        clickedObject.TryGetComponent<Rigidbody>(out var rb);
        while(mouseClick.ReadValue<float>() != 0)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if(rb != null)
            {
                Vector3 mouseDir = ray.GetPoint(initDist) - clickedObject.transform.position;
                mouseDir.y = 0;
                //rb.position = clickedObject.transform.position += mouseDir;
                clickedObject.transform.position += mouseDir;
                //rb.velocity = mouseDir * mouseDragSpeed;

                yield return waitForFixedUpdate;
            }
            else
            {

                yield return null;
            }
        }
    }
    */
}
