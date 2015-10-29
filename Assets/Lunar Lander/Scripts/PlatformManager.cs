using UnityEngine;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour
{
    //Dies ist ein etwas fortgeschritteneres Muster, das sicherstellt, dass es in jeder Szene immer einen
    //neuen PlatformManager gibt.
    //Der vorhandene PlatformManager wird beim Szenenwechsel gelöscht - die folgenden Zeilen sorgen dafür,
    //dass sofort ein neuer erstellt wird, wenn er gebraucht wird.
    private static PlatformManager _instance;
    private static PlatformManager instance
    {
        get
        {
            if(!_instance)
            {
                var go = new GameObject("Platform Manager");
                _instance = go.AddComponent<PlatformManager>();
                go.hideFlags = HideFlags.HideAndDontSave;
            }
            return _instance;
        }
    }

    private int missingplatformCount = 0;

    public static void AddPlatform(Platform p)
    {
        ++instance.missingplatformCount;
    }

    public static void PlatformActivated(Platform p)
    {
        --instance.missingplatformCount;

        if(instance.missingplatformCount == 0)
        {
            Debug.Log("Level Done!");
        }
    }
}
