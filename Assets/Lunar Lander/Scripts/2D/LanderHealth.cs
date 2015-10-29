using UnityEngine;
using System.Collections;

public class LanderHealth : MonoBehaviour
{
    private SpriteRenderer sr;

    public int lives = 3;
    public float invincibleTimeAfterCrash = 2;
    private bool invincible = false;


    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Crash()
    {
        if(invincible) return;

        print("crashed!");

        lives--;
        if(lives == 0)
        {
            Death();
        }
        else
        {
            StartCoroutine(Invincibility());
        }
    }

    private IEnumerator Invincibility()
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

    public void Death()
    {

    }
}
