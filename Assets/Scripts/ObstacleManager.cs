using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;
    private ObstacleSpawnManager spawnManager;

    void Start()
    {
        spawnManager = GameObject
            .FindGameObjectWithTag("GameManager")
            .GetComponent<ObstacleSpawnManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (spawnManager.isGameOver)
            return;

        rb.velocity = Vector2.left * (speed + spawnManager.speedMultiplier);

        if (rb.transform.position.y <= -12f)
        {
            Destroy(rb);
        }
    }
}
