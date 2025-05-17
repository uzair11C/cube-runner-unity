using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float jump;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Animator anim;

    [SerializeField]
    private GameObject gameOverUI;
    private ObstacleSpawnManager spawnManager;

    [SerializeField]
    private TextMeshProUGUI gameOverHighScoreText;

    [SerializeField]
    private TextMeshProUGUI gameOverCurrentScoreText;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        gameOverHighScoreText.text =
            "High Score: " + PlayerPrefs.GetInt("CubeRunner_highScore", 0).ToString();
        spawnManager = GameObject
            .FindGameObjectWithTag("GameManager")
            .GetComponent<ObstacleSpawnManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
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
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            spawnManager.isGameOver = true;
            gameOverUI.SetActive(true);
            spawnManager.scoreText.gameObject.SetActive(false);
            Time.timeScale = 0f;
            gameOverCurrentScoreText.text = "Your Score: " + (int)spawnManager.score;
            if (PlayerPrefs.GetInt("CubeRunner_highScore", 0) < (int)spawnManager.score)
            {
                gameOverHighScoreText.text = "High Score: " + (int)spawnManager.score;
                PlayerPrefs.SetInt("CubeRunner_highScore", (int)spawnManager.score);
            }
        }
    }
}
