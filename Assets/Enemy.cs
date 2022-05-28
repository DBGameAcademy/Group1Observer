using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float mooveSpeed;
    [SerializeField] int Damage;
    Rigidbody2D myRigidbody;
    
    enum eStates {
        attack,
        runaway
    }

    eStates state { get; set;  }

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        Player.RegisterEnemy(this);
        state = eStates.attack;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction;
        switch (state) {
            case eStates.attack:
                direction = Player.GetPos() - (Vector2)transform.position;
                myRigidbody.velocity = direction * mooveSpeed;
                break;
            case eStates.runaway:
                direction = (Vector2) transform.position - Player.GetPos();
                myRigidbody.velocity = direction * mooveSpeed;
                break;
        }
    }


    private void OnCollisionStay2D(Collision2D other) {
        Player otherPlayer = other.gameObject.GetComponent<Player>();
        if (otherPlayer) {
            otherPlayer.GetDamage(Damage);
        }
    }

}
