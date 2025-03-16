using UnityEngine;

public class MoveYByUm : MonoBehaviour
{
    public float y;
    private bool activated = false;
    private void OnTriggerEnter2D(Collider2D other) {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController != null) {
            if (!activated) {
                GameObject.FindGameObjectWithTag("SplitBar").GetComponent<SplitBarController>().MoveSplitBarY(y);
                activated = true;
            }
        }
    }
}
