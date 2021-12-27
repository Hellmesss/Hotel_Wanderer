using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public Animator animator;

    Vector2 movement;

    public static PlayerMovement instance;

    private float moveSpeed;


    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;

        moveSpeed = 5f;
    }

    void Update() //gere les movements du player
    {
        if (!PauseMenu.isGamePaused)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("moveSpeed", movement.sqrMagnitude);
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void AddMoveSpeed (int speed)
    {
        moveSpeed += speed;
    }
}
