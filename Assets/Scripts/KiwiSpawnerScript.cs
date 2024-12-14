using UnityEngine;

//TODO: connect with ObstacleSpawner!!!
public class KiwiSpawnerScript : MonoBehaviour
{
    public GameObject kiwi;

    private float currentSpawnTimer = 0f;
    private float thresholdSpawnTimer = 10f;

    private void Update()
    {
        currentSpawnTimer += Random.Range(0f, 1f) * Time.deltaTime;
        Vector3 position = transform.position;

        if (currentSpawnTimer >= thresholdSpawnTimer)
        {
            position.y = Random.Range(-4f, 4f);

            GameObject kiwiObj = Instantiate(kiwi, position, Quaternion.identity);
            kiwiObj.transform.parent = transform;
            currentSpawnTimer = 0f;
        }
    }
}