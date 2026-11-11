using Unity.VisualScripting;
using UnityEngine;

public class Dollar : MonoBehaviour
{
    [SerializeField] int moneyValue = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moneyValue = moneyValue + 1;
            Destroy(gameObject);
        }
    }
}
