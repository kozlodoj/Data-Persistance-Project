using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UiScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScore;
    [SerializeField] TMP_InputField nameText;

    public void Start()
    {
        nameText.text = GameManager.Instance.nameSet;
    }


    public void SetHighScore(string name, int score)
    {
        highScore.SetText("High score " + name + " " + score);
       
    }

    public void StarGame()
    {
        SceneManager.LoadScene(1);
    }
}
