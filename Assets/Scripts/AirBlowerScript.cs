using System;
using UnityEngine;

public class AirBlowerScript : MonoBehaviour
{
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right);
        if (hit.collider != null)
        {
            Rigidbody2D rb = hit.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(Vector2.right * 10f); // Adjust the force magnitude as needed
            }
        }
        
    }
}
