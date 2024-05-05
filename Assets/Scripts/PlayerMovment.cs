
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovnment : MonoBehaviour
{
    bool alive = true;
    public float speed = 5;
    public Rigidbody rb;

    float horizontalInput;

    public float horizontalMultiplier = 2;
    private void FixedUpdate()
    {
        if (!alive) return;
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
}
