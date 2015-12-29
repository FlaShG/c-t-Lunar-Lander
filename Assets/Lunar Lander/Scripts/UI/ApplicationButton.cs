using UnityEngine;
#if UNITY_5_3
using UnityEngine.SceneManagement;
#endif

public class ApplicationButton : MonoBehaviour
{
    public void LoadLevel(string level)
    {
        if(level == "")
        {
            //Wird ein leerer String übergeben, soll das aktuelle Level geladen werden
#if UNITY_5_3
            level = SceneManager.GetActiveScene().name;
#else
            level = Application.loadedLevelName;
#endif
        }
#if UNITY_5_3
        SceneManager.LoadScene(level);
#else
        Application.LoadLevel(level);
#endif

        
        //Wenn wir aus einem Pause-Menü kommen, soll die Zeit nicht mehr angehalten sein,
        //sobald die Szene gewechselt wird.
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
