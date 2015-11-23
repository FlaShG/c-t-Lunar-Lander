using UnityEngine;

public class ToggleIngameMenus : MonoBehaviour
{
    private static ToggleIngameMenus instance;

    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject gameOverMenu;

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
    }

    public static void GameOver()
    {
        Time.timeScale = 0;
        instance.gameOverMenu.SetActive(true);
    }
}
