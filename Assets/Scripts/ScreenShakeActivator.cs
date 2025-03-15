using UnityEngine;

public class ScreenShakeActivator : MonoBehaviour
{
    public float intensity = 0.4f;
    public float duration = 0.1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindGameObjectWithTag("EffectsManager").GetComponent<EffectsManager>().ScreenShake(intensity, duration);
    }
}
