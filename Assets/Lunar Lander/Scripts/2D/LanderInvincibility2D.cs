using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class LanderInvincibility2D : LanderInvincibility
{
    private SpriteRenderer sr;

    void Awake()
	{
        sr = GetComponent<SpriteRenderer>();
    }

    public override void Play()
    {
        StartCoroutine(PlayEffect());
    }

    private IEnumerator PlayEffect()
    {
        invincible = true;

        float elapsedTime = 0;
        var color = sr.color;
        while(elapsedTime < invincibleTimeAfterCrash)
        {
            color.a = Mathf.Cos(elapsedTime * 80) + 1 * 0.5f;
            sr.color = color;

            yield return null;

            elapsedTime += Time.deltaTime;
        }

        sr.color = Color.white;
        invincible = false;
    }
}
