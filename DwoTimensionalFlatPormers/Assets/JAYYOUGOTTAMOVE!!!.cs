    using UnityEngine;
    using UnityEngine.InputSystem;
    using System.Collections;
    using System.Collections.Generic; 

public class JAYYOUGOTTAMOVE : MonoBehaviour
{
    [Header("playerhappiness")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;

    Vector2 moveVector;
    Rigidbody2D playerorgan;

    private void Start()
    {
        playerorgan = GetComponent<Rigidbody2D>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jump");
            Jump();
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
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
