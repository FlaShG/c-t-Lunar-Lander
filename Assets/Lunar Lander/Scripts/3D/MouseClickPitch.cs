using UnityEngine;

/// <summary>
/// Neigt das Objekt in Abhängigkeit der Mausbewegung, wenn die linke Maustaste gedrückt gehalten wird.
/// </summary>
public class MouseClickPitch : MonoBehaviour
{
    public float speed = 2;
    [Tooltip("The lowest angle. Positive values mean above the relative ground.")]
    public float minAngle = 10;
    [Tooltip("The highest angle. Positive values mean above the relative ground.")]
    public float maxAngle = 60;


    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            var euler = transform.localEulerAngles;
            euler.x -= Input.GetAxis("Mouse Y") * speed;

            euler.x = Mathf.Repeat(euler.x, 360);
            if(euler.x >= 180)
            {
                euler.x -= 360;
            }

            var min = minAngle;
            var max = maxAngle;
            if(min < 0 || max < 0)
            {
                min += 360;
                max += 360;
                euler.x += 360;
            }

            euler.x = Mathf.Clamp(euler.x, min, max);

            transform.localEulerAngles = euler;
        }
    }
}
