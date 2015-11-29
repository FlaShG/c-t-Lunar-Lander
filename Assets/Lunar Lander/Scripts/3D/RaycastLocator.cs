using UnityEngine;

/// <summary>
/// Diese Komponente ist ein Besipiel für die Verwendung von Raycasts und Spherecasts.
/// Vom übergeordneten Objekt wird in jedem Frame ein Raycast geschossen - in die angegebene Richtung.
/// Wo der Strahl auftrifft wird dieses Objekt platziert.
/// </summary>
public class RaycastLocator : MonoBehaviour
{
    private Transform parent;

    public bool relativeRotation;
    public Vector3 offset;
    public Vector3 direction = Vector3.forward;
    public float maxDistance = Mathf.Infinity;
    [Range(0,10)]
    public float castRadius = 0;
    [SerializeField]
    private LayerMask layerMask;


    void Awake()
    {
        parent = transform.parent;
    }

    void LateUpdate()
    {
        var dir = direction;
        if(relativeRotation)
        {
            dir = parent.TransformDirection(dir);
        }
        var ray = new Ray(parent.position + offset, dir);
        RaycastHit hit;

        var dist = maxDistance;

        if(Cast(ray, out hit))
        {
            dist = hit.distance;
        }
        
        transform.position = ray.origin + ray.direction * dist;
    }

    private bool Cast(Ray ray, out RaycastHit hit)
    {
        if(castRadius == 0)
        {
            return Physics.Raycast(ray, out hit, maxDistance, layerMask);
        }
        else
        {
            return Physics.SphereCast(ray, castRadius, out hit, maxDistance, layerMask);
        }
    }
}
