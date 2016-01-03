using UnityEngine;

public abstract class LanderInput2D : MonoBehaviour
{
    private static LanderInput2D instance;

    void Awake()
    {
        instance = this;
    }

    protected abstract float horizontalValue { get; }
    protected abstract bool accelerationValue { get; }

    public static float horizontal
    {
        get
        {
            if(instance)
            {
                return instance.horizontalValue;
            }
            return Input.GetAxis("Horizontal");
        }
    }

    public static bool acceleration
    {
        get
        {
            if(instance)
            {
                return instance.accelerationValue;
            }
            return Input.GetButton("Accelerate");
        }
    }
}
