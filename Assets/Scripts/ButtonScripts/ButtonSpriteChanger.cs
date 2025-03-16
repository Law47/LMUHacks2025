using UnityEngine;

public class ButtonSpriteChanger : MonoBehaviour
{
    public Sprite PressedSprite;
    private bool pressed = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController != null)
        {
            if (!pressed) {
                gameObject.GetComponent<SpriteRenderer>().sprite = PressedSprite; 
                pressed = true;
            }
        }
    }
}
