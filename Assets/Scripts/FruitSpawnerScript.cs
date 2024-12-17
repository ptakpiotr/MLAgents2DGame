using UnityEngine;

//TODO: connect with ObstacleSpawner!!!
public class FruitSpawnerScript : MonoBehaviour
{
    public GameObject kiwi;
    public GameObject strawberry;

    private float currentSpawnTimer = 0f;
    private float thresholdSpawnTimer = 10f;
    private float strawberryTimerMultiplier = 10f;

    private void Awake()
    {
        strawberryTimerMultiplier = Random.Range(10, 13);
    }

    private void Update()
    {
        currentSpawnTimer += Random.Range(0f, 1f) * Time.deltaTime;
        Vector3 position = transform.position;

        if (currentSpawnTimer >= strawberryTimerMultiplier * thresholdSpawnTimer)
        {
            position.y = Random.Range(-4f, 4f);

            GameObject strawberryObj = Instantiate(strawberry, position, Quaternion.identity);
            strawberryObj.transform.parent = transform;
            currentSpawnTimer = 0f;
        }
        if (currentSpawnTimer >= thresholdSpawnTimer)
        {
            position.y = Random.Range(-4f, 4f);

            GameObject kiwiObj = Instantiate(kiwi, position, Quaternion.identity);
            kiwiObj.transform.parent = transform;
            currentSpawnTimer = 0f;
        }
    }
}