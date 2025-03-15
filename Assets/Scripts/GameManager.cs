using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject splitBar;
    private Rigidbody2D rbSplitBar;
    
    private Vector2 posTargetSplitBar;
    private float rotTargetSplitBar;
    private float scaleTargetSplitBar;
    
    Vector2 toVector2(Vector3 a) {
        return new Vector2(a.x, a.y);
    }

    void Awake() {
        rbSplitBar = splitBar.GetComponent<Rigidbody2D>();
        posTargetSplitBar = toVector2(splitBar.transform.position);
        rotTargetSplitBar = splitBar.transform.rotation.eulerAngles.z;
        scaleTargetSplitBar = splitBar.transform.localScale.y;
    }
    void FixedUpdate() {
        float posTargetDeviation = (posTargetSplitBar - toVector2(splitBar.transform.position)).magnitude;
    }

    public void MoveSplitBarX(float x) {
        posTargetSplitBar.x += x;
    }
    public void MoveSplitBarY(float y) {
        posTargetSplitBar.y += y;
    }
    public void RotateSplitBar(float degrees) {
        rotTargetSplitBar += degrees;
    }
    public void StretchSplitBar(float scale) {
        scaleTargetSplitBar *= scale;
    }
}
