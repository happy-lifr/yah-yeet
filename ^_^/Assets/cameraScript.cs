﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public GameObject target;
    float desiredDistance = 0f;
    float pitch = 0f;
    float pitchMin = -40f;
    float pitchMax = 60f;
    float yaw = 0f;
    float roll = 0f;
    float sensitivity = 15f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    void Update()
    {
        transform.position = target.transform.position - desiredDistance * transform.forward;
        pitch -= sensitivity * Input.GetAxis("Mouse Y");
        yaw += sensitivity * Input.GetAxis("Mouse X");
        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);
        transform.localEulerAngles = new Vector3(pitch, yaw, roll);
    }
}
