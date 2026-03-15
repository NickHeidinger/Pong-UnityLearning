using UnityEngine;

public class Goal : MonoBehaviour
{
    public enum Side { Left, Right }
    public Side side;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Ball")) return;

        if (side == Side.Left)
        {
            // Player 2 scores
            ScoreManager.Instance.Player2Scores();
        }
        else
        {
            // Player 1 scores
            ScoreManager.Instance.Player1Scores();
        }

        // Reset ball
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        other.transform.position = Vector2.zero;
        other.GetComponent<Ball>().LaunchBall();
    }
}