using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float initialSpeed = 6f;
    public Transform player1Paddle;

    void Start()
    {
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
        bool isRight = UnityEngine.Random.value >= 0.5f;
        float xVelocity = isRight ? 1f : -1f;
        float yVelocity = UnityEngine.Random.Range(-1f, 1f);
        rb.linearVelocity = new Vector2(xVelocity, yVelocity).normalized * initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // (empty)
    }
}
