using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManger : MonoBehaviour
{
     int score;
    public static GameManger inst;
    public Text scoreText;

    public void IncrementScore()
    {
        score++;
        scoreText.text = $"SCORE : {score}";
    }
    // Start is called before the first frame update

    private void Awake()
    {
        inst = this; 
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
