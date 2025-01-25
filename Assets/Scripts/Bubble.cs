using System;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float maxSpeed = 5f;             // Maximum speed of the bubble
    public float airForceMultiplier = 10f; // Multiplier for air force
    public float dragFactor = 0.98f;       // Drag factor to slow the bubble over time
    public float minSpeedThreshold = 0.05f; // Minimum speed before stopping the bubble completely
    public GameObject popEffect;           // Effect to play when the bubble pops

    private int bounceCount = 0;            // Number of times the bubble has bounced off a ground surface

    // PowerUps
    private float freezeTime = 3f;
    private float freezeTimer;
    private BubbleState bubbleState = BubbleState.Normal;
    private Vector2 recordedVelocity;
    private enum BubbleState
    {
        Normal,
        Frozen,
        BonusPoint
    }
    
    // Testing 
    private Vector3 origin;

    private Rigidbody2D rb;

    #region Unity Methods
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        origin = transform.position;

        if (GamePlayManager.Instance)
            GamePlayManager.Instance.activatePowerUPAction += ActivatePowerUp;
        freezeTimer = 0f;
    }

    private void Update()
    {
        if (bubbleState == BubbleState.Frozen)
        {
            RunFreezeTimer();
        }
    }

    void FixedUpdate()
    {
        // Apply drag to simulate gradual slowing
        ApplyDrag();

        // Clamp the velocity to the maximum speed
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Bounce the bubble when it collides with a ground surface
        GroundBounce(other);

    }
    #endregion

    #region Mechanics
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Bounce the bubble when it collides with a ground surface
        GroundBounce(other);

        // Unfreeze if a player collides with frozen bubble
        if (TryGetComponent(out PlayerController playerController))
        {
            if (bubbleState == BubbleState.Frozen) UnfreezeBubble();
        }
        
    }

    private void GroundBounce(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground Bounce");
            bounceCount++;
            GameManager.Instance.uiManager.coOpuiPanelHandler.RemoveOneBubbleIcon();
            if (bounceCount >= 3)
            {
                PopBubble();
            }
        }
    }

    void PopBubble()
    {
        if (popEffect != null)
        {
            Instantiate(popEffect, transform.position, Quaternion.identity);
        }
        // Destroy(gameObject);
        ResetBubble();
        GameManager.Instance.uiManager.coOpuiPanelHandler.AddMaxToBubbleDisplay();
    }

    #region PowerUps
    private void ActivatePowerUp(BasePowerUp powerUp)
    {

    }
    #endregion
    #endregion

    [SABI.Button("Reset Bubble")]
    public void ResetBubble()
    {
        transform.position = origin;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        bounceCount = 0;
    }

    #region PowerUps

    [SABI.Button("Freeze Bubble")]
    public void FreezeBubble()
    {
        recordedVelocity = rb.linearVelocity;
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0;
        gameObject.layer = LayerMask.NameToLayer("Default"); // To prevent collision with air stream
        
        bubbleState = BubbleState.Frozen;
    }
    
    private void RunFreezeTimer()
    {
        freezeTimer -= Time.deltaTime;
        if (freezeTimer <= 0f)
        {
            freezeTimer = freezeTime;
            UnfreezeBubble();
        }
    }

    private void UnfreezeBubble()
    {
        rb.linearVelocity = recordedVelocity;
        rb.gravityScale = 1;
        bubbleState = BubbleState.Normal;
        gameObject.layer = LayerMask.NameToLayer("Bubble");
    }

    #endregion
}

