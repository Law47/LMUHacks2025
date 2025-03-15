using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing from this game object.");
        }
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float moveDirection = 0f;

        if (Input.GetKey(moveLeftKey))
        {
            moveDirection = -1f;
        }
        else if (Input.GetKey(moveRightKey))
        {
            moveDirection = 1f;
        }

        rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);
    }

    public void SetMovementKeys(KeyCode newLeftKey, KeyCode newRightKey)
    {
        if (newLeftKey != KeyCode.None)
        {
            moveLeftKey = newLeftKey;
        }
        if (newRightKey != KeyCode.None)
        {
            moveRightKey = newRightKey;
        }
    }
}
