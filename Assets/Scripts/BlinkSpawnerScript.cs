using UnityEngine;

//TODO: connect with ObstacleSpawner!!!
public class BlinkSpawnerScript : MonoBehaviour
{
    public GameObject blink;

    private float currentSpawnTimer = 0f;
    private float thresholdSpawnTimer = 8f;

    private void Update()
    {
        currentSpawnTimer += Random.Range(0f, 1f) * Time.deltaTime;
        Vector3 position = transform.position;

        if (currentSpawnTimer >= thresholdSpawnTimer)
        {
            position.y = Random.Range(-4f, 4f);

            GameObject blinkObj = Instantiate(blink, position, Quaternion.identity);
            blinkObj.transform.parent = transform;
            currentSpawnTimer = 0f;
        }
    }
}