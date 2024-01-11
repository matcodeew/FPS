using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20;

    public Transform orientation;
    [SerializeField] private Player manager;
    Rigidbody rb;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    public void Update()
    {
        MyInput();
    }

    private void MyInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = orientation.forward * verticalInput + orientation.right * horizontalInput;
        direction.Normalize();

        Vector3 movement = direction * speed * Time.deltaTime;
        movement.y = 0;

        transform.Translate(movement);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            manager.PlayerLife();
        }
    }
}