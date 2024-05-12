using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManger : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI TotalScoreText;
    public TextMeshProUGUI HighScoreText;

    void Start()
    {
        TotalScoreText = GameObject.Find("TextMeshPro1").GetComponent<TextMeshProUGUI>();
        HighScoreText = GameObject.Find("TextMeshPro2").GetComponent<TextMeshProUGUI>();

        int totalScore = PlayerPrefs.GetInt("TotalScore", 0);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        TotalScoreText.text = $"Total SCORE : {totalScore}";
        HighScoreText.text = $"High Score : {highScore}";


            int playerScore = GameManger.inst.getPlayerScore();

            totalScore += playerScore;

            if (playerScore > highScore)
            {
                highScore = playerScore;
            }

            PlayerPrefs.SetInt("TotalScore", totalScore);
            PlayerPrefs.SetInt("HighScore", highScore);

            TotalScoreText.text = $"Total SCORE : {totalScore}";
            HighScoreText.text = $"High Score : {highScore}";


    }

    // Update is called once per frame
    void Update()
    {

    }
}
