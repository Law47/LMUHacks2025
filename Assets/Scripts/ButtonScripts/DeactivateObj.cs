using UnityEngine;

public class DeactivateObj : MonoBehaviour
{
    public GameObject[] toDeactivate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (GameObject obj in toDeactivate)
            {
                obj.SetActive(false);
            }
        }
    }
}
