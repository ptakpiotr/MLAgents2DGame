using UnityEngine;

public class TerrainScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerScript playerScript = collision.GetComponent<PlayerScript>();

            playerScript.SetScore(0);
            //Reset scores
            //Destroy object - TEMPORARY
            collision.gameObject.SetActive(false);
        }
    }
}