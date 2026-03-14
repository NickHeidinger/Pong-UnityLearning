using UnityEngine;

public class Paddle1 : MonoBehaviour
{
    public float speed = 5f; // Speed of the paddle
    public float boundary = 4.5f; // Boundary to restrict paddle movement

    // Update is called once per frame
    void Update()
    {
        float move = 0f;

        // Check for input from the W and S keys
        if (Input.GetKey(KeyCode.W))
        {
            move = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move = -1f;
        }

        // Move the paddle
        transform.Translate(0, move * speed * Time.deltaTime, 0);

        // Restrict the paddle within the boundary
        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, -boundary, boundary);
        transform.position = position;
    }
}
