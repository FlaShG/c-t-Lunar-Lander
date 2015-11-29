using UnityEngine;

/// <summary>
/// Abstrakte Superklasse für die Unverwundbarkeits, die aktiv ist, wenn man ein Leben verliert.
/// Außerdem wird sich hier um den Flacker-Effekt kümmert, der die Unverwundbarkeit signalisiert.
/// </summary>
public abstract class LanderInvincibility : MonoBehaviour
{
    public float invincibleTimeAfterCrash = 2;
    public bool invincible { protected set; get; }

    public abstract void Play();
}
