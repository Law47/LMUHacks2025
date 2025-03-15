using UnityEngine;

public class GameManager : MonoBehaviour {
    [Header("GameObject Refs")]
    public GameObject SplitBar;
    
    [Header("SplitBar Physics")]
    public float PosAutoMergeDistance;
    public float RotAutoMergeDistance;
    public float ScaleAutoMergeDistance;
    public float SplitBarMoveSpeed;
    public float SplitBarRotationSpeed;
    public float SplitBarScaleSpeed;
    private Rigidbody2D rbSplitBar;
    
    private Vector2 posTargetSplitBar;
    private float rotTargetSplitBar;
    private float scaleTargetSplitBar;
    
    Vector2 toVector2(Vector3 a) {
        return new Vector2(a.x, a.y);
    }
    Vector3 toVector3(Vector2 a) {
        return new Vector3(a.x, a.y, 0f);
    }
    float angularClamp(float a) {
        float b = a;
        while (b > 180) { b -= 180; }
        while (b < -180) { b += 180; }
        return b;
    }
    float getAngleDistance(float a, float b) {
        return Mathf.Abs(a - b);
    }

    void Awake() {
        rbSplitBar = SplitBar.GetComponent<Rigidbody2D>();
        posTargetSplitBar = toVector2(SplitBar.transform.position);
        rotTargetSplitBar = SplitBar.transform.rotation.eulerAngles.z;
        scaleTargetSplitBar = SplitBar.transform.localScale.y;
    }
    void FixedUpdate() {
        float posTargetDeviation = (posTargetSplitBar - toVector2(SplitBar.transform.position)).magnitude;
        if (posTargetDeviation <= PosAutoMergeDistance) {
            SplitBar.transform.position = toVector3(posTargetSplitBar);
        } else {
            rbSplitBar.linearVelocity = (posTargetSplitBar - toVector2(SplitBar.transform.position)).normalized * SplitBarMoveSpeed;
        }
        float rotTargetDeviation = getAngleDistance(rotTargetSplitBar, SplitBar.transform.rotation.eulerAngles.z);
        if (rotTargetDeviation <= RotAutoMergeDistance) {
            SplitBar.transform.rotation = Quaternion.Euler(new Vector3(0f, rotTargetSplitBar, 0f));
        } else {
            rbSplitBar.angularVelocity = rotTargetSplitBar < angularClamp(rbSplitBar.transform.rotation.eulerAngles.z) ? -SplitBarRotationSpeed : SplitBarRotationSpeed;
            Debug.Log($"Actual: {rbSplitBar.angularVelocity},   Expected: {(rotTargetSplitBar < angularClamp(rbSplitBar.transform.rotation.eulerAngles.z) ? SplitBarRotationSpeed : -SplitBarRotationSpeed)}");
        }
        float scaleTargetDeviation = Mathf.Abs(scaleTargetSplitBar - SplitBar.transform.localScale.y);
        if (scaleTargetDeviation <= ScaleAutoMergeDistance) {
            SplitBar.transform.localScale = new Vector3(SplitBar.transform.localScale.x, scaleTargetSplitBar, SplitBar.transform.localScale.z);
        } else {
            rbSplitBar.transform.localScale = new Vector3(SplitBar.transform.localScale.x, rbSplitBar.transform.localScale.y * (scaleTargetSplitBar < rbSplitBar.transform.localScale.y ? 1 - SplitBarScaleSpeed : 1 + SplitBarScaleSpeed), SplitBar.transform.localScale.z);
        }
        Debug.Log($"Angle: {angularClamp(rbSplitBar.transform.rotation.eulerAngles.z)},   Target Angle: {rotTargetSplitBar}");
        Debug.Log($"Deviations: [{posTargetDeviation}, {rotTargetDeviation}, {scaleTargetDeviation}]");
    }

    public void SetSplitBarMoveSpeed(float a) { SplitBarMoveSpeed = a; }
    public void SetSplitBarRotationSpeed(float a) { SplitBarRotationSpeed = a; }
    public void SetSplitBarScaleSpeed(float a) { SplitBarScaleSpeed = a; }

    public void MoveSplitBarX(float x) { posTargetSplitBar.x += x; }
    public void MoveSplitBarY(float y) { posTargetSplitBar.y += y; }
    public void RotateSplitBar(float degrees) { rotTargetSplitBar += degrees; }
    public void StretchSplitBar(float scale) { scaleTargetSplitBar *= scale; }
}
