using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float turnspeed = 90f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>()!=null)
        {
            Destroy(gameObject);
        }
        if (other.gameObject.name!="Player")
        {
            return;
        }
        GameManger.inst.IncrementScore();
        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnspeed * Time.deltaTime);
    }
}
