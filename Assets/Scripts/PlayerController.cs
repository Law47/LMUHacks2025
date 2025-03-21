using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode restartKey = KeyCode.F1;
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;

    public UnityEvent walkingRight;
    public UnityEvent walkingLeft;
    public UnityEvent notWalking;
    public UnityEvent changeKeys;
    public GameObject changeKeyColliderObj;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing from this game object.");
        }
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float moveDirection = 0f;

        if (Input.GetKey(moveLeftKey))
        {
            moveDirection = -1f;
            anim.SetBool("walking", true);
            spr.flipX = true;
            walkingLeft.Invoke();
        }
        else if (Input.GetKey(moveRightKey))
        {
            moveDirection = 1f;
            anim.SetBool("walking", true);
            spr.flipX = false;
            walkingRight.Invoke();
        }
        else if (Input.GetKey(restartKey)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else 
        {
            anim.SetBool("walking", false);
            notWalking.Invoke();
        }

        rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);
    }

    public void SetMovementKeys(KeyCode newLeftKey, KeyCode newRightKey, GameObject buttonObject)
    {
        if (newLeftKey != KeyCode.None)
        {
            moveLeftKey = newLeftKey;
        }
        if (newRightKey != KeyCode.None)
        {
            moveRightKey = newRightKey;
        }
        changeKeyColliderObj = buttonObject;
        changeKeys.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            if (SceneManager.GetActiveScene().name == "Level7")
            {
                SceneManager.LoadScene("MainMenu");
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
