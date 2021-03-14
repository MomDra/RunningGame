using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Mana : MonoBehaviour
{
    [SerializeField]
    GameObject ScoreBoard;
    [SerializeField]
    GameObject CloseButton;
    [SerializeField]
    GameObject Title;
    [SerializeField]
    GameObject PlayButton;
    [SerializeField]
    GameObject ScoreButton;
    [SerializeField]
    GameObject InputField;
    [SerializeField]
    Text inputText;
    [SerializeField]
    Text[] ScoreBoardText;

    int minval = 0;

    static LinkedList<string> Names = new LinkedList<string>();
    static LinkedList<int> Scores = new LinkedList<int>();

    public void GamePlay()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void OpenScoreBoard()
    {
        ScoreBoard.SetActive(true);
        Title.SetActive(false);
        PlayButton.SetActive(false);
        ScoreButton.SetActive(false);
        InputField.SetActive(false);
    }

    public void CloseScoreBoard()
    {
        ScoreBoard.SetActive(false);
        Title.SetActive(true);
        PlayButton.SetActive(true);
        ScoreButton.SetActive(true);
    }

    public void UpdateScore(string _name)
    {
        Text[] texts = ScoreBoard.GetComponentsInChildren<Text>();

        LinkedListNode<int> currintnode = Scores.First;
        LinkedListNode<string> currstringnode = Names.First;

        if(currintnode == null)
        {
            Scores.AddFirst(GameMana.CurrentScore);
            Names.AddFirst(_name);
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                if (currintnode.Value < GameMana.CurrentScore)
                {
                    Scores.AddBefore(currintnode, GameMana.CurrentScore);
                    Names.AddBefore(currstringnode, _name);
                    break;
                }
                else if(currintnode.Next == null)
                {
                    Scores.AddAfter(currintnode, GameMana.CurrentScore);
                    Names.AddAfter(currstringnode, _name);
                    break;
                }

                currintnode = currintnode.Next;
                currstringnode = currstringnode.Next;
            }
        }

        RenderScore();
    }

    private void RenderScore()
    {
        LinkedListNode<int> currintnode = Scores.First;
        LinkedListNode<string> currstringnode = Names.First;
        currintnode = Scores.First;
        currstringnode = Names.First;

        int N = Scores.Count >= 3 ? 3 : Scores.Count;
        for (int i = 0; i < N; i++)
        {
            ScoreBoardText[i].text = string.Format("{0}.  {1}  {2}", i + 1, currstringnode.Value == "" ? "NoName" : currstringnode.Value, currintnode.Value);
            if (i == 2) minval = currintnode.Value;
            currintnode = currintnode.Next;
            currstringnode = currstringnode.Next;
        }
    }

    private void OpenInputField()
    {
        InputField.SetActive(true);
        CloseButton.SetActive(false);
    }

    private void CloseInputField()
    {
        InputField.SetActive(false);
        CloseButton.SetActive(true);
    }

    public void PressEnter()
    {
        Text text = inputText;
        UpdateScore(text.text);
        CloseInputField();
    }

    private bool UpdateCheck()
    {
        if (Scores.Count < 3) return true;
        else
        {
            return minval < GameMana.CurrentScore;
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        OpenScoreBoard();
        if(UpdateCheck()) OpenInputField();
        else RenderScore();
    }
}
