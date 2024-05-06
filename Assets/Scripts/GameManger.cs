using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    int score;
    int upgradeScore = 10;
    public static GameManger inst;
    [SerializeField] Text scoreText;
    [SerializeField] PlayerMovment playerMovment;
    public AudioSource Source;
    public AudioClip Coin_sound,upgradeSfx;
    public void IncrementScore()
    {
        score++;
        scoreText.text = $"SCORE : {score}";
        Source.clip = Coin_sound;
        Source.Play();
        if (score == upgradeScore)
        {
            Source.clip = upgradeSfx;
            Source.Play();
            upgradeScore += 10;
        }
        //increase player speed
        playerMovment.speed += playerMovment.speedIncreasePoint;
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
