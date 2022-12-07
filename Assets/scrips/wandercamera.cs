using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wandercamera : MonoBehaviour
{
    public float movespeed = 30.0f;
    public float rotateSpeed = 0.2f;

    public static Vector3 kUpDirection = new Vector3(0.0f, 1.0f, 0.0f);

    private float m_fLastMousePosX = 0.0f;
    private float m_fLastMousePosY = 0.0f;
    private bool m_bMouseRightKeyDown = false;

    [Header("Camera")]
    public float lookSensitivity;  //mouse look sensitivity
    public float maxLookX;         //highest x rotation of the camera
    public float minLookX;         //lowest down we can look
    private float rotx;           //current x ratation of the camera
    private float y;

    private Camera cam;
    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start()
    {
        
    }
    private void Update()
    {
         y += Input.GetAxis("Mouse X") * lookSensitivity;
        rotx += Input.GetAxis("Mouse Y") * lookSensitivity;
        

        //It rotates around the X-axis
        cam.transform.localRotation = Quaternion.Euler(-rotx, y, 0);
        //adding the rotation along the y axis
       // transform.eulerAngles += Vector3.up * y;

        float fMoveDeltaX = 0.0f;
        float fMoveDeltaZ = 0.0f;
        float fDeltaTime = Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            fMoveDeltaX -= movespeed * fDeltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            fMoveDeltaX += movespeed * fDeltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            fMoveDeltaZ += movespeed * fDeltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            fMoveDeltaZ -= movespeed * fDeltaTime;
        }
        if(fMoveDeltaX != 0.0f || fMoveDeltaZ != 0.0f)
        {
            Vector3 kForward = transform.forward;
            Vector3 kRight = Vector3.Cross(kUpDirection, kForward);
            Vector3 kNewPos = transform.position;
            kNewPos += kRight * fMoveDeltaX;
            kNewPos += kForward * fMoveDeltaZ;
            transform.position = kNewPos;
        }
    }
}
