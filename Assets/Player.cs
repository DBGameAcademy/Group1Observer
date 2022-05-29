using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Player : MonoBehaviour
{
    //[SerializeField] UnityEvent OnRagemode;
    public static Action OnRampageModeAction;
    public static Action OnRampageModeActionEnd;

    public int maxHealth = 100;
    public int currentHealth;

    enum eStates
    {
        normal,
        rage
    }

    eStates state { get; set; }

    // nell' uml non ci sono, ma potreste mettere 2 stati anche qui
    private void Start()
    {
        maxHealth = currentHealth;
        GameController.RegisterPlayer(this);
        state = eStates.normal;
    }

    private void Update()
    {
        Debug.Log("Current Health: " + currentHealth);

        switch (state)
        {
            case eStates.normal:
                RageMode();

                break;

            case eStates.rage:
                break;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal();
        }
    }

    public Vector2 GetPos()
    {
        return transform.position;
    }

    public void GetDamage(int _damage)
    {
        if (currentHealth <= 0)
        {
            return;
        }
        else
        {
            currentHealth -= _damage;
        }
    }

    void RageMode()
    {
        if (currentHealth < 10)
        {
            state = eStates.rage;
            NotifyRageMode();
        }
    }

    void Heal()
    {
        currentHealth = maxHealth;
        if (state == eStates.rage)
        {
            state = eStates.normal;
            NotifyRageModeEnd();
        }
    }

    private void NotifyRageMode()
    {
        OnRampageModeAction?.Invoke();
    }

    private void NotifyRageModeEnd()
    {
        OnRampageModeActionEnd?.Invoke();
    }
}
