using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini_BossAttack : MonoBehaviour
{
   public GameObject myMiniBoss;
   public float attackRate = 1f;

    private Animator miniBossAnimator;
    private Coroutine attackCoroutine;
    

    private void Start()
    {
        miniBossAnimator = myMiniBoss.gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == "Player")
        {
            //miniBossAnimator.SetBool("MiniBossIsAttacking", true);

            attackCoroutine = StartCoroutine(AttackCoroutine());
        }
        //else
        //{
        //    miniBossAnimator.SetBool("MiniBossIsAttacking", false);
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
            miniBossAnimator.SetBool("MiniBossIsAttacking", true);

            yield return new WaitForSeconds(attackRate);
        }
    }
}
