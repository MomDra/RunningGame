using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BackGround : MonoBehaviour
{
    [SerializeField]
    GameObject MainCamera;

    void Update()
    {
        transform.position += Vector3.left * 2 * Time.deltaTime;

        if (MainCamera.transform.position.x - transform.position.x > 20)
        {
            transform.position += new Vector3(39.9f, 0, 0);
        }
    }
}
