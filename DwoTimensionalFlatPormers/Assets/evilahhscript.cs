using UnityEngine;

public class evilahhscript : MonoBehaviour
{
    [SerializeField] Rigidbody2D evilorgans;
    [SerializeField] float evilrunspeed;
    [SerializeField] Transform evilturn;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] bool isgrounded;
    [SerializeField] Transform groundcheck;
    Vector2 evilmovevector;

    private void Start()
    {
        evilorgans = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        evilorgans.linearVelocity = new Vector2(evilmovevector.x * evilrunspeed, evilorgans.linearVelocity.y);

        if (!isgrounded)
        {
            evilturn.rotation = Quaternion.Euler(0, 180, 0);
        }


    }
    private void Update()
    {
        isgrounded = Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundLayer);
    }
}
