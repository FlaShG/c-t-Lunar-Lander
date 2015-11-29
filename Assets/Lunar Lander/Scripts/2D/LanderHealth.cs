using UnityEngine;
using System.Collections;

public class LanderHealth : MonoBehaviour
{
    private LanderInvincibility invincibility;

    public int lives = 3;
    public bool isInvincible
    {
        get
        {
            return invincibility.invincible;
        }
    }


    void Awake()
    {
        invincibility = GetComponent<LanderInvincibility>();
    }

    void Start()
    {
        LifeCounter.UpdateCounter(lives);
    }

    public void Crash()
    {
        if(invincibility.invincible || lives <= 0) return;
        
        lives--;
        LifeCounter.UpdateCounter(lives);
        if(lives == 0)
        {
            Death();
        }
        else
        {
            invincibility.Play();
        }
    }

    public void Death()
    {
        ToggleIngameMenus.GameOver();
    }
}
