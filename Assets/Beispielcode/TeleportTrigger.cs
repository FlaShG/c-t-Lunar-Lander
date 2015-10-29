using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public Transform teleportTarget;

    void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = teleportTarget.position;
    }
}
