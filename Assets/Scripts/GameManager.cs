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
    float angleClamp1(float a) {
        while (a > 360f) {
            a -= 360f;
        }
        while (a < -360f) {
            a += 360f;
        }
        return a;
    }
    float angularClamp2(float a) {
        if (a > 180) { return -(360 - a); }
        else if (a < -180) { return 360 + a; }
        return a;
    }
    float getAngleDistance(float a, float b) {
        a = a < 0 ? a + 360: a;
        b = b < 0 ? b + 360: b;
        float d = a - b;
        if (d < -180) {
            d += 360;
        } else if (d > 180) {
            d -= 360;
        }
        return Mathf.Abs(d);
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
            SplitBar.transform.position += toVector3((posTargetSplitBar - toVector2(SplitBar.transform.position)).normalized * SplitBarMoveSpeed);
        }
        float rotTargetDeviation = getAngleDistance(rotTargetSplitBar, SplitBar.transform.rotation.eulerAngles.z);
        if (rotTargetDeviation <= RotAutoMergeDistance) {
            SplitBar.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, rotTargetSplitBar));
        } else {
            SplitBar.transform.rotation = Quaternion.Euler(SplitBar.transform.rotation.eulerAngles + new Vector3(0f, 0f, rotTargetSplitBar < angularClamp2(rbSplitBar.transform.rotation.eulerAngles.z) ? -SplitBarRotationSpeed : SplitBarRotationSpeed));
            Debug.Log($"Actual: {rbSplitBar.angularVelocity},   Expected: {(rotTargetSplitBar < angularClamp2(rbSplitBar.transform.rotation.eulerAngles.z) ? SplitBarRotationSpeed : -SplitBarRotationSpeed)}");
        }
        float scaleTargetDeviation = Mathf.Abs(scaleTargetSplitBar - SplitBar.transform.localScale.y);
        if (scaleTargetDeviation <= ScaleAutoMergeDistance) {
            SplitBar.transform.localScale = new Vector3(SplitBar.transform.localScale.x, scaleTargetSplitBar, SplitBar.transform.localScale.z);
        } else {
            rbSplitBar.transform.localScale = new Vector3(SplitBar.transform.localScale.x, rbSplitBar.transform.localScale.y * (scaleTargetSplitBar < rbSplitBar.transform.localScale.y ? 1 - SplitBarScaleSpeed : 1 + SplitBarScaleSpeed), SplitBar.transform.localScale.z);
        }
        Debug.Log($"Angle: {rbSplitBar.transform.rotation.eulerAngles.z}   ,Clamped Angle: {angularClamp2(rbSplitBar.transform.rotation.eulerAngles.z)},   Target Angle: {rotTargetSplitBar}");
        Debug.Log($"Deviations: [{posTargetDeviation}, {rotTargetDeviation}, {scaleTargetDeviation}]");
    }

    public void SetSplitBarMoveSpeed(float a) { SplitBarMoveSpeed = a; }
    public void SetSplitBarRotationSpeed(float a) { SplitBarRotationSpeed = a; }
    public void SetSplitBarScaleSpeed(float a) { SplitBarScaleSpeed = a; }

    public void MoveSplitBarX(float x) { posTargetSplitBar.x += x; }
    public void MoveSplitBarY(float y) { posTargetSplitBar.y += y; }
    public void RotateSplitBar(float degrees) { rotTargetSplitBar = angleClamp1(rotTargetSplitBar + degrees); }
    public void StretchSplitBar(float scale) { scaleTargetSplitBar *= scale; }
}
