using UnityEngine;
using System.Collections;

public class AABBBugWarner : MonoBehaviour
{
	void Start()
    {
#if UNITY_5_3_1
        Debug.LogWarning("Sollten Sie eine Menge Fehlermeldungen und schlechte Performance bemerken, laden Sie sich bitte das Update 5.3.1p1 herunter:" + "http://unity3d.com/unity/qa/patch-releases" + "\nFalls nicht, können Sie dieses GameObject gerne löschen.", gameObject);
#endif
    }
}
