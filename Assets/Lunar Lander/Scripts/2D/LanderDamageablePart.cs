using UnityEngine;

public class LanderDamageablePart : MonoBehaviour
{
    private LanderHealth landerHealth;
    

    void Awake()
    {
        landerHealth = GetComponentInParent<LanderHealth>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        landerHealth.Crash();
    }
}
