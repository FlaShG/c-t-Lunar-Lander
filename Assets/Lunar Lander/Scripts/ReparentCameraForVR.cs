using UnityEngine;
using UnityEngine.VR;

public class ReparentCameraForVR : MonoBehaviour
{
    [SerializeField]
    private LanderController3D landerController;

    void Start()
    {
        if(VRDevice.isPresent)
        {
            var ct = Camera.main.transform;
            ct.parent = transform;
            ct.localPosition = Vector3.zero;

            var cameraPivot = new GameObject("Backup Camera Pivot");
            cameraPivot.transform.parent = transform;
            var fyr = cameraPivot.AddComponent<FollowYRotation>();
            fyr.target = ct;

            landerController.cameraPivot = cameraPivot.transform;
        }
    }
}
