using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    [SerializeField]
    Player Player;
    [SerializeField]
    GameObject CoinPrefab;

    [SerializeField]
    float LastPos = -5;
    [SerializeField]
    int LastScale = 10;

    int LastYpos;

    [SerializeField]
    int MaxScale = 7;
    [SerializeField]
    int MaxYPos = 4;

    public int MaxYpos { get => MaxYPos; }
    public float Lastpos { set { LastPos = value; } }
    public int Lastscale { set { LastScale = value; } }
   

    [SerializeField]
    Sprite GroundSprite;


    private void Update()
    {
        MakeGround();
    }

    void MakeGround()
    {
        // 새로운 바닥을 생성
        if(Player.transform.position.x + 20 >= LastPos + LastScale * 0.5f)
        {
            int newScale = Random.Range(2, MaxScale);
            float newX = LastPos + LastScale * 0.5f + newScale * 0.5f + Random.Range(3, 5);
            GameObject ground = new GameObject("Ground");
            ground.AddComponent<BoxCollider2D>();
            ground.AddComponent<SpriteRenderer>();
            DestoryGround dg = ground.AddComponent<DestoryGround>();
            dg.setPlayer(Player);
            SpriteRenderer sr = ground.GetComponent<SpriteRenderer>();
            sr.sprite = GroundSprite;

            LastYpos = Random.Range(-MaxYPos, MaxYPos);
            ground.transform.position = new Vector3(newX, LastYpos, 0);
            ground.transform.localScale = new Vector3(newScale, 1, 1);

            LastPos = newX;
            LastScale = newScale;

            // 코인 생성
            for(int i = 0; i<LastScale; i++)
            {
                GameObject coin = GameObject.Instantiate(CoinPrefab);
                Coin co = coin.AddComponent<Coin>();
                co.setPlayer(Player);
                coin.transform.position = ground.transform.position + Vector3.up;
                coin.transform.position += Vector3.right * (i + 0.5f) + Vector3.left * LastScale * 0.5f;
            }
        }
    }
}
