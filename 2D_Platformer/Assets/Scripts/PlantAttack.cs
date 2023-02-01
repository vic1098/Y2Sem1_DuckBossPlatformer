using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAttack : MonoBehaviour
{
    public GameObject myPlant;
    public float attackRate = 1f;

    private Animator plantAnimator;
    private Coroutine attackCoroutine;
    

    private void Start()
    {
        plantAnimator = myPlant.gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == "Player")
        {
            //plantAnimator.SetBool("PlantIsAttacking", true);

            attackCoroutine = StartCoroutine(AttackCoroutine());
        }
        //else
        //{
        //    plantAnimator.SetBool("PlantIsAttacking", false);
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
            plantAnimator.SetBool("PlantIsAttacking", true);

            yield return new WaitForSeconds(attackRate);
        }
    }
}
