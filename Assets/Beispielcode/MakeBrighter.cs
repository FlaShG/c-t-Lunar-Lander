using UnityEngine;

public class MakeBrighter : MonoBehaviour
{
    void Update()
    {
        var r = GetComponent<SpriteRenderer>();
        r.color += Color.white * Time.deltaTime;
    }
}
