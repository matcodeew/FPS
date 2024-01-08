using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
   [SerializeField] PlayerMovement move;
    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            move.MovePLayerForward();
        }
        if(Input.GetKey(KeyCode.S))
        { 
            move.MovePLayerBehind();
        }
        if (Input.GetKey(KeyCode.A))
        {
            move.MovePLayerLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            move.MovePLayerRight();
        }
        if(Input.GetKey(KeyCode.Space) && move.CanJump == true)
        {
            move.JumpPlayer();
        }
    }
}
