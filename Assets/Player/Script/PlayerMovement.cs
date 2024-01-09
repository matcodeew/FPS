using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] GameObject player;
    public Transform orientation;
     Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public float Speed = 0.05f;
    public int JumpForce = 1;
    public bool CanJump = true;

    Vector3 moveDirection;
    float verticalInput;
    float horizontalInput;

    private void Update()
    {
        MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
    }

    public void MovePLayerForward()
    {
        player.transform.position += new Vector3 (moveDirection.x * Speed, 0,moveDirection.z * Speed) ;
    }
    public void MovePLayerBehind()
    {
        player.transform.position += new Vector3(moveDirection.x * Speed, 0, moveDirection.z * Speed);
    }
    public void MovePLayerLeft()
    {
        player.transform.position += new Vector3(moveDirection.x * Speed, 0, moveDirection.z * Speed);
    }
    public void MovePLayerRight()
    {
        player.transform.position += new Vector3(moveDirection.x * Speed, 0, moveDirection.z * Speed);
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
