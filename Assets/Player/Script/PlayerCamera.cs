using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;

    float rotationX = 0f;
    float rotationY = 0f;
    float MouseSensibility = 2f;

    private void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }
    private void Update()
    {
        rotationX += -Input.GetAxis("Mouse Y") * MouseSensibility;
        rotationX = Mathf.Clamp(rotationX, -90f, 90);

        rotationY = Input.GetAxis("Mouse X") * MouseSensibility;

        player.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, rotationY, 0);
    }
}
