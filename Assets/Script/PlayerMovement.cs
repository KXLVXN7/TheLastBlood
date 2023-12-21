using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool canMove = true;
    public Animator anim; // Corrected variable name

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>(); // Corrected variable assignment
    }

    void Update()
    {
        if (canMove)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);
            rb.velocity = movement;

            // Player flip logic
            Flip(horizontalInput);

            // Animation logic
            if (Mathf.Abs(horizontalInput) > 0 || Mathf.Abs(verticalInput) > 0)
            {
                anim.SetBool("run", true);
            }
            else
            {
                anim.SetBool("run", false);
            }
        }
    }
    
    public void Freze ()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        anim.SetBool("run", false);
        Debug.Log("Freeze");
    }
    public void Unfreeze()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Reset constraints to unfreeze position
        anim.SetBool("run", true); // Set the animation parameter to start playing
        Debug.Log("Unfreeze");
    }

    void Flip(float horizontalInput)
    {
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove; // Corrected assignment to use "this" to refer to the class variable
    }
}