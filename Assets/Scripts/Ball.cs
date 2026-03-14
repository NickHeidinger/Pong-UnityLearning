using UnityEngine;

public class Ball : MonoBehaviour
{

    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bool isRight = UnityEngine.Random.value >= 0.5f;

        float xVelocity = -1f;
        if (isRight)
        {
            xVelocity = 1f;
        }

        float yVelocity = UnityEngine.Random.Range(-1f, 1f);
        rb.linearVelocity = new Vector2(xVelocity, yVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
