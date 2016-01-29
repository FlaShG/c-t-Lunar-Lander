using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR;

[RequireComponent(typeof(Canvas))]
public class RepositionCanvasForVR : MonoBehaviour
{
    void Start()
    {
        if(VRDevice.isPresent)
        {
            var canvas = GetComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;

            var camera = Camera.main;
            var height = camera.orthographicSize * 2;

            var rect = canvas.transform as RectTransform;
            rect.anchoredPosition3D = camera.transform.position + Vector3.forward * 20;
            var scale = height / rect.rect.height;
            rect.localScale = new Vector3(scale, scale, 1);

            var scaler = GetComponent<CanvasScaler>();
            Destroy(scaler);
        }
    }
}
