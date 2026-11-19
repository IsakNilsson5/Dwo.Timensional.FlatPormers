using UnityEngine;

public class GIMMEMONEY : MonoBehaviour
{
    [SerializeField] GameObject moneyprefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(moneyprefab, (transform.position + new Vector3(0, 2.5f, 0)), Quaternion.identity);
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocityY = 0;

        }
    }
}
