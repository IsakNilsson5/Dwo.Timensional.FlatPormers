    using UnityEngine;
    using UnityEngine.InputSystem;
    using System.Collections;
    using System.Collections.Generic; 

public class JAYYOUGOTTAMOVE : MonoBehaviour
{
    [Header("playerhappiness")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] bool isGrounded;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform groundCheck2;
    [SerializeField] Transform groundCheck3;
    Vector2 moveVector;
    Rigidbody2D playerorgan;

    private void Start()
    {
        playerorgan = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer) || Physics2D.OverlapCircle(groundCheck2.position, 0.2f, groundLayer) || Physics2D.OverlapCircle(groundCheck3.position, 0.2f, groundLayer);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
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
    }
    private void OnDrawGizmosSelected()
    {
        if(isGrounded)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireSphere(groundCheck.position, 0.2f);
    }
    public void FixedUpdate()
    {
        playerorgan.linearVelocity = new Vector2(moveVector.x * moveSpeed, playerorgan.linearVelocity.y);
    }
    void Jump() 
   {
        playerorgan.linearVelocityY = 0;
        playerorgan.AddForce(Vector2.up* jumpForce, ForceMode2D.Impulse);
   }    

}
