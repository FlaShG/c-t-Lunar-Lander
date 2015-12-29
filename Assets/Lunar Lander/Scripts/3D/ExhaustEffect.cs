#pragma warning disable 108
using UnityEngine;

[RequireComponent(typeof(Light))]
public class ExhaustEffect : MonoBehaviour
{
    private Light light;
    private ParticleSystem ps;
    private AudioSource audio;

    private float fullParticleEmissionRate;

    private float fullLightIntensity;
    private float targetLightIntensity;

    private float fullVolume;


    void Awake()
    {
        light = GetComponent<Light>();
        ps = GetComponentInChildren<ParticleSystem>();
        audio = GetComponent<AudioSource>();

        fullLightIntensity = light.intensity;
#if UNITY_5_3
        fullParticleEmissionRate = ps.emission.rate.constantMax;
#else
        fullParticleEmissionRate = ps.emissionRate;
#endif

        if(audio)
        {
            fullVolume = audio.volume;
            ToggleIngameMenus.AddAudioSourceForDeactivation(audio);
        }
    }

    void Start()
    {
        SetActive(false);
    }

    public void SetActive(bool on)
    {
        SetEmission(ps, on ? fullParticleEmissionRate : 0);
        targetLightIntensity = on ? fullLightIntensity : 0;
        if(audio)
        {
            audio.volume = on ? fullVolume : 0;
        }
    }

    public void SetAmount(float a)
    {
        if(a > 0)
        {
            SetEmission(ps, fullParticleEmissionRate * a);

            targetLightIntensity = fullLightIntensity * a;
            if(audio)
            {
                audio.volume = fullVolume * a;
            }
        }
        else
        {
            SetEmission(ps, 0);

            targetLightIntensity = 0;
            if(audio)
            {
                audio.volume = 0;
            }
        }
    }

    void Update()
    {
        light.intensity = Mathf.Lerp(light.intensity, targetLightIntensity, Time.deltaTime * 15);
    }

    private static void SetEmission(ParticleSystem ps, float amount)
    {
#if UNITY_5_3
        var emission = ps.emission;
        emission.enabled = amount > 0;
        emission.rate = new ParticleSystem.MinMaxCurve(amount);
#else
        ps.enableEmission = amount > 0;
        ps.emissionRate = amount;
#endif
    }
}
