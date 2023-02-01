using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class myPlayerManager : MonoBehaviour
{
    public float playerSpeed = 5f;
    public GameObject player;

    private Animator playerAnimator;

    private SpriteRenderer playerSR;
    private Rigidbody2D rb;
    private Vector2 movement;

    // all to do with the jump
    // public Vector2 movementDirection;
    public float jumpImpulse = 7f;
    GroundCheck groundCheck;

    // all to do with the fireball
    public FireBall fireBallPrefab;
    public float fireBallSpeed = 2.0f;
    private Vector2 fireBallDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        playerAnimator = gameObject.GetComponent<Animator>();

        playerSR = gameObject.GetComponent<SpriteRenderer>();

        groundCheck = gameObject.GetComponent<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (movement !=Vector2.zero)
        {
            playerAnimator.SetBool("PlayerIsWalking", true);

            if (movement.x < 0)
            {
                playerSR.flipX = true;
            }
            if (movement.x > 0)
            {
                playerSR.flipX = false;
            }

        }
        else
        {
            playerAnimator.SetBool("PlayerIsWalking", false);
        }*/


        
        if (movement != Vector2.zero)
        {
            // Is the Run animation set the False?
            if (playerAnimator.GetBool("PlayerIsWalking") == false)
            {
                // Enable the Run Animation
                playerAnimator.SetBool("PlayerIsWalking", true);

            }

            if (movement.x < 0) 
            { 
                playerSR.flipX = true; 
            }
            if (movement.x > 0)
            {
                playerSR.flipX = false;
            }
        }

        // If the player is not moving - they're standing still
        else
        {
            // Disable the Run Animation
            playerAnimator.SetBool("PlayerIsWalking", false);
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    rb.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);
        //}
    }

        
   
    // here is the problem
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movement * playerSpeed * Time.fixedDeltaTime));
        //rb.velocity = new Vector2((movementDirection.x * playerSpeed), rb.velocity.y * Time.fixedDeltaTime);
    }
    
    private void OnMove(InputValue movePosition)
    {
        movement = movePosition.Get<Vector2>();
    }

    //there is a problem here also, interaction is not working with player movement
    void OnJump()
    {
        // Trigger the Jump Animation
        if (groundCheck.isGrounded)
        {
            Debug.Log("Player has Jumped!");
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);// (x, y) (rb.velocity.y + 
            //rb.AddForce(new Vector2(0, jumpImpulse), ForceMode2D.Impulse);
            playerAnimator.SetTrigger("PlayerIsJumping");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DoorToLevelSecret")
        {
            SceneManager.LoadScene("3_Level_2_Secret");
        }

        if (collision.tag == "DoorToLevelBoss")
        {
            SceneManager.LoadScene("4_Level_Boss");
        }
    }

    private void OnFire()
    {
        playerAnimator.SetTrigger("PlayerIsAttacking");
        FireBullet();
    }

    private void FireBullet()
    {
        // instantiate a bullet object
        // set the transform and rotation = player tran and rotation
        FireBall b = Instantiate(fireBallPrefab, player.transform.position, Quaternion.identity);
        b.transform.position = player.transform.position;
        b.transform.rotation = player.transform.rotation;
        b.Player = this.gameObject;
        b.direction = Vector2.right; // (Vector3)fireBallDirection;
        Destroy(b.gameObject, 3f);
    }
}
/*
 * i want to fire the bullet
 * i want the enemy to lose health after fire ball hit
 * i want to destroy the fire ball after contact
 * if no contact i want to destroy the bullet after 3 sec
 */