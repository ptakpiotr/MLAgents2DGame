using UnityEngine;

public class ObstacleSpawnerScript : MonoBehaviour
{
    public GameObject[] standardObstacles;

    public GameObject bigObstacle;
    public GameObject scoreFlag;

    private float currentSpawnTimer = 4.5f;
    private float thresholdSpawnTimer = 5f;

    private void Update()
    {
        currentSpawnTimer += Random.Range(0f, 1f) * Time.deltaTime;

        if (currentSpawnTimer >= thresholdSpawnTimer)
        {
            GameObject firstObstacle = default;
            GameObject secondObstacle = default;

            Vector3 position = transform.position;
            Vector3 secondPosition = transform.position;

            if (Random.Range(0, 10) % 4 == 0)
            {
                position.y = 0.75f;

                GameObject prefab = bigObstacle;

                firstObstacle = Instantiate(prefab, position, Quaternion.identity);
                firstObstacle.transform.parent = transform;
            }
            else
            {
                int idx = Random.Range(0, standardObstacles.Length);
                int secondIdx = Random.Range(0, standardObstacles.Length);
                GameObject firstPrefab = standardObstacles[idx];
                GameObject secondPrefab = standardObstacles[secondIdx];

                SetPosition(idx, ref position);
                SetPosition(secondIdx, ref secondPosition, true);

                firstObstacle = Instantiate(firstPrefab, position, Quaternion.identity);
                secondObstacle = Instantiate(secondPrefab, secondPosition, Quaternion.identity);

                firstObstacle.transform.parent = transform;
                secondObstacle.transform.parent = transform;
            }

            Vector3 flagPosition = transform.position;
            flagPosition.x = position.x + 2.5f;
            flagPosition.y = -4f;
            GameObject flag = Instantiate(scoreFlag, flagPosition, Quaternion.identity);
            flag.transform.parent = transform;
            currentSpawnTimer = 0f;
        }
    }

    private void SetPosition(int idx, ref Vector3 position, bool isUpper = false)
    {
        switch (idx)
        {
            case 0:
                position.y = isUpper ? 4.65f : -2.2f;
                break;

            case 1:
                position.y = isUpper ? 4.8f : -1.6f;
                break;

            case 2:
                position.y = isUpper ? 4.98f : -1.0f;
                break;
        }
    }
}