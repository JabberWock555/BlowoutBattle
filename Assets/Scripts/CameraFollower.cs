using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; // The character to follow

    [Header("Camera Settings")]
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Offset from the target
    public float smoothSpeed = 0.125f; // Smoothness factor (lower is smoother)

    [Header("Bounds (Optional)")]
    public bool useBounds = false; // Enable bounds for camera movement
    public Vector2 minBounds; // Minimum X and Y bounds
    public Vector2 maxBounds; // Maximum X and Y bounds

    private void LateUpdate()
    {
        if (target == null) return;

        // Calculate the desired position with the offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Apply bounds if enabled
        if (useBounds)
        {
            smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minBounds.x, maxBounds.x);
            smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, minBounds.y, maxBounds.y);
        }

        // Update the camera's position
        transform.position = smoothedPosition;
    }
}
