using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMana : MonoBehaviour
{
    [SerializeField]
    Text text;

    static int currentScore = 0;
    public static int CurrentScore { get => currentScore; set { currentScore = value; } }
    void Awake()
    {
        currentScore = 0;
    }
    void Update()
    {
        text.text = currentScore.ToString();
    }
}
