using UnityEngine;
using UnityEngine.SceneManagement;

public class evilahhscript : MonoBehaviour
{
    [SerializeField] JAYYOUGOTTAMOVE player;

    [SerializeField] Rigidbody2D evilorgans;
    [SerializeField] float evilrunspeed;
    [SerializeField] Transform evilturn;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] bool iswall;
    [SerializeField] Transform wallcheck;
    [SerializeField] bool isledge;
    [SerializeField] Transform ledgecheck;
    [SerializeField] Transform floorcheck;
    [SerializeField] bool isfloor;
    Vector2 evilmovevector;

    private void Start()
    {
        evilorgans = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        evilorgans.linearVelocityX = transform.right.x * evilrunspeed;

        isfloor = Physics2D.OverlapCircle(floorcheck.position, 0.2f, groundLayer);
        iswall = Physics2D.OverlapCircle(wallcheck.position, 0.2f, groundLayer);
        isledge = Physics2D.OverlapCircle(ledgecheck.position, 0.2f, groundLayer);
        if (!isledge || iswall)
        {
            evilturn.rotation *= Quaternion.Euler(0, 180, 0);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && player.Health == 1)
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(0);  
        }
        else if (collision.gameObject.CompareTag("Player") && player.Health == 2)
        {
            player.Health = 1;
        }
    }
}