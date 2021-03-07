using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    [SerializeField]
    float LastPos = -5;
    [SerializeField]
    int LastScale = 10;

    [SerializeField]
    int MaxScale = 8;
    [SerializeField]
    int MaxYPos = 4;

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
            int newScale = Random.Range(3, MaxScale);
            float newX = LastPos + LastScale * 0.5f + newScale * 0.5f + Random.Range(3, 5);
            GameObject ground = new GameObject("Ground");
            ground.AddComponent<BoxCollider2D>();
            ground.AddComponent<SpriteRenderer>();
            SpriteRenderer sr = ground.GetComponent<SpriteRenderer>();
            sr.sprite = GroundSprite;

            ground.transform.position = new Vector3(newX, Random.Range(-MaxYPos, MaxYPos), 0);
            ground.transform.localScale = new Vector3(newScale, 1, 1);

            LastPos = newX;
            LastScale = newScale;
        }
    }
}
