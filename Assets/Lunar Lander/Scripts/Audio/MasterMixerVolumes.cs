using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class MasterMixerVolumes : MonoBehaviour
{
    public AudioMixer mixer;
    public string[] parameters;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Start()
    {
        foreach(var parameter in parameters)
        {
            float volume;
            if(mixer.GetFloat(parameter, out volume))
            {
                slider.value = volume;
            }
            else
            {
                Debug.LogError("Mixer Parameter " + parameter + " not set up.");
            }
        }
    }

    public void SetVolume(float volume)
    {
        foreach(var parameter in parameters)
        {
            if(volume > slider.minValue)
            {
                mixer.SetFloat(parameter, volume);
            }
            else
            {
                mixer.SetFloat(parameter, -80);
            }
        }
	}
}
