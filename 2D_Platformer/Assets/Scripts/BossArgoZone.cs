using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArgoZone : MonoBehaviour
{
    public GameObject target;
    public GameObject myEnemy;
    public float movementSpeed = 2f;

    private Rigidbody2D enemyRigidBody;
    private Animator BossAnimator;
    private SpriteRenderer BossSR;

    Vector2 calculatedDirection;

    bool targetDetected = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = myEnemy.GetComponent<Rigidbody2D>();

        BossAnimator = myEnemy.GetComponent<Animator>();

        BossSR = myEnemy.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (targetDetected)
        {
            BossAnimator.SetBool("BossIsWalking", true);

            if (calculatedDirection.x < 0)
            {
                BossSR.flipX = false;
            }

            if (calculatedDirection.x > 0)
            {
                BossSR.flipX = true;
            }
        }
        else
        {
            BossAnimator.SetBool("BossIsWalking", false);
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
