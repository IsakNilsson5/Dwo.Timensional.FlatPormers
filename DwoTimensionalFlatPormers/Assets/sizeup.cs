using Unity.VisualScripting;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    [SerializeField] JAYYOUGOTTAMOVE player;

    [SerializeField] Rigidbody2D foodorgans;
    [SerializeField] float foodspeed;
    [SerializeField] Transform foodtransform;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] bool iswall;
    [SerializeField] Transform wallcheck;
    Vector2 foodmovevector;
    GameManager gameManager;

    private void Start()
    {
        foodorgans = GetComponent<Rigidbody2D>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void FixedUpdate()
    { 
        foodorgans.linearVelocityX = transform.right.x * foodspeed;

        iswall = Physics2D.OverlapCircle(wallcheck.position, 0.2f, groundLayer);
        if (iswall)
        {
            foodtransform.rotation *= Quaternion.Euler(0, 180, 0);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player.Health == 2)
            {
                gameManager.Scoresuh(1);
            }
            else
            {
                player.Health = 2;
            }
                Destroy(gameObject);
        }
    }
}
