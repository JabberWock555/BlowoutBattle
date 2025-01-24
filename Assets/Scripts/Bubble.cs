using UnityEngine;

public class Bubble : MonoBehaviour
{

    public float bubbleSpeed = 2f;      // Base speed of the bubble
    public float airForceMultiplier = 5f; // Force multiplier for hand dryer air
    public GameObject popEffect;       // Particle effect prefab for popping the bubble

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Clamp the bubble's velocity to prevent it from going too fast
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, bubbleSpeed);
    }

    public void ApplyAirForce(Vector2 direction, float strength)
    {
        rb.AddForce(direction * strength * airForceMultiplier, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Pop the bubble if it enters a specific zone (e.g., the opponent's court)
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
}


