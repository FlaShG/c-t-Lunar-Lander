using UnityEngine;
using System.Collections;

public class SpriteOrderOffset : MonoBehaviour
{
    public int offset = 0;

	void Start()
	{
        var renderers = GetComponentsInChildren<SpriteRenderer>();
	    foreach(var r in renderers)
        {
            r.sortingOrder += offset;
        }

        Destroy(this);
	}
}
