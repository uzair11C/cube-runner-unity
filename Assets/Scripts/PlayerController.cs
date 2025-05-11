using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float jump;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            rb.AddForce(Vector2.up * jump);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else
        {
            Debug.Log("Collided with: " + other.gameObject.name);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
