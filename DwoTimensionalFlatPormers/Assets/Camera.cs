using UnityEditor.Tilemaps;
using UnityEngine;

public class Camerathing : MonoBehaviour
{
    Transform moverTransform;
    [SerializeField] Vector3 Offset;

    private void Start()
    {
        moverTransform = FindAnyObjectByType<JAYYOUGOTTAMOVE>().transform;
        Offset = transform.position - moverTransform.position;
    }

    private void FixedUpdate()
    {
        transform.position = moverTransform.position + Offset;
    }
}



