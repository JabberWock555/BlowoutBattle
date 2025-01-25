using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyAIController : BaseBlowerController
{
    public Transform bubble; // Reference to the bubble in the scene
    public Transform goalPost; // Reference to the enemy's goal post
    public float attackRange = 10f; // Range within which the enemy will attack the bubble
    public float defendRange = 5f; // Range within which the enemy will defend the goal post
    public float rotationThreshold = 0f; // Threshold to stop rotating when facing the target
    private float currentRotationVelocity;

    void FixedUpdate()
    {
        if (bubble == null || goalPost == null)
        {
            Debug.LogWarning("Bubble or Goal Post reference is missing!");
            return;
        }

        // Calculate distances
        float distanceToBubble = Vector2.Distance(transform.position, bubble.position);
        float distanceToGoal = Vector2.Distance(transform.position, goalPost.position);

        /* // Decide whether to attack or defend
         if (distanceToBubble < attackRange && distanceToBubble < distanceToGoal)
         {
             AttackBubble();
         }
         else if (distanceToGoal < defendRange)
         {
             DefendGoal();
         }
         else
         {*/
        // Move towards the bubble if it's not in attack range and not defending
        MoveTowardsBubble();
        // }
    }

    private void AttackBubble()
    {
        // Rotate towards the bubble
        RotateTowards(bubble.position);

        // Blow air at the bubble
        BlowerONBlowBubble();
    }

    private void DefendGoal()
    {
        // Rotate towards the goal post
        RotateTowards(goalPost.position);

        // Blow air to push the bubble away from the goal
        BlowerONBlowBubble();
    }

    private void MoveTowardsBubble()
    {
        // Rotate towards the bubble
        RotateTowards(bubble.position);

        // Blow air to move towards the bubble using recoil
        BlowerONBlowBubble();
    }

    private void RotateTowards(Vector3 targetPosition)
    {
        // Calculate the direction to the target
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Calculate the target angle in degrees (using Atan2 for proper signed angle)
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Create the target rotation as a quaternion
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);

        // Smoothly interpolate between the current rotation and the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Prevent flipping upside down
        Vector3 localScale = transform.localScale;
        localScale.y = (targetAngle > 90 || targetAngle < -90) ? -Mathf.Abs(localScale.y) : Mathf.Abs(localScale.y);
        transform.localScale = localScale;

        // Debugging: Draw the direction to the target
        Debug.DrawRay(transform.position, direction * 5f, Color.blue);
    }


}
