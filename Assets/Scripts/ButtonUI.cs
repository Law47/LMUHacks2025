using TMPro;
using UnityEngine;

public class ButtonUI : MonoBehaviour {
    public GameObject jason1;
    private PlayerController jason1Controller;
    public GameObject jason2;
    private PlayerController jason2Controller;

    private GameObject canvas;
    private GameObject jason1Forward;
    private TextMeshProUGUI jason1FText;
    private GameObject jason1Back;
    private TextMeshProUGUI jason1BText;
    private GameObject jason2Forward;
    private TextMeshProUGUI jason2FText;
    private GameObject jason2Back;
    private TextMeshProUGUI jason2BText;
    void Awake() {
        canvas = transform.Find("UI").gameObject;
        jason1Forward = canvas.transform.Find("Jason1Forward").gameObject;
        jason1FText = jason1Forward.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
        jason1Back = canvas.transform.Find("Jason1Back").gameObject;
        jason1BText = jason1Back.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
        jason2Forward = canvas.transform.Find("Jason2Forward").gameObject;
        jason2FText = jason2Forward.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
        jason2Back = canvas.transform.Find("Jason2Back").gameObject;
        jason2BText = jason2Back.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();

        jason1Controller = jason1.GetComponent<PlayerController>();
        jason2Controller = jason2.GetComponent<PlayerController>();

        jason1FText.text = jason1Controller.moveRightKey.ToString();
        jason1BText.text = jason1Controller.moveLeftKey.ToString();
        jason2FText.text = jason2Controller.moveRightKey.ToString();
        jason2BText.text = jason2Controller.moveLeftKey.ToString();
    }
    void Update() {
        jason1FText.text = jason1Controller.moveRightKey.ToString();
        jason1BText.text = jason1Controller.moveLeftKey.ToString();
        jason2FText.text = jason2Controller.moveRightKey.ToString();
        jason2BText.text = jason2Controller.moveLeftKey.ToString();
    }
}
