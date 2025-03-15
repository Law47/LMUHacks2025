using UnityEngine;

public class RotateForeverButton : MonoBehaviour
{
    public float rotateFactor;
    private void OnTriggerEnter2D(Collider2D other) {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController != null) {
            GameObject.FindGameObjectWithTag("SplitBar").GetComponent<SplitBarController>().RotateNonStop(rotateFactor);
        }
    }
}
