using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float maxSpeed = 5f;             // Maximum speed of the bubble
    public float airForceMultiplier = 10f; // Multiplier for air force
    public float dragFactor = 0.98f;       // Drag factor to slow the bubble over time
    public float minSpeedThreshold = 0.05f; // Minimum speed before stopping the bubble completely
    public GameObject popEffect;           // Effect to play when the bubble pops

    // Testing 
    private Vector3 origin;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        origin = transform.position;
    }

    void FixedUpdate()
    {
        // Apply drag to simulate gradual slowing
        ApplyDrag();

        // Clamp the velocity to the maximum speed
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);
    }

    public void ApplyAirForce(Vector2 direction, float strength)
    {
        // Add force to the bubble based on the direction and strength of air
        rb.AddForce(direction * strength * airForceMultiplier * Time.fixedDeltaTime, ForceMode2D.Force);
    }

    private void ApplyDrag()
    {
        // Reduce the bubble's velocity gradually
        if (rb.linearVelocity.magnitude > minSpeedThreshold)
        {
            rb.linearVelocity *= dragFactor;
        }
        else
        {
            // Stop the bubble completely if it is moving too slowly
            rb.linearVelocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Pop the bubble when it enters a designated pop zone
        if (other.CompareTag("PopZone"))
        {
            PopBubble();
        }
    }
    void PopBubble()
    {
        if (popEffect != null)
        {
            Instantiate(popEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }


    [SABI.Button("Reset Bubble")]
    public void ResetBubble()
    {
        transform.position = origin;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }


}


