using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    GroundManager gm;

    [SerializeField]
    int MoveSpeed = 5;

    [SerializeField]
    int JumpPower = 500;

    [SerializeField]
    int JumpCount = 2;

    int gamejumpcount;

    Rigidbody2D Myrigid;

    bool isDie = false;
    public bool isdie{ get => isDie; }
    
    private void Awake()
    {
        Myrigid = GetComponent<Rigidbody2D>();
        gamejumpcount = JumpCount;
    }

    private void Start()
    {
        Myrigid.AddForce(new Vector2(0, JumpPower));
    }

    void Update()
    {
        transform.position += Vector3.right * MoveSpeed * Time.deltaTime;

        if (isDie) isDie = false;

        if (Input.GetKeyDown(KeyCode.Space) && gamejumpcount > 0)
        {
            Myrigid.velocity = Vector2.zero;
            Myrigid.AddForce(new Vector2(0, JumpPower));
            gamejumpcount--;
        }

        if(transform.position.y < -gm.MaxYpos - 5)
        {
            transform.position = new Vector3(-9.45f, 0, 0);
            isDie = true;
            gm.Lastpos = -5;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gamejumpcount = JumpCount;
    }
}
