    using UnityEngine;
    using UnityEngine.InputSystem;

public class JAYYOUGOTTAMOVE : MonoBehaviour
{
    [Header("playerhappiness")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] public bool isGrounded;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform groundCheck2;
    [SerializeField] Transform groundCheck3;
    [SerializeField] public bool isGrounded2;
    Vector2 moveVector;
    Rigidbody2D playerorgan;
    [SerializeField] int Health = 1;
    [SerializeField] Sprite Jumpie;
    [SerializeField] Sprite Runnies;
    [SerializeField] Sprite Idleieie;

    private void Start()
    {
        playerorgan = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        isGrounded2 = Physics2D.OverlapCircle(groundCheck2.position, 0.2f, groundLayer) || Physics2D.OverlapCircle(groundCheck3.position, 0.2f, groundLayer);

        if ((isGrounded || isGrounded2) && moveVector.x == 0)
        {
            GetComponent<SpriteRenderer>().sprite = Idleieie;
        }
        else if (!isGrounded)
        {
            GetComponent<SpriteRenderer>().sprite = Jumpie;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && (isGrounded || isGrounded2))
        {
            Debug.Log("Jump");
            Jump();
        }
        else
        {
            Debug.Log("bad legs");
            return;
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
        if (moveVector.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<SpriteRenderer>().sprite = Runnies;
        }
        else if (moveVector.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<SpriteRenderer>().sprite = Runnies;
        }
    }

    public void FixedUpdate()
    {
        playerorgan.linearVelocity = new Vector2(moveVector.x * moveSpeed, playerorgan.linearVelocity.y);

    }
    void Jump() 
   {
        playerorgan.linearVelocityY = 0;
        playerorgan.AddForce(Vector2.up* jumpForce, ForceMode2D.Impulse);
        GetComponent<SpriteRenderer>().sprite = Jumpie;
    }    

}
