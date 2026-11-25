using UnityEngine;

public class GIMMEMONEY : MonoBehaviour
{
    [SerializeField] GameObject moneyprefab;
    [SerializeField] bool moneypriviledge = true;
    [SerializeField] GameObject powerupprefab;
    [SerializeField] Sprite nomonies;
    int luck;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && moneypriviledge)
        {
            
            luck = Random.Range(1, 11);
            if (luck <= 6)
            {
                Instantiate(moneyprefab, (transform.position + new Vector3(0, 2.5f, 0)), Quaternion.identity);
            }
            else if (luck > 6)
            {
                Instantiate(powerupprefab, (transform.position + new Vector3(0, 2.5f, 0)), Quaternion.identity);
            }
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocityY = 0;
            moneypriviledge = false;
            GetComponent<SpriteRenderer>().sprite = nomonies;


        }
    }
}
