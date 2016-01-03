using UnityEngine;

public class Platform : MonoBehaviour
{
    private const float activationTime = 4;
    private Color defaultColor;
    private static readonly Color activatedColor = new Color(0.1f,1,0.1f,1);

    private SpriteRenderer sr;
    private bool landerJustStoodOnMe;
    private float standTime = 0;
    private bool activated { get { return standTime >= activationTime; } }

    [SerializeField]
    private ParticleSystem activatedEffect;


    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        defaultColor = sr.color;
    }

    void Start()
    {
        PlatformManager.AddPlatform(this);
    }

    void OnDestroy()
    {
        PlatformManager.RemovePlatform(this);
    }

    void OnLanderStand()
    {
        landerJustStoodOnMe = true;
    }

    void FixedUpdate()
    {
        if(activated) return;

        if(landerJustStoodOnMe)
        {
            standTime += Time.deltaTime;
            if(standTime >= activationTime)
            {
                Activated();
            }
            landerJustStoodOnMe = false;
        }
        else
        {
            standTime -= Time.deltaTime;
            if(standTime < 0)
            {
                standTime = 0;
            }
        }

        sr.color = Color.Lerp(defaultColor, activatedColor, standTime / activationTime);
    }

    private void Activated()
    {
        PlatformManager.PlatformActivated(this);
        activatedEffect.Play();
    }
}
