using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/**
 * Dieses Skript ließe sich mit StateMachineBehaviours vermutlich eleganter lösen.
 * Es soll allerdings die Möglichkeiten mit Coroutinen und die Benutzung des Animators verdeutlichen.
 *
 * Eingebaut ist hier eine nicht explizite StateMachine, die abwechselnd in den States "Idle" und "RunSomewhere" ist.
**/
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class AlienBehaviour : MonoBehaviour
{
    private static List<AlienBehaviour> allAliens = new List<AlienBehaviour>();

    private Rigidbody2D rb;
    private Animator animator;
    private static int paramSpeed;
    private static int paramCheer;
    private Transform body;
    private List<Func<IEnumerator>> states;

    public float speed = 10;
    private float currentDirection = 0;
    

    void Awake()
    {
        allAliens.Add(this);

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        paramSpeed = Animator.StringToHash("Speed");
        paramCheer = Animator.StringToHash("Cheer");

        body = transform.Find("Body");

        states = new List<Func<IEnumerator>>();
        states.Add(Idle);
        states.Add(RunSomewhere);
    }

    void OnDestroy()
    {
        allAliens.Remove(this);
    }

    //Einige Unity-Events, wie Start, können Coroutinen sein
    IEnumerator Start()
    {
        int stateIndex = 0;
        while(enabled)
        {
            yield return StartCoroutine(states[stateIndex].Invoke());
            if(++stateIndex >= states.Count)
            {
                stateIndex = 0;
            }
        }
	}

    void FixedUpdate()
    {
        var v = rb.velocity;
        v.x = currentDirection * speed;
        rb.velocity = v;
    }

    //Idle ist quasi ein State
    private IEnumerator Idle()
	{
        currentDirection = 0;
        animator.SetFloat(paramSpeed, 0);

        yield return new WaitForSeconds(UnityEngine.Random.Range(1f,3f));
    }

    //Auch RunSomewhere ist ein State
    private IEnumerator RunSomewhere()
    {
        currentDirection = (UnityEngine.Random.value > 0.5f) ? -1 : 1;
        animator.SetFloat(paramSpeed, Mathf.Abs(currentDirection));
        body.localScale = new Vector3((currentDirection > 0) ? 1 : -1, 1, 1);

        yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 3f));
    }

    public static void AllAliensCheer()
    {
        foreach(var alien in allAliens)
        {
            alien.currentDirection = 0; //Stehen bleiben
            alien.StopAllCoroutines(); //Diese State Machine deaktivieren
            alien.animator.SetTrigger(paramCheer); //Der Animator-State Machine den Befehl zum Jubeln geben
        }
    }
}
