using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    int MoveSpeed = 5;

    [SerializeField]
    int JumpPower = 500;

    [SerializeField]
    int JumpCount = 2;

    int gamejumpcount;

    Rigidbody2D Myrigid;
    // Start is called before the first frame update
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


        if (Input.GetKeyDown(KeyCode.Space) && gamejumpcount > 0)
        {
            Myrigid.AddForce(new Vector2(0, JumpPower));
            gamejumpcount--;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gamejumpcount = JumpCount;
    }
}
