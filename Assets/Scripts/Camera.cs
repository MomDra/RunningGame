using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    private void LateUpdate()
    {
        transform.position = new Vector3(Player.transform.position.x + 5, 1, -10);
    }
}
