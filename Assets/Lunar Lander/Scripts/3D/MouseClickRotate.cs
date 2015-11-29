using UnityEngine;

/// <summary>
/// Dreht das Objekt in Abhängigkeit der Mausbewegung um die vertikale Achse, wenn die linke Maustaste gedrückt gehalten wird.
/// </summary>
public class MouseClickRotate : MonoBehaviour
{
    public float speed = 2;
    private KeepGlobalRotation kgr;


    void Awake()
    {
        kgr = GetComponent<KeepGlobalRotation>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            var rotation = new Vector3(0, Input.GetAxis("Mouse X") * speed, 0);
            if(!kgr)
            {
                transform.Rotate(rotation);
            }
            else
            {
                kgr.rotation = Quaternion.Euler(rotation) * kgr.rotation;
            }
        }
    }
}
