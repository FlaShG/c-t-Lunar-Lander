using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;
    private AudioSource source;

    [SerializeField]
    private AudioClip startMusic;

    void Awake()
    {
        if(instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            source = GetComponent<AudioSource>();
            source.loop = true;
            source.spatialBlend = 0;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        if(startMusic)
        {
            PlayMusic(startMusic);
        }
    }

    public static void PlayMusic(AudioClip clip)
    {
        instance.source.Stop();
        instance.source.clip = clip;
        instance.source.Play();
    }
}
