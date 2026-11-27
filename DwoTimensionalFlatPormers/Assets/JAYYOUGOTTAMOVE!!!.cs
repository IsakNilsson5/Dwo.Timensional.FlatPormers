using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

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
    [SerializeField] public int Health = 1;
    [SerializeField] Sprite Jumpie;
    [SerializeField] Sprite Runnies;
    [SerializeField] Sprite Idleieie;
    [SerializeField] bool dashpossible;
    [SerializeField] bool stun;
    [SerializeField] int bigback;
    private void Start()
    {
        playerorgan = GetComponent<Rigidbody2D>();
        bigback = 5;
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        isGrounded2 = Physics2D.OverlapCircle(groundCheck2.position, 0.2f, groundLayer) || Physics2D.OverlapCircle(groundCheck3.position, 0.2f, groundLayer);
        if (isGrounded)
        {
            dashpossible = true;
            moveSpeed = 7.5f;
        }

        if ((isGrounded || isGrounded2) && moveVector.x == 0)
        {
            GetComponent<SpriteRenderer>().sprite = Idleieie;
        }
        else if (!isGrounded)
        {
            GetComponent<SpriteRenderer>().sprite = Jumpie;
        }
        transform.localScale = new Vector2(Health, Health);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && (isGrounded || isGrounded2))
        {
            Debug.Log("Jump");
            Jump();
            return;
        }
        else
        {
            Debug.Log("bad legs");
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
    public void OnInteract(InputAction.CallbackContext context)
    {
            if (dashpossible == true && !isGrounded && !stun)
            {
                Debug.Log("good brains");
                StartCoroutine(Dash());
                return;
            }

            else
            {
                Debug.Log("bad brains");
                return;
            }


    }

    public void FixedUpdate()
    {
        if (!stun)
        {
            playerorgan.linearVelocity = new Vector2(moveVector.x * moveSpeed, playerorgan.linearVelocity.y);
        }
    }
    void Jump() 
   {
        playerorgan.linearVelocityY = 0;
        playerorgan.AddForce(Vector2.up* jumpForce, ForceMode2D.Impulse);
        GetComponent<SpriteRenderer>().sprite = Jumpie;
    }
    IEnumerator Dash()
    {
        stun = true;
        dashpossible = false;
        playerorgan.linearVelocity = Vector2.zero;
        playerorgan.gravityScale = 0;
        yield return new WaitForSeconds(0.1f);
        playerorgan.linearVelocityX = transform.right.x * 100;
        if (moveVector.x > 0)
        {
            playerorgan.linearVelocityX = transform.right.x * 100;
        }
        else if (moveVector.x < 0)
        {
            playerorgan.linearVelocityX = transform.right.x * -100;
        }
        yield return new WaitForSeconds(0.1f);
        playerorgan.linearVelocity = Vector2.zero;
        playerorgan.gravityScale = 0;
        yield return new WaitForSeconds(0.1f);
        playerorgan.gravityScale = bigback;
        stun = false;


    }

}
