using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; private set; }
    [SerializeField] private TextMeshProUGUI scoreTxt; //Score Text
    [SerializeField] private TextMeshProUGUI highScoreTxt; //Highscore Text

    private int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        scoreTxt.text = score.ToString();
        highScoreTxt.text = PlayerPrefs.GetInt("HighScore", 0).ToString(); //Get highscore stored in player preferences

        UpdateHighScore();
    }
    //If score is higher than highscore, update highscore
    private void UpdateHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreTxt.text = score.ToString();
        }
    }
    //Update score
    public void UpdateScore(int points)
    {
        score += points;
        scoreTxt.text = score.ToString();
        UpdateHighScore();
    }
}
