using UnityEngine;

public class ControlChanger : MonoBehaviour
{
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
