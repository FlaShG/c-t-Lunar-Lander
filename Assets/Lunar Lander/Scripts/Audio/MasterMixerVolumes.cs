using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class MasterMixerVolumes : MonoBehaviour
{
    public AudioMixer mixer;
    public string parameter;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Start()
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

    public void SetVolume(float volume)
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
