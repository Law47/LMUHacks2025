using UnityEngine;

public class ScreenShakeOnlyOnce : MonoBehaviour
{
    public float intensity = 0.4f;
    public float duration = 0.1f;
    private bool activated = false;
    private void OnTriggerEnter2D(Collider2D other)
    {   
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController != null)
        {
            if (!activated) {
                GameObject.FindGameObjectWithTag("EffectsManager").GetComponent<EffectsManager>().ScreenShake(intensity, duration);
                activated = true;
            }
        }
    }
}
