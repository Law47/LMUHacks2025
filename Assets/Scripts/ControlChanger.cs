using UnityEngine;

public class ControlChanger : MonoBehaviour
{
    [Header("New Control Settings")]
    public KeyCode newMoveLeftKey;
    public KeyCode newMoveRightKey;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.SetMovementKeys(newMoveLeftKey, newMoveRightKey);
        }
    }
}
