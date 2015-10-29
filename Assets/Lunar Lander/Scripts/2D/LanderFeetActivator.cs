using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Sendet Aktivierungs-Events an alles, auf dem der Lander mit beiden Füßen steht.
/// </summary>
public class LanderFeetActivator : MonoBehaviour
{
    //Alle berührten Collider des aktuellen FixedUpdate-Frames.
    //Der boolean-Wert ist true, wenn der Collider mit beiden Füßen berührt wird.
    private Dictionary<Collider2D, bool> touched = new Dictionary<Collider2D, bool>();

    void OnCollisionStay2D(Collision2D collision)
    {
        var c = collision.collider;

        if(!touched.ContainsKey(c))
        {
            touched.Add(c, false);
        }
        else
        {
            touched[c] = true;
        }
    }

    void FixedUpdate()
    {
        foreach(var c in touched.Keys)
        {
            if(touched[c])
            {
                c.SendMessage("OnLanderStand", SendMessageOptions.DontRequireReceiver);
            }
        }

        touched.Clear();
    }
}
