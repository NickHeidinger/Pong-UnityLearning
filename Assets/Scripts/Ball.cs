using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float initialSpeed = 6f;

    void Start()
    {
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
        
    }
}
