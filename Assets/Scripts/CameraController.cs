using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float minClamp, maxClamp;

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, minClamp, maxClamp), transform.position.y, transform.position.z);
    }
}
