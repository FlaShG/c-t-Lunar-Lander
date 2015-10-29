using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    void Start()
    {
        var rb = GetComponentInParent<Rigidbody2D>();
        rb.centerOfMass = transform.localPosition;
    }
}
