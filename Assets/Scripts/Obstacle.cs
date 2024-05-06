using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovment playerMovnment;
    void Start()
    {
        playerMovnment=GameObject.FindObjectOfType<PlayerMovment>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //Kill the player
            playerMovnment.Die();
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
