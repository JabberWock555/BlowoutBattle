using System;
using System.Collections;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float maxSpeed = 5f;             // Maximum speed of the bubble
    public float airForceMultiplier = 10f; // Multiplier for air force
    public float dragFactor = 0.98f;       // Drag factor to slow the bubble over time
    public float minSpeedThreshold = 0.05f; // Minimum speed before stopping the bubble completely
    public GameObject popEffect;           // Effect to play when the bubble pops
    [SerializeField] private AudioClip popSound; // Sound to play when the bubble pops
    [SerializeField] private AudioClip bounceSound; // Sound to play when the bubble pops

    [Header("PowerUps controller")]
    [SerializeField] PowerUpType powerUpType;
    [Header("SmashPowerUp")]
    [SerializeField] private float smashForceAdd = 10f;




    private int bounceCount = 0;            // Number of times the bubble has bounced off a ground surface
    private AudioSource audioSource;
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

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        origin = transform.position;

        if (CoOpManager.Instance)
        {
            CoOpManager.Instance.activatePowerUPAction += ActivatePowerUp;
            CoOpManager.Instance.deactivatePowerUPAction += PowerUpCoolDown;
        }
        freezeTimer = 0f;
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

        // Unfreeze if a player collides with frozen bubble
        if (TryGetComponent(out PlayerController playerController))
        {
            if (bubbleState == BubbleState.Frozen) UnfreezeBubble();
        }

        if (other.gameObject.CompareTag("Goal1"))
        {
            Debug.Log("Goal1");
            GameManager.Instance.uiManager.coOpUIPanelHandler.SetScore(2);
            ResetBubble(2);
        }

        else if (other.gameObject.CompareTag("Goal2"))
        {
            Debug.Log("Goal2");
            GameManager.Instance.uiManager.coOpUIPanelHandler.SetScore(1);
            ResetBubble(1);

        }
    }

    private void OnDestroy()
    {
        if (CoOpManager.Instance)
        {
            CoOpManager.Instance.activatePowerUPAction -= ActivatePowerUp;
            CoOpManager.Instance.deactivatePowerUPAction -= PowerUpCoolDown;
        }
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

    private void GroundBounce(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            audioSource.PlayOneShot(bounceSound);
            Debug.Log("Ground Bounce");
            bounceCount++;
            GameManager.Instance.uiManager.coOpUIPanelHandler.RemoveOneBubbleIcon();
            if (bounceCount >= 3)
            {
                PopBubble();
            }
        }
    }

    void PopBubble()
    {
        int score = 1;
        if (isBonusActive)
        {
            score = 2;
        }

        audioSource.PlayOneShot(popSound);
        if (popEffect != null)
        {
            Instantiate(popEffect, transform.position, Quaternion.identity);
        }
        // Destroy(gameObject);

        int index = 0;
        if (transform.position.x > 0f)
        {
            GameManager.Instance.uiManager.coOpUIPanelHandler.SetScore(1, score);
            index = 2;
        }
        else if (transform.position.x < 0f)
        {
            index = 1;
            GameManager.Instance.uiManager.coOpUIPanelHandler.SetScore(2, score);
        }
        else
        {
            index = 0;
        }
        ResetBubble(index);

        GameManager.Instance.uiManager.coOpUIPanelHandler.AddMaxToBubbleDisplay();
    }





    #region PowerUps

    private bool isBonusActive = false;

    private void ActivatePowerUp(BasePowerUp powerUp)
    {
        if (CoOpManager.Instance.isPowerUPActive) return;

        powerUpType = powerUp.powerUpSO.powerUpType;
        switch (powerUpType)
        {
            case PowerUpType.BonusPoint:
                isBonusActive = true;
                return;
            case PowerUpType.Freeze:
                FreezeBubble();
                break;
            case PowerUpType.Smash:
                ActivateSmashPower();
                break;
            default:
                break;
        }

    }

    private void PowerUpCoolDown(BasePowerUp powerUp)
    {
        StartCoroutine(PowerUpCoolDownCoroutine(powerUp));
    }
    IEnumerator PowerUpCoolDownCoroutine(BasePowerUp powerUp)
    {
        yield return new WaitForSeconds(powerUp.powerUpSO.coolDownTime);

        switch (powerUpType)
        {
            case PowerUpType.BonusPoint:
                isBonusActive = false;
                break;
            case PowerUpType.Freeze:
                UnfreezeBubble();
                break;
            case PowerUpType.Smash:
                DeactivateSmashPower();
                break;
            default:
                break;
        }

    }

    #region SmashPower
    private void ActivateSmashPower()
    {
        airForceMultiplier += smashForceAdd;
    }

    private void DeactivateSmashPower()
    {
        airForceMultiplier -= smashForceAdd;
    }
    #endregion

    #region FreezePower
    [SABI.Button("Freeze Bubble")]
    public void FreezeBubble()
    {
        recordedVelocity = rb.linearVelocity;
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0;
        gameObject.layer = LayerMask.NameToLayer("Default"); // To prevent collision with air stream
        bubbleState = BubbleState.Frozen;
    }

    [SABI.Button("UnFreeze Bubble")]
    private void UnfreezeBubble()
    {
        rb.linearVelocity = recordedVelocity;
        rb.gravityScale = .3f;
        bubbleState = BubbleState.Normal;
        gameObject.layer = LayerMask.NameToLayer("Bubble");
    }
    #endregion


    #endregion
    #endregion

    [SABI.Button("Reset Bubble")]
    public void ResetBubble(int index)
    {


        bounceCount = 0;
        CoOpManager.Instance.SpawnBubble(index);


        GameManager.Instance.uiManager.coOpUIPanelHandler.AddMaxToBubbleDisplay();

        /*  transform.position = origin;
          rb.linearVelocity = Vector2.zero;
          rb.angularVelocity = 0f;
          bounceCount = 0;*/
    }






}

