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
    GameObject GroundSprite;
    [SerializeField]
    GameObject LeftGroundSprite;
    [SerializeField]
    GameObject RightGroundSprite;

    private void Update()
    {
        MakeGround();
    }

    void MakeGround()
    {
        // 새로운 바닥을 생성
        if(Player.transform.position.x + 20 > LastPos + LastScale)
        {
            int newScale = Random.Range(2, MaxScale);
            float newX = LastPos + LastScale + Random.Range(3, 6);
            LastYpos = Random.Range(-MaxYPos, MaxYPos);
            //ground.transform.position = new Vector3(newX, LastYpos, 0);
            //ground.transform.localScale = new Vector3(newScale, 1, 1);

            for(int i = 0; i<newScale; i++)
            {
                GameObject go;

                if(i == 0)
                {
                    go = Instantiate(LeftGroundSprite);
                }
                else if(i == newScale - 1)
                {
                    go = Instantiate(RightGroundSprite);
                }
                else
                {
                    go = Instantiate(GroundSprite);
                }
                DestoryGround dg = go.AddComponent<DestoryGround>();
                dg.setPlayer(Player);
                go.transform.position = new Vector3(newX + i, LastYpos, 0);
            }

            // 코인 생성
            for (int i = 0; i < newScale; i++)
            {
                GameObject coin = GameObject.Instantiate(CoinPrefab);
                Coin co = coin.AddComponent<Coin>();
                co.setPlayer(Player);
                coin.transform.position = new Vector3(newX + i, LastYpos, 0) + Vector3.up;
            }

            LastPos = newX;
            LastScale = newScale;
        }
    }
}
