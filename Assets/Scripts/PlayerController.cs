using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float jump;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jump);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetTrigger("Slide");
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetTrigger("Idle");
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
