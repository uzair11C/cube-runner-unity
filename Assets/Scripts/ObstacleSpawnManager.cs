using TMPro;
using UnityEngine;

public class ObstacleSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnObject;

    [SerializeField]
    private GameObject[] spawnPoints;

    [SerializeField]
    private float timer;

    [SerializeField]
    private float timeBetweenSpawns;

    public float speedMultiplier;
    public bool isGameOver = false;

    public float score;
    public TextMeshProUGUI scoreText;

    void Update()
    {
        if (isGameOver)
            return;

        scoreText.text = "Score: " + ((int)score).ToString();
        Debug.Log("Score: " + ((int)score).ToString());

        timer += Time.deltaTime;
        speedMultiplier += Time.deltaTime * 0.1f;
        score += Time.deltaTime * (0.5f + (speedMultiplier * 0.05f));

        if (timer > timeBetweenSpawns)
        {
            timer = 0;
            int randomIndex = Random.Range(0, 3);
            GameObject newObstacle = Instantiate(
                spawnObject,
                spawnPoints[randomIndex].transform.position,
                Quaternion.identity
            );

            Renderer rend = newObstacle.GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material.color = Color.HSVToRGB(
                    Random.value,
                    Random.Range(0.4f, 0.7f),
                    Random.Range(0.8f, 1f)
                );
            }
        }
    }
}
