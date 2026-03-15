using UnityEngine;

public class Paddle2 : MonoBehaviour
{
    public float speed = 5f;
    public float upperBoundary = 2.65f;
    public float lowerBoundary = -4.17f;
    public Transform ball;

    void Update()
    {
        if (ball == null) return;

        // Move toward the ball's Y position
        float direction = Mathf.Sign(ball.position.y - transform.position.y);
        transform.Translate(0, direction * speed * Time.deltaTime, 0);

        // Restrict within boundaries
        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, lowerBoundary, upperBoundary);
        transform.position = position;
    }
}
