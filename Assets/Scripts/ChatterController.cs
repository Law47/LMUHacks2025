using UnityEngine;

public class ChatterController : MonoBehaviour
{
    public GameObject dialogue;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController != null)
        {
            dialogue.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController != null)
        {
            dialogue.SetActive(false);
        }
    }
}
