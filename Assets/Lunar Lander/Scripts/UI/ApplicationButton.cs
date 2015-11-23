using UnityEngine;
using System.Collections;

public class ApplicationButton : MonoBehaviour
{
    public void LoadLevel(string level)
    {
        if(level == "")
        {
            //Wird ein leerer String übergeben, soll das aktuelle Level geladen werden
            level = Application.loadedLevelName;
        }
        Application.LoadLevel(level);
        
        //Wenn wir aus einem Pause-Menü kommen, soll die Zeit nicht mehr angehalten sein,
        //sobald die Szene gewechselt wird.
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
