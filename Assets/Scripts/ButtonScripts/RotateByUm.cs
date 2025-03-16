using UnityEngine;

public class RotateByUm : MonoBehaviour
{
    public float rotation;
    private bool activated = false;
    private void OnTriggerEnter2D(Collider2D other) {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController != null) {
            if (!activated) {
                GameObject.FindGameObjectWithTag("SplitBar").GetComponent<SplitBarController>().RotateSplitBar(rotation);
                activated = true;
            }
        }
    }
}
