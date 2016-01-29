using UnityEngine;

public class MobileInput2D : LanderInput2D
{
    private bool left;
    private bool right;
    protected override float horizontalValue
    {
        get
        {
            return (left ? -1 : 0) + (right ? 1 : 0);
        }
    }
    private bool _acceleration;
    protected override bool accelerationValue { get { return _acceleration; } }

    public void SetLeft(bool on)
    {
        left = on;
    }

    public void SetRight(bool on)
    {
        right = on;
    }

    public void SetAcceleration(bool on)
    {
        _acceleration = on;
    }

    void Start()
    {
        if(!Application.isMobilePlatform)
        {
            Destroy(gameObject);
        }
    }
}
