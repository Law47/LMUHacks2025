using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject splitBar;

    public void MoveSplitBar(Vector2 transformation) {
        splitBar.transform.position += new Vector3(transformation.x, transformation.y, 0);
    }

    public void RotateSplitBar(float degrees) {
        splitBar.transform.rotation = Quaternion.Euler(new Vector3(0, 0, degrees));
    }

    void Awake() {
        
    }

    void Update() {
        
    }
}
