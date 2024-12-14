using UnityEngine;

public class TerrainScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Agent")
        {
            //Reset scores
            //Destroy object - TEMPORARY
            collision.gameObject.SetActive(false);
        }
    }
}