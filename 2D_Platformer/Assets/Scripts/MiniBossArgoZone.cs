using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossArgoZone : MonoBehaviour
{
    public GameObject target;
    public GameObject myEnemy;
    public float movementSpeed = 2f;

    private Rigidbody2D enemyRigidBody;
    private Animator miniBossAnimator;
    private SpriteRenderer miniBossSR;

    Vector2 calculatedDirection;

    bool targetDetected = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = myEnemy.GetComponent<Rigidbody2D>();

        miniBossAnimator = myEnemy.GetComponent<Animator>();

        miniBossSR = myEnemy.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (targetDetected)
        {
            miniBossAnimator.SetBool("MiniBossIsWalking", true);

            if (calculatedDirection.x < 0)
            {
                miniBossSR.flipX = false;
            }
                
            if (calculatedDirection.x > 0)
            {
                miniBossSR.flipX = true;
            }
        }
        else
        {
            miniBossAnimator.SetBool("MiniBossIsWalking", false);
        }
    }

    void FixedUpdate()
    {
        if (targetDetected)
        {
            calculatedDirection = (target.transform.position - myEnemy.transform.position).normalized;

            enemyRigidBody.velocity = calculatedDirection * movementSpeed;
        }
        else
        {
            enemyRigidBody.velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals(target.name))
        {
            targetDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals(target.name))
        {
            targetDetected = false;
        }
    }
}
/*
 * i want the boss to finish his walking animation
 * i want the boss to turn to face the player
 * i want the boss to follow the player not just go forward
 */
