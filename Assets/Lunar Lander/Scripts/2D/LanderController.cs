using UnityEngine;

//Dieses Skript funktioniert nur auf einem GameObject, das einen Rigidbody2D hat.
[RequireComponent(typeof(Rigidbody2D))]
public class LanderController : MonoBehaviour
{
    //Für die Referenz auf die Rigidbody2D-Komponente
    private Rigidbody2D rb;

    //Die Variablen, die ein Gamedesigner im Editor einstellen kann, um das Gameplay
    //zu beeinflussen. Entscheidend ist hierbei die Sichtbarkeit "public".
    public float upwardsPower;
    public float rotatePower;

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
        SetEmission(exhaustParticles, false);
        SetEmission(turnClockwiseParticles, false);
        SetEmission(turnCounterclockwiseParticles, false);
    }

    //FixedUpdate wird in jedem Fixed Update Step ausgeführt.
    //In FixedUpdate werden physikbezogene Aktionen, wie die Ausübung von Kraft auf Rigidbodys, eingebaut.
    //Nach Möglichkeit auch andere, für das Gameplay relevante Dinge.
    void FixedUpdate()
    {
        if(LanderInput2D.acceleration)
        {
            rb.AddRelativeForce(Vector2.up * upwardsPower);
            SetEmission(exhaustParticles, true);
        }
        else
        {
            SetEmission(exhaustParticles, false);
        }

        var rotationInput = -LanderInput2D.horizontal;
        rb.AddTorque(rotationInput * rotatePower);

        SetEmission(turnClockwiseParticles, rotationInput > 0.2f);
        SetEmission(turnCounterclockwiseParticles, rotationInput < -0.2f);
    }

    private static void SetEmission(ParticleSystem ps, bool enable)
    {
#if UNITY_5_3
        var emission = ps.emission;
        emission.enabled = enable;
#else
        ps.enableEmission = enable;
#endif
    }
}

