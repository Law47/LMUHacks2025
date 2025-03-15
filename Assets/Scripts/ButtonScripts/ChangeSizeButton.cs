using UnityEngine;

public class ChangeSizeButton : MonoBehaviour
{
    public float scaleFactor;
    private bool activated;
    void Awake() {
        activated = false;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController != null) {
            if (!activated) {
            GameObject.FindGameObjectWithTag("SplitBar").GetComponent<SplitBarController>().StretchSplitBar(scaleFactor);
            activated = true;
            }
        }
    }
}
