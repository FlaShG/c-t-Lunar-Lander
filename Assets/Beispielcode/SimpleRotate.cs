using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    [Tooltip("The speed at which the object will rotate, in degrees per second.")]
    public float speed = 20;

    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
