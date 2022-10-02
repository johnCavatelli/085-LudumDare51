using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    public Vector3 offset = new Vector3(0,0.8f,0);
    public float turnSpeed = 4.0f;
    public float moveSpeed = 2.0f;  
    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 90.0f;
    private float rotX;
    private bool frozen = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MouseAiming();
        transform.position = playerBody.position + offset;
    }

    void MouseAiming()
    {
        if (!frozen)
        {
            // get the mouse inputs
            float y = Input.GetAxis("Mouse X") * turnSpeed;
            rotX += Input.GetAxis("Mouse Y") * turnSpeed;

            // clamp the vertical rotation
            rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

            // rotate the camera
            transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
            playerBody.eulerAngles = new Vector3(0, transform.eulerAngles.y + y, 0);
        }
    }

    public void Freeze()
    {
        frozen = true;
    }

    public void UnFreeze()
    {
        frozen = false;
    }
}
