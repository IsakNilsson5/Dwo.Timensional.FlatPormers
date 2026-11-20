using UnityEngine;

public class Camerathing : MonoBehaviour
{
    [SerializeField] Transform moverTransform;
    [SerializeField] Vector3 Offset;
    [SerializeField] float cammovsped = 4;
    [SerializeField] JAYYOUGOTTAMOVE player;

    private void Start()
    {
        moverTransform = FindAnyObjectByType<JAYYOUGOTTAMOVE>().transform;
        Offset = transform.position - moverTransform.position;
    }

    private void FixedUpdate()
    {
        if (player.isGrounded)
        {
            transform.position = moverTransform.position + Offset;
        }
        else if (player.isGrounded2)
        { 
           transform.position = Vector3.Lerp(transform.position, moverTransform.position + Offset, cammovsped * Time.fixedDeltaTime);
        }
        else
         {
           transform.position = new Vector3(moverTransform.position.x, transform.position.y, transform.position.z);
         }
        
    }
}



