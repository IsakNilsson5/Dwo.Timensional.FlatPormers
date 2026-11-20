using UnityEngine;

public class evilahhscript : MonoBehaviour
{
    [SerializeField] Rigidbody2D evilorgans;
    [SerializeField] float evilrunspeed;
    [SerializeField] Transform evilturn;
    [SerializeField] LayerMask groundcheck;
    [SerializeField] bool isgrounded;
    private void Start()
    {
        evilorgans = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        evilorgans.linearVelocity = new Vector2(evilrunspeed, evilorgans.linearVelocity.y);

        if (!isgrounded)
        {
            evilturn.rotation = Quaternion.Euler(0, 180, 0);
        }


    }
    private void Update()
    {
        isgrounded = Physics2D.OverlapCircle(evilturn.position, 0.1f, groundcheck);
    }
}
