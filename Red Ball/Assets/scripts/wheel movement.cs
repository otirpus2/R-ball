using UnityEngine;

public class RollingCircle : MonoBehaviour
{
    public float speed = 5f; // Linear speed
    public float rotationSpeed = 10f; // Angular speed in degrees per second

    private Rigidbody2D rb;
    private float radius;
    private float direction = 0f; // Direction of movement: -1 for backward, 1 for forward, 0 for no movement

    void Start()
    {
        // Get the Rigidbody2D component attached to the GameObject
        rb = GetComponent<Rigidbody2D>();
        // Get the radius of the CircleCollider2D component attached to the GameObject
        radius = GetComponent<CircleCollider2D>().radius;
    }

    void Update()
    {
        // Check for input to move forward or backward
        if (Input.GetKey(KeyCode.D))
        {
            direction = 1f; // Move forward
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction = -1f; // Move backward
        }
        else
        {
            direction = 0f; // No movement
        }
    }

    void FixedUpdate()
    {
        // Move the circle based on the direction
        rb.velocity = transform.right * speed * direction;

        // Calculate the angular velocity based on the linear speed and the radius
        float circumference = 2 * Mathf.PI * radius;
        float angularVelocity = -(speed / circumference) * 360f * direction; // Full rotation in degrees per second

        // Set the angular velocity
        rb.angularVelocity = angularVelocity;
    }
}
