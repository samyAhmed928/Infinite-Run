using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
using TMPro;

public class GameManger : MonoBehaviour
{
    int score=0;
    int upgradeScore = 10;
    public static GameManger inst;
    
    public TextMeshProUGUI ScoreText;

    [SerializeField] PlayerMovment playerMovment;
    public AudioSource Source,second_source;
    public AudioClip Coin_sound,upgradeSfx;
    public void IncrementScore()
    {
        score++;
        ScoreText.text = $"SCORE : {score}";
        Source.clip = Coin_sound;
        Source.Play();
        if (score == upgradeScore)
        {
            second_source.clip = upgradeSfx;
            second_source.Play();
            upgradeScore += 10;
        }
        playerMovment.speed += playerMovment.speedIncreasePoint;
    }
    
    public int getPlayerScore()
    {
        return score;
    }
    // Start is called before the first frame update

    private void Awake()
    {
        inst = this; 
    }
    void Start()
    {
        ScoreText = GameObject.Find("Smesh").GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
