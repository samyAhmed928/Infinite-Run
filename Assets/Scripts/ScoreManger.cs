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

        // Update the text of textMeshProObject1 and textMeshProObject2 with the initial scores
        TotalScoreText.text = $"Total SCORE : {totalScore}";
        HighScoreText.text = $"High Score : {highScore}";

        // Check if GameManger.inst is not null before accessing it
        //if (GameManger.inst.getPlayerScore() != null)
        //{
            // Retrieve the player's score
            int playerScore = GameManger.inst.getPlayerScore();

            // Update the total score
            totalScore += playerScore;

            // Update the high score if the player's score is greater
            if (playerScore > highScore)
            {
                highScore = playerScore;
            }

            // Save the updated scores in PlayerPrefs
            PlayerPrefs.SetInt("TotalScore", totalScore);
            PlayerPrefs.SetInt("HighScore", highScore);

            // Update the text with the updated scores
            TotalScoreText.text = $"Total SCORE : {totalScore}";
            HighScoreText.text = $"High Score : {highScore}";
        //}



        //if (PlayerPrefs.HasKey("TotalScore"))
        //{
        //    Debug.Log("IM Total score");
        //    int TScore = PlayerPrefs.GetInt("TotalScore");
        //    Debug.Log($"Total score : {TScore}");

        //    if (GameManger.inst != null)
        //    {
        //        Debug.Log("++ Total");
        //        TScore +=  GameManger.inst.getPlayerScore();
        //        Debug.Log($"Total score : {TScore}");


        //    }

        //    PlayerPrefs.SetInt("TotalScore", TScore);
        //    textMeshProObject1.text = $"Total SCORE : {TScore}";

        //}
        //else
        //{
        //    // If no total score is found (e.g., first time playing), set it to 0
        //    Debug.Log("I will zero total");

        //    PlayerPrefs.SetInt("TotalScore", 0);
        //}
        //if (PlayerPrefs.HasKey("HighScore"))
        //{
        //    Debug.Log("IM High score");
        //    Debug.Log($"High score : {PlayerPrefs.GetInt("HighScore")}");
        //    int HScore = PlayerPrefs.GetInt("HighScore");
        //    if (GameManger.inst != null)
        //    {
        //        int score = GameManger.inst.getPlayerScore();
        //        if (score > HScore)
        //        {
        //           HScore= score;
        //        }

        //    }
        //    PlayerPrefs.SetInt("HighScore", HScore);


        //    textMeshProObject2.text = $"High Score : {HScore}";


        //}
        //else
        //{
        //    // If no total score is found (e.g., first time playing), set it to 0
        //    Debug.Log("I will zero high");
        //    PlayerPrefs.SetInt("HighScore", 0);
        //}

    }

    // Update is called once per frame
    void Update()
    {

    }
}
