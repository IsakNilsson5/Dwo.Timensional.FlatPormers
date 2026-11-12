using Unity.VisualScripting;
using UnityEngine;

public class Dollar : MonoBehaviour
{
    GameManager gameManager;


    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.Scoresuh(1);
            Destroy(gameObject);
        }
    }
}
