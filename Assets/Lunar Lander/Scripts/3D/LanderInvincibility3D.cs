using UnityEngine;
using System.Collections;

/// <summary>
/// Die 3D-Version der Klasse, die sich um Unverwundbarkeit und den dazugehörigen visuellen Effekt kümmert.
/// </summary>
public class LanderInvincibility3D : LanderInvincibility
{
    [SerializeField]
    private Renderer landerRenderer;
    private Material m;
    private Color startColor;

    void Awake()
	{
        m = landerRenderer.material;
        startColor = m.color;
    }

    public override void Play()
    {
        StartCoroutine(PlayEffect());
    }

    private IEnumerator PlayEffect()
    {
        invincible = true;

        float elapsedTime = 0;
        while(elapsedTime < invincibleTimeAfterCrash)
        {
            m.color = Color.Lerp(startColor, Color.white, Mathf.Cos(elapsedTime * 80) + 1 * 0.5f);

            yield return null;

            elapsedTime += Time.deltaTime;
        }

        m.color = startColor;
        invincible = false;
    }
}
