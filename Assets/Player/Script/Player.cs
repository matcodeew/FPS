using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerMovement move;

    [SerializeField] PlayerShoot shoot;

    private float fireRate = 0.5f;
    private float canfire = -1f;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shoot.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > canfire)
        {
            canfire = Time.time + fireRate;
            move.speed = 40;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            move.speed = 20;
        }
    }

}