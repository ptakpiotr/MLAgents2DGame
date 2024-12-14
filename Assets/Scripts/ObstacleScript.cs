using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public float scrollSpeed = 1f;

    private void Start()
    {
    }

    private void Update()
    {
        CheckBounds();
        Scroll();
    }

    private void Scroll()
    {
        Vector2 offset = transform.position;
        offset.x -= Time.deltaTime * scrollSpeed;

        transform.position = offset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Agent")
        {
            collision.gameObject.SetActive(false);
        }
    }

    private void CheckBounds()
    {
        if (transform.position.x <= -15f)
        {
            gameObject.SetActive(false);
        }
    }
}