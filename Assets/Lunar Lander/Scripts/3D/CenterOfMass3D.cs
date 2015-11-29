using UnityEngine;

public class CenterOfMass3D : MonoBehaviour
{
    void Start()
    {
        var rb = GetComponentInParent<Rigidbody>();
        rb.centerOfMass = transform.localPosition;
    }
}
