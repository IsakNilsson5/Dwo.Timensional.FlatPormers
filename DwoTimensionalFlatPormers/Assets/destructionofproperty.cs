using UnityEngine;

public class destructionofproperty : MonoBehaviour
{
    [SerializeField] GameObject nuclearparticle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Instantiate(nuclearparticle, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocityY = 0;
            Destroy(gameObject);
        }
    }
}
