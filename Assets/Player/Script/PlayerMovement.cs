using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] GameObject player;
     Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public int Speed = 1;
    public int JumpForce = 1;
    public bool CanJump = true;

    public void MovePLayerForward()
    {
        player.transform.position += new Vector3(0,0, 0.01f) * Speed;
    }
    public void MovePLayerBehind()
    {
        player.transform.position += new Vector3(0, 0, -0.01f) * Speed;
    }
    public void MovePLayerLeft()
    {
        player.transform.position += new Vector3(-0.01f, 0, 0) * Speed;
    }
    public void MovePLayerRight()
    {
        player.transform.position += new Vector3(0.01f, 0, 0) * Speed;
    }
    public void JumpPlayer()
    {
        rb.velocity += new Vector3 (0,5,0) * JumpForce;
        CanJump = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Floor")
        {
            CanJump = true;
        }
    }
}
