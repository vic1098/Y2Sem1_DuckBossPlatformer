using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer moleSR;
    private float moveSpeed = 3f;
    private int direction;
    private Animator moleAnimator;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        moleSR = gameObject.GetComponent<SpriteRenderer>();
        moleAnimator = gameObject.GetComponent<Animator>();
        direction = 1;
        moleAnimator.SetBool("MoleIsWalking", true);
    }
    private void Update()
    {
        rb.velocity = new Vector2(moveSpeed * direction, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // print("collided with: " + collision.tag);
        if (collision.gameObject.tag != "Foreground")
        {
            direction *= -1;
            moleSR.flipX = !moleSR.flipX;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyPlant") return;
        direction *= -1;
        moleSR.flipX = !moleSR.flipX;
    }
}
