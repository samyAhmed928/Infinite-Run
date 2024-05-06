
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{
    bool alive = true;
    bool IsonGround = true;
    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;

    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePoint = 0.1f;

    [SerializeField] int jumpForce = 10;
    [SerializeField] LayerMask groundMask;
    public AudioSource source,second_src;
    public AudioClip JumpSfx, DieSfx, StartSfx,EndSfx;
    Animator anim;

    private void FixedUpdate()
    {
        if (!alive) return;
        Vector3 forwardmove= transform.forward*speed*Time.fixedDeltaTime;
        Vector3 HorizontalMove = transform.right * horizontalInput*speed*Time.fixedDeltaTime*horizontalMultiplier;
        rb.MovePosition(rb.position + forwardmove+HorizontalMove);
    }
                
    void Start()
    {
        anim = GetComponent<Animator>();
        source.clip = StartSfx;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && IsonGround&&alive)
            {
                Jump();
                IsonGround = false;
            }

            if (transform.position.y < -5)
            {
                Die();
            }
        


    }
    public void Die()
    {
        alive=false;
        //Restart the game
        source.clip = DieSfx;
        source.Play();
        anim.SetBool("Die", true);

        second_src.clip = EndSfx;
        second_src.Play();
        Invoke("Restart",4);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    void Jump()
    {
        //float height = GetComponent<Collider>().bounds.size.y;

        rb.AddForce(new Vector3(0, jumpForce, 0),ForceMode.Impulse);
        
        source.clip = JumpSfx;
        source.Play();
        


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Assuming the ground has a tag "Ground"
        {
            Debug.Log("Colloision");
            IsonGround = true; // Reset jumping state when colliding with the ground
        }
    }
}
