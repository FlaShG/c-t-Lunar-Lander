#pragma warning disable 0108

using UnityEngine;

///<summary>
/// Da OnCollisionEnter (die 3D-Version) im Gegensatz zu OnCollisionEnter2D nicht auf dem GameObject
/// mit den betroffenen Collidern ausgelöst wird (obwohl die Scripting Reference etwas anderes behauptet),
/// liegt dieses Skript auf dem Rigidbody und fragt ab, ob die Collider die empfindlichen waren.
/// </summary>
public class LanderCollisions3D : MonoBehaviour
{
    [SerializeField]
    private GameObject damageablePart;
    private LanderHealth landerHealth;
    private AudioSource audio;
    

    void Awake()
    {
        landerHealth = GetComponent<LanderHealth>();
        audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach(var contact in collision.contacts)
        {
            if(contact.thisCollider.gameObject == damageablePart)
            {
                if(!landerHealth.isInvincible)
                {
                    landerHealth.Crash();
                    audio.Play();
                }
            }
        }
    }
}
