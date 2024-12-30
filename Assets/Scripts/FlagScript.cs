using UnityEngine;

public class FlagScript : MonoBehaviour
{
    public float scrollSpeed = 1.5f;

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
        if (collision.tag == "Player")
        {
            PlayerScript playerScript = collision.GetComponent<PlayerScript>();

            if (playerScript is not null)
            {
                playerScript.UpdateScore(10);
            }

            gameObject.SetActive(false);
        }
        else if (collision.tag == "Agent")
        {
            gameObject.SetActive(false);
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