using UnityEngine;

public class SetSplitBarX : MonoBehaviour
{
    public float x;
    private bool activated = false;
    private void OnTriggerEnter2D(Collider2D other) {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController != null) {
            if (!activated) {
                GameObject.FindGameObjectWithTag("SplitBar").GetComponent<SplitBarController>().MoveSplitBarX(x);
                activated = true;
            }
        }
    }
}
