using UnityEngine;

public class Paddle2 : MonoBehaviour
{
    public float speed = 1f;
    public float upperBoundary = 2.65f;
    public float lowerBoundary = -4.17f;
    public Transform ball;

    void Update()
    {
        if (ball == null) return;

        float diff = ball.position.y - transform.position.y;

        // Only move if the ball is far enough away (adds reaction dead zone)
        if (Mathf.Abs(diff) < 0.1f) return;

        float move = Mathf.Clamp(diff, -speed * Time.deltaTime, speed * Time.deltaTime);
        transform.Translate(0, move, 0);

        // Restrict within boundaries
        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, lowerBoundary, upperBoundary);
        transform.position = position;
    }
}
