using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Player Player;

    public void setPlayer(Player _player)
    {
        Player = _player;
    }
    void Update()
    {
        if (Player.transform.position.x - transform.position.x > 15)
        {
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        if (Player.isdie)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameMana.CurrentScore += 1;
        Destroy(gameObject);
    }
}
