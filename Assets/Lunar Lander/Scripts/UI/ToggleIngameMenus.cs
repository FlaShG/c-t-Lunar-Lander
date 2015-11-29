using UnityEngine;
using System.Collections.Generic;

public class ToggleIngameMenus : MonoBehaviour
{
    private static ToggleIngameMenus instance;

    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject gameOverMenu;

    //Liste von AudioSources, die auf "mute" gestellt werden sollen, wenn ein Menü aktiv ist
    private static List<AudioSource> audioToDeactivateInMenus = new List<AudioSource>();

    //wird noch früher als Awake aufgerufen, aber nur beim Levelwechsel
    void OnLevelWasLoaded()
    {
        audioToDeactivateInMenus.Clear();
    }

    void Awake()
    {
        instance = this;

        //Zu Anfang des Spiels deaktiviert sich die Menüs
        //Das GameObject kann auch im Editor schon deaktiviert sein, aber falls es beim Editieren
        //aktiviert bleibt...
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        if(gameOverMenu.activeSelf) return; //Wenn Game Over aktiv ist, nicht das Pause-Menü öffnen

        //GameObject an schalten, wenn aus, und umgekehrt
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        //Pausiert die Welt wenn der Canvas aktiv wird
        Time.timeScale = pauseMenu.activeSelf ? 0 : 1;
        //Ton bestimmer Soundquellen an oder aus schalten
        SetAudioSourcesActive(!pauseMenu.activeSelf);
    }

    public static void GameOver()
    {
        Time.timeScale = 0;
        instance.gameOverMenu.SetActive(true);
        SetAudioSourcesActive(false);
    }

    public static void AddAudioSourceForDeactivation(AudioSource audio)
    {
        audioToDeactivateInMenus.Add(audio);
    }

    private static void SetAudioSourcesActive(bool on)
    {
        foreach(var audio in audioToDeactivateInMenus)
        {
            audio.mute = !on;
        }
    }
}
