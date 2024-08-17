using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20;

    public Transform orientation;
    [SerializeField] private Player manager;
    Rigidbody rb;

    [SerializeField] public TextMeshProUGUI lifeMesh;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        lifeMesh.text = manager.currentPlayerLife.ToString() + " / 100";
    }

    private void Update()
    {
        MyInput();
        UpdateLifeMesh();
    }

    private void MyInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = orientation.forward * verticalInput + orientation.right * horizontalInput;
        direction.Normalize();

        Vector3 movement = direction * speed * Time.deltaTime;
        movement.y = 0;

        // Applying movement using Rigidbody for better physics handling
        rb.MovePosition(rb.position + movement);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            manager.PlayerLife();
        }
        else if (collision.gameObject.CompareTag("HealBonus"))
        {
            Destroy(collision.gameObject);
            manager.currentPlayerLife += HealPlayer();
        }

        UpdateLifeMesh();
    }

    private int HealPlayer()
    {
        if (manager.currentPlayerLife < 100)
        {
            if (manager.currentPlayerLife + manager.orbHeal > 100)
            {
                return 100 - manager.currentPlayerLife;
            }
            else
            {
                return manager.orbHeal;
            }
        }
        else
        {
            return 0;
        }
    }

    private void UpdateLifeMesh()
    {
        lifeMesh.text = manager.currentPlayerLife.ToString() + " / 100";
    }
}
