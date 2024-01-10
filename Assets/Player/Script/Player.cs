using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerMovement move;

    [SerializeField] PlayerShoot shoot;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shoot.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            move.speed = 40;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            move.speed = 20;
        }
    }

}