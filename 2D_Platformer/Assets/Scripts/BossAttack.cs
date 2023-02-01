using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject myBoss;
    public float attackRate = 1f;

    private Animator BossAnimator;
    private Coroutine attackCoroutine;


    private void Start()
    {
        BossAnimator = myBoss.gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //BossAnimator.SetBool("BossIsAttacking", true);

            attackCoroutine = StartCoroutine(AttackCoroutine());
        }
        //else
        //{
        //    BossAnimator.SetBool("BossIsAttacking", false);
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StopCoroutine(attackCoroutine);
        }
    }

    private IEnumerator AttackCoroutine()
    {
        while (true)
        {
            BossAnimator.SetBool("BossIsAttacking", true);

            yield return new WaitForSeconds(attackRate);
        }
    }
}
