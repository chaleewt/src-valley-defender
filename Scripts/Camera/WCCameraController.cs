using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCCameraController : MonoBehaviour
{
    public Transform cameraTransform; // Main camera

    //Camera Position
    [SerializeField] Vector3 newPosition;
    [SerializeField] Quaternion newXRotation;
    [SerializeField] Quaternion newYRotation;
    [SerializeField] Vector3 newZoom;

    //Clamp Values
    [SerializeField] float minXPanLimit = 20f; //.. Forward Vector
    [SerializeField] float maxXPanLimit = 54f;
    [SerializeField] float minZPanLimit = 47f; //.. Right Vector
    [SerializeField] float maxZPanLimit = 130f;

    [SerializeField] Vector3 zoomLimit;

    //Speed
    [SerializeField] float panBorderThinkness = 20f;
    [SerializeField] float panSpeed = 20f;
    [SerializeField] float movementTime = 10f;

    //Rotate
    [SerializeField] Vector3 rotateStartXPosition;
    [SerializeField] Vector3 rotateCurrentXPosition;
    [SerializeField] Vector3 rotateStartYPosition;
    [SerializeField] Vector3 rotateCurrentYPosition;

    //Zoom
    [SerializeField] Vector3 zoomAmount;
    

    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        newXRotation = transform.rotation;
        newYRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
        //Rotate();
        Zoom();
    }

    void MoveCamera()
    {


        if (Input.mousePosition.y >= Screen.height - panBorderThinkness)
        {
            newPosition += (transform.forward * panSpeed * Time.deltaTime);
        }

        if (Input.mousePosition.y <= panBorderThinkness)
        {
            newPosition += (transform.forward * -panSpeed * Time.deltaTime);
        }

        if (Input.mousePosition.x >= Screen.width - panBorderThinkness)
        {
            newPosition += (transform.right * panSpeed * Time.deltaTime);
        }
        if (Input.mousePosition.x <= panBorderThinkness)
        {
            newPosition += (transform.right * -panSpeed * Time.deltaTime);
        }

        transform.position = newPosition;

        //Clamp Position
        newPosition.x = Mathf.Clamp(newPosition.x, minXPanLimit, maxXPanLimit);
        newPosition.z = Mathf.Clamp(newPosition.z, minZPanLimit, maxZPanLimit);
    }

    void Rotate()
    {

        // Rotate Camera with right click

        if (Input.GetMouseButtonDown(1))
        {
            rotateStartYPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            rotateCurrentYPosition = Input.mousePosition;

            Vector3 difference = rotateStartYPosition - rotateCurrentYPosition;

            //Revalue
            rotateStartYPosition = rotateCurrentYPosition;

            newYRotation *= Quaternion.Euler(Vector3.up * -difference.x / 5f);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, newYRotation, movementTime * Time.deltaTime);

    }

    void Zoom()
    {
        newZoom.y = Mathf.Clamp(newZoom.y, -zoomLimit.y, zoomLimit.y);
        newZoom.z = Mathf.Clamp(newZoom.z, -zoomLimit.z, zoomLimit.z);

        //Zoom in
        if (Input.mouseScrollDelta.y > 0)
        {
            newZoom += zoomAmount * Time.deltaTime;
        }


        //Zoom out
        if (Input.mouseScrollDelta.y < 0)
        {
            newZoom -= zoomAmount * Time.deltaTime;
        }

        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, movementTime * Time.deltaTime);
    }

   
}