using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float mooveSpeed;
    [SerializeField] int Damage;
    Rigidbody2D myRigidbody;

    SpriteRenderer enemyColor;

    enum eStates
    {
        attack,
        runaway
    }

    eStates state { get; set; }

    void Start()
    {
        enemyColor = GetComponent<SpriteRenderer>();

        myRigidbody = GetComponent<Rigidbody2D>();
        GameController.RegisterEnemy(this);
        state = eStates.attack;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction;
        switch (state)
        {
            case eStates.attack:
                direction = GameController.GetPlayerPos() - (Vector2)transform.position;
                myRigidbody.velocity = direction * mooveSpeed;
                break;

            case eStates.runaway:
                direction = (Vector2)transform.position - -GameController.GetPlayerPos();
                myRigidbody.velocity = direction * mooveSpeed;
                enemyColor.color = Color.cyan;
                break;
        }
    }


    private void OnCollisionStay2D(Collision2D other)
    {
        Player otherPlayer = other.gameObject.GetComponent<Player>();
        if (otherPlayer)
        {
            otherPlayer.GetDamage(Damage);
        }
    }

    public void OnNotifyRageMode()
    {
        state = eStates.runaway;
    }

    public void OnNotifyRageModeEnd()
    {
        state = eStates.attack;
    }

    private void OnEnable()
    {
        Player.OnRampageModeAction += OnNotifyRageMode;
        Player.OnRampageModeActionEnd += OnNotifyRageModeEnd;
    }

    private void OnDisable()
    {
        Player.OnRampageModeAction -= OnNotifyRageMode;
        Player.OnRampageModeActionEnd -= OnNotifyRageModeEnd;

    }

}
