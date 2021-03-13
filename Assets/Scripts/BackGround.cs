using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    Player Player;
    Vector3 firstpos;
    private void Awake()
    {
        firstpos = transform.position;
    }
    private void Update()
    {
        if (Player.isdie) transform.position = firstpos;
        transform.position += Vector3.right * 2 * Time.deltaTime;

        if (Player.transform.position.x - transform.position.x > 15)
        {
            transform.position += new Vector3(39.9f, 0, 0);
        }
    }
}
