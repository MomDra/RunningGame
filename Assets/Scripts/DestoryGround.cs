using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryGround : MonoBehaviour
{
    Player Player;

    public void setPlayer(Player _player)
    {
        Player = _player;
    }
    void Update()
    {
        if(Player.transform.position.x - transform.position.x > 15)
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
}
