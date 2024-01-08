using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCamera : MonoBehaviour
{

    public Transform player;

    float MouseSensibility = 2f;
    float CameraVerticalRotation = 0f;
    private void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * MouseSensibility;

        float inputY = Input.GetAxis("Mouse Y") * MouseSensibility;


        CameraVerticalRotation -= inputY;
        CameraVerticalRotation = Mathf.Clamp(CameraVerticalRotation, -30f, 20f);
        transform.localEulerAngles =Vector3.right * CameraVerticalRotation;
    }
}
