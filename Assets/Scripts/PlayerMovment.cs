
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{
    bool alive = true;
    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;

    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePoint = 0.1f;

    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;
    private void FixedUpdate()
    {
        if (!alive) return;
        Vector3 forwardmove= transform.forward*speed*Time.fixedDeltaTime;
        Vector3 HorizontalMove = transform.right * horizontalInput*speed*Time.fixedDeltaTime*horizontalMultiplier;
        rb.MovePosition(rb.position + forwardmove+HorizontalMove);
    }
                
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (transform.position.y<-5)
        {
            Die();
        }
    }
    public void Die()
    {
        alive=false;
        //Restart the game
        Invoke("Restart",2);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    void Jump()
    {
        float height=GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f,groundMask);

        rb.AddForce(Vector3.up * jumpForce);

        
    }
}
