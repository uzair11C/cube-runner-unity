using UnityEngine;

public class ObstacleSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private float timer;
    [SerializeField] private float timeBetweenSpawns;

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeBetweenSpawns)
        {
            timer = 0;
            int randomIndex = Random.Range(0, 3);
            // Instantiate(
            //     spawnObject,
            //     spawnPoints[randomIndex].transform.position,
            //     Quaternion.identity
            // );
            // Instantiate a new obstacle
            GameObject newObstacle = Instantiate(
                spawnObject,
                spawnPoints[randomIndex].transform.position,
                Quaternion.identity
            );

            // Change the material color of the *new* obstacle
            Renderer rend = newObstacle.GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material.color = Color.HSVToRGB(Random.value, Random.Range(0.4f, 0.7f), Random.Range(0.8f, 1f));
            }
            Debug.Log("Spawned at: " + newObstacle.transform.position);

        }
    }
}
