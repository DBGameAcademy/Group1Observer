using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static Player player;
    static List<Enemy> enemies = new List<Enemy>();
    private static GameController instance;

    private void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public static void RegisterPlayer(Player _player) {
        player = _player;
    }

    public static void RegisterEnemy(Enemy _enemy) {
        enemies.Add(_enemy);
    }

    public static Player GetPlayer() {
        return player;
    }

    public static Vector2 GetPlayerPos() {
        return player.GetPos();
    }

}
