using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;

    float horizontalInput;

    public float horizontalMultiplier = 2;
    private void FixedUpdate()
    {
        Vector3 forwardmove= transform.forward*speed*Time.fixedDeltaTime;
        Vector3 HorizontalMove = transform.right * horizontalInput*speed*Time.fixedDeltaTime*horizontalMultiplier;
        rb.MovePosition(rb.position + forwardmove+HorizontalMove);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }
}
