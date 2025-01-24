using System;
using UnityEngine;

public class AirBlowerScript : MonoBehaviour
{
    [SerializeField] private float airForceMultiplier = 5f;
    [SerializeField] private float rayDistance = 5f;

    private void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, rayDistance);
        if (hit.collider != null)
        {
            Bubble rb = hit.collider.GetComponent<Bubble>();
            if (rb != null)
            {
                rb.ApplyAirForce(transform.right, airForceMultiplier);
            }
        }

    }

    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right * rayDistance);
    }
}
