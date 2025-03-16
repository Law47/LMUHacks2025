using UnityEngine;

public class ActivateObj : MonoBehaviour
{
    public GameObject[] toActivate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (GameObject obj in toActivate)
            {
                obj.SetActive(true);
            }
        }
    }
}
