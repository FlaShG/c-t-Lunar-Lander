using UnityEngine;

/// <summary>
/// Dieses Skript setzt am Ende jeder Update-Phase die Rotation eines Objekts auf Anfang zurück.
/// Die Zielrotation kann allerdings durch andere Skripts verändert werden.
/// </summary>
public class KeepGlobalRotation : MonoBehaviour
{
    //Diese Variable soll public sein, aber nicht im Editor eingestellt oder serialisiert werden.
    [System.NonSerialized]
    public Quaternion rotation;

    void Start()
    {
        rotation = transform.rotation;
    }

    void LateUpdate()
    {
        transform.rotation = rotation;
    }
}
