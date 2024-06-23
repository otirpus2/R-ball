using UnityEngine;

public class WheelMovement : MonoBehaviour
{
    public float speed = 5f; // Linear speed
    public float rotationSpeed = 30f; // Angular speed in degrees per second

    public Rigidbody2D rb;
    public float radius;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        radius = GetComponent<CircleCollider2D>().radius;
    }

    void FixedUpdate()
    {
        // Move forward
        rb.velocity = transform.right * speed;
        
        // Calculate the angular velocity based on the linear speed and the radius
        float circumference = 2 * Mathf.PI * radius;
        rb.angularVelocity = -(speed / circumference) * rotationSpeed;
    }
}
