using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    // nell' uml non ci sono, ma potreste mettere 2 stati anche qui

    static Player instance;
    
    private void Start() {
        instance = this;
    }

    public static void RegisterEnemy(Enemy _enemy) {
        //throw new NotImplementedException();
    }

    public static Vector2 GetPos() {
        Debug.Log("ho ritornato: " + (Vector2) instance.transform.position);
        return instance.transform.position;
    }

    public void GetDamage(int _damage) {
        throw new NotImplementedException();
    }

    private void NotifyRageMode() {
        throw new NotImplementedException();
    }




}
