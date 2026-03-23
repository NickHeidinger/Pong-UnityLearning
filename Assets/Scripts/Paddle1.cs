using UnityEngine;
using UnityEngine.InputSystem; // Import the Input System namespace

public class Paddle1 : MonoBehaviour
{
    public float speed = 5f; // Speed of the paddle
    public float upperBoundary = 2.65f; // Upper boundary to restrict paddle movement
    public float lowerBoundary = -4.17f; // Lower boundary to restrict paddle movement
    private float move = 0f; // Movement input value

    // Update is called once per frame
    void Update()
    {
        // Read input from the new Input System
        if (Keyboard.current.wKey.isPressed)
        {
            move = 2f;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move = -2f;
        }
        else
        {
            move = 0f;
        }

        // Move the paddle
        transform.Translate(0, move * speed * Time.deltaTime, 0);

        // Restrict the paddle within the boundary
        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, lowerBoundary, upperBoundary);
        transform.position = position;
    }
}
