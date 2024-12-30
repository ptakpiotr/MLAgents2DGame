using UnityEngine;

public class FruitScript : MonoBehaviour
{
    public float scrollSpeed = 1.2f;

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
        if (collision.tag == "Player")
        {
            PlayerScript playerScript = collision.GetComponent<PlayerScript>();

            if (playerScript is not null)
            {
                int increaseScore = this.tag switch
                {
                    "Kiwi" => 50,
                    "Strawberry" => 500,
                    _ => -1
                };
                playerScript.UpdateScore(increaseScore);
            }

            gameObject.SetActive(false);
        }
        else if(collision.tag == "Agent")
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