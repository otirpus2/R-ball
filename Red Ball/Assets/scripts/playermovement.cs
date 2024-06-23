using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 8f;
    public float jumpingPower = 16f;
    public float rotationSpeed = 100f; // Adjust as needed
    public float deceleration = 10f;   // Adjust for smooth deceleration
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // Disable gravity temporarily to manage jumping
    }

    void Update()
    {
        // Horizontal movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        // Apply deceleration when no input
        if (Mathf.Approximately(horizontal, 0f) && isGrounded)
        {
            // Apply horizontal deceleration
            rb.velocity = new Vector2(rb.velocity.x * (1f - deceleration * Time.deltaTime), rb.velocity.y);
        }

        // Check if grounded
        isGrounded = IsGrounded();

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        // Calculate rotation angle based on velocity
        float rotationAngle = -rb.velocity.x * rotationSpeed * Time.deltaTime;

        // Apply rotation around the z-axis
        transform.Rotate(Vector3.forward, rotationAngle);

        // Reset rotation when velocity drops
        if (Mathf.Approximately(rb.velocity.x, 0f))
        {
            transform.rotation = Quaternion.identity;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f); // Adjust distance according to your ball size

        // Check if there's ground beneath the ball
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    void FixedUpdate()
    {
        // Enable gravity after the first FixedUpdate to let the ball fall naturally
        if (Time.fixedTime == Time.fixedDeltaTime)
        {
            rb.gravityScale = 1f;
        }
    }
}
