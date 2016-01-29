using UnityEngine;
using System.Collections;

public class FollowYRotation : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if(!target) return;

        transform.localEulerAngles = new Vector3(0, target.localEulerAngles.y, 0);
    }
}
