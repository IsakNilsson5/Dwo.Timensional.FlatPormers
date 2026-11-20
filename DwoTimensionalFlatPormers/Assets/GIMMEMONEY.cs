using UnityEditor.XR;
using UnityEngine;

public class GIMMEMONEY : MonoBehaviour
{
    [SerializeField] GameObject moneyprefab;
    [SerializeField] bool moneypriviledge = true;
    [SerializeField] Sprite nomonies;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && moneypriviledge)
        {
            Instantiate(moneyprefab, (transform.position + new Vector3(0, 2.5f, 0)), Quaternion.identity);
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocityY = 0;
            moneypriviledge = false;
            GetComponent<SpriteRenderer>().sprite = nomonies;


        }
    }
}
