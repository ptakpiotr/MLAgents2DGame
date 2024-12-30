using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private int score = 0;

    public BoxCollider2D ghostCollider;
    public float upForce = 2f;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //Ignore collision between us (player) and ghost player
        Collider2D thisCollider = GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(thisCollider, ghostCollider);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigidbody2d.linearVelocity = Vector2.zero;
            rigidbody2d.AddForce(new Vector2(0, upForce), ForceMode2D.Impulse);
            animator.Play("up");
            Invoke("ChangeSprite", 1f);
            Debug.Log($"Score: {score}");
        }
    }

    private void ChangeSprite()
    {
        animator.Play("down");
    }

    public void UpdateScore(int increaseScore)
    {
        score += increaseScore;
    }

    public void SetScore(int newScore)
    {
        score = newScore;
    }
}