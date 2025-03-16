using UnityEngine;

public class TeleportSplitBar : MonoBehaviour
{
    public Vector2 location;
    private bool activated = false;
    private void OnTriggerEnter2D(Collider2D other) {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController != null) {
            if (!activated) {
                GameObject.FindGameObjectWithTag("SplitBar").GetComponent<SplitBarController>().TeleportSplitBar(location);
                activated = true;
            }
        }
    }
}
