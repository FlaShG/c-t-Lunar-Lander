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
        fullParticleEmissionRate = ps.emissionRate;

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
        ps.enableEmission = on;
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
            ps.enableEmission = true;
            ps.emissionRate = fullParticleEmissionRate * a;

            targetLightIntensity = fullLightIntensity * a;
            if(audio)
            {
                audio.volume = fullVolume * a;
            }
        }
        else
        {
            ps.enableEmission = false;
            ps.emissionRate = fullParticleEmissionRate;

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
}
