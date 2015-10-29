#pragma warning disable 108
using UnityEngine;

/// <summary>
/// Dieses Skript setzt die Lautstärke einer Soundquelle in Abhängigkeit der Geschwindigkeit des Objekts.
/// Wird z.B. benutzt, um das Windgeräusch der Kamera zu beeinflussen.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class SoundVolumeBySpeed : MonoBehaviour
{
    private AudioSource audio;
    private Vector3 lastPosition;

    [Tooltip("This is the minimum speed for the sound to hear at all.")]
    public float minSpeed = 5;
    [Tooltip("This is the speed at which the sound volume is the loudest.")]
    public float fullSpeed = 20;
    [Tooltip("Higher values mean faster changes in volume.")]
    public float smoothingPower = 5;


    void Awake()
    {
        audio = GetComponent<AudioSource>();
        lastPosition = transform.position;

        audio.volume = 0;
    }

    void Update()
    {
        var speed = Vector3.Distance(lastPosition, transform.position) / Time.deltaTime;

        var targetVolume = (speed - minSpeed) / (fullSpeed - minSpeed);
        audio.volume = Mathf.MoveTowards(audio.volume, targetVolume, Time.deltaTime * smoothingPower);

        lastPosition = transform.position;
    }
}
