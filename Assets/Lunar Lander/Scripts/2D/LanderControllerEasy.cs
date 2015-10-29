using UnityEngine;

//Dieses Skript funktioniert nur auf einem GameObject, das einen Rigidbody2D hat.
[RequireComponent(typeof(Rigidbody2D))]
public class LanderControllerEasy : MonoBehaviour
{
    //Für die Referenz auf die Rigidbody2D-Komponente
    private Rigidbody2D rb;

    //Die Variablen, die ein Gamedesigner im Editor einstellen kann, um das Gameplay
    //zu beeinflussen. Entscheidend ist hierbei die Sichtbarkeit "public".
    public float upwardsPower;
    public float rotatePower;
    public float maxAngle = 40;

    //SerializeField erlaubt das Serialisieren und Einstellen des Wertes im Editor,
    //wann immer public keine gute Option ist.
    [SerializeField]
    private ParticleSystem exhaustParticles;
    [SerializeField]
    private ParticleSystem turnClockwiseParticles;
    [SerializeField]
    private ParticleSystem turnCounterclockwiseParticles;

    //In Awake werden Komponenten und andere GameObjects gefunden, die für die weitere
    //Funktionsweise des Skripts gebraucht werden.
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Erste Logik des Spiels wird in Start implementiert.
    void Start()
    {
        exhaustParticles.enableEmission = false;
        turnClockwiseParticles.enableEmission = false;
        turnCounterclockwiseParticles.enableEmission = false;
    }

    //InFixedUpdate werden physikbezogene Aktionen ausgeführt.
    //Nach Möglichkeit auch andere, für das Gameplay relevante Dinge.
    void FixedUpdate()
    {
        if(Input.GetButton("Accelerate"))
        {
            rb.AddRelativeForce(Vector2.up * upwardsPower);
            exhaustParticles.enableEmission = true;
        }
        else
        {
            exhaustParticles.enableEmission = false;
        }

        var rotationInput = -Input.GetAxis("Horizontal");
        var targetAngle = rotationInput * maxAngle;
        var currentAngle = Mathf.MoveTowards(rb.rotation, targetAngle, rotatePower * Time.deltaTime);

        rb.MoveRotation(currentAngle);

        turnClockwiseParticles.enableEmission = rotationInput > 0.2f;
        turnCounterclockwiseParticles.enableEmission = rotationInput < -0.2f;
    }
}