using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float initialSpeed = 6f;
    public float speedIncrement = 0.5f;
    public float maxSpeed = 20f;
    public Transform player1Paddle;

    private float currentSpeed;
    private Vector2 lastVelocityDir;

    void Start()
    {
        currentSpeed = initialSpeed;
        StartCoroutine(WaitForPlayer1Move());
    }

    private System.Collections.IEnumerator WaitForPlayer1Move()
    {
        float startY = player1Paddle.position.y;
        while (Mathf.Approximately(player1Paddle.position.y, startY))
        {
            yield return null;
        }
        LaunchBall();
    }

    public void LaunchBall()
    {
        currentSpeed = initialSpeed;
        bool isRight = UnityEngine.Random.value >= 0.5f;
        float xVelocity = isRight ? 1f : -1f;
        float yVelocity = UnityEngine.Random.Range(-1f, 1f);
        rb.linearVelocity = new Vector2(xVelocity, yVelocity).normalized * currentSpeed;
        lastVelocityDir = rb.linearVelocity.normalized;
    }

    void FixedUpdate()
    {
        if (rb.linearVelocity == Vector2.zero) return;

        Vector2 currentDir = rb.linearVelocity.normalized;

        // X direction flipped = ball bounced off a paddle or side wall
        if (Mathf.Sign(currentDir.x) != Mathf.Sign(lastVelocityDir.x) ||
            Mathf.Sign(currentDir.y) != Mathf.Sign(lastVelocityDir.y))
        {
            currentSpeed = Mathf.Min(currentSpeed + speedIncrement, maxSpeed);
            rb.linearVelocity = currentDir * currentSpeed;
        }

        lastVelocityDir = currentDir;
    }
}
