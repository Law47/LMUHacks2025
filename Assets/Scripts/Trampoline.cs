using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounceForce = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);
        }
    }
}