﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{

    public float mouseSencetivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;

    public Camera zoom;

    public float zoomValue = 60f;

    float standartZoom;

    // Start is called before the first frame update
    void Start()
    {
        standartZoom = zoom.fieldOfView;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSencetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSencetivity * Time.deltaTime;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);

        if (Input.GetMouseButton(1))
        {
            zoom.fieldOfView = zoomValue;
        }
        else
        {
            zoom.fieldOfView = standartZoom;
        }
    }
}
