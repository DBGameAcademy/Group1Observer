using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    // nell' uml non ci sono, ma potreste mettere 2 stati anche qui
    private void Start() {
        GameController.RegisterPlayer(this);
    }

    public Vector2 GetPos() {
        return transform.position;
    }

    public void GetDamage(int _damage) {
        throw new NotImplementedException();
    }

    private void NotifyRageMode() {
        throw new NotImplementedException();
    }




}
