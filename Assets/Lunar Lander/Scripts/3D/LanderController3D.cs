using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LanderController3D : MonoBehaviour
{
    private Rigidbody rb;

    public Transform cameraPivot;

    public float upwardsPower;
    public float rotatePower;

    [SerializeField]
    private ExhaustEffect exhaustParticlesMain;
    [SerializeField]
    private ExhaustEffect exhaustParticlesFront;
    [SerializeField]
    private ExhaustEffect exhaustParticlesBack;
    [SerializeField]
    private ExhaustEffect exhaustParticlesLeft;
    [SerializeField]
    private ExhaustEffect exhaustParticlesRight;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        exhaustParticlesMain.SetActive(false);
        exhaustParticlesFront.SetActive(false);
        exhaustParticlesBack.SetActive(false);
        exhaustParticlesLeft.SetActive(false);
        exhaustParticlesRight.SetActive(false);
    }

    void FixedUpdate()
    {
        var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        if(Input.GetButton("Accelerate"))
        {
            rb.AddRelativeForce(Vector3.up * upwardsPower);
            exhaustParticlesMain.SetActive(true);
        }
        else
        {
            exhaustParticlesMain.SetActive(false);
        }

        var transformedInput = cameraPivot.right * input.y
                             + cameraPivot.forward * -input.x;
        rb.AddTorque(transformedInput * rotatePower);

        //Ein anderer Vektor für die Partikelsysteme.
        transformedInput = cameraPivot.right * input.x
                         + cameraPivot.forward * input.y;
        transformedInput = transform.InverseTransformDirection(transformedInput);

        exhaustParticlesFront.SetAmount(-transformedInput.z);
        exhaustParticlesBack.SetAmount(transformedInput.z);
        exhaustParticlesLeft.SetAmount(transformedInput.x);
        exhaustParticlesRight.SetAmount(-transformedInput.x);
    }
}
