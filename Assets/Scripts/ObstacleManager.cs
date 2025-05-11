using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = Vector2.left * speed;
    }
}
