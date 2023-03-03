using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerCurrentHealth;
    public float attackRate = 1f;

    private int moleDamage = 10;
    private int plantDamage = 15;
    private int miniBossDamage = 20;
    private int bossDamage = 30;

    private int playerMaxHealth = 100;

    private Coroutine damageCoroutine;
    private int currentEnemyDamage = 0;

    //public int hitAmount;
    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    void Update()
    {
        if (playerCurrentHealth < 0)
        {
            // play end screen and end the game
        }
    }
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyMole")
        {
            currentEnemyDamage = moleDamage;
            damageCoroutine = StartCoroutine(TakeDamageCoroutine());
            // playerCurrentHealth -= 10;
        }

        if (collision.tag == "EnemyPlant")
        {
            currentEnemyDamage = plantDamage;
            damageCoroutine = StartCoroutine(TakeDamageCoroutine());
            // playerCurrentHealth -= 15;
        }

        if (collision.tag == "MiniBoss")
        {
            currentEnemyDamage = miniBossDamage;
            damageCoroutine = StartCoroutine(TakeDamageCoroutine());
            // playerCurrentHealth -= 20;
        }

        if (collision.tag == "Boss")
        {
            currentEnemyDamage = bossDamage;
            damageCoroutine = StartCoroutine(TakeDamageCoroutine());
            // playerCurrentHealth -= 30;
        }

        if (collision.tag == "Death Line")
        {
            playerCurrentHealth -= 100;
        }

        //Debug.Log("Player Collided with: " + collision);
        //Debug.Log("Player Health: " + playerCurrentHealth);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "EnemyMole")
        {
            StopCoroutine(damageCoroutine);
        }

        if (collision.tag == "EnemyPlant")
        {
            StopCoroutine(damageCoroutine);
        }

        if (collision.tag == "MiniBoss")
        {
            StopCoroutine(damageCoroutine);
        }

        if (collision.tag == "Boss")
        {
            StopCoroutine(damageCoroutine);
        }
    }

    private IEnumerator TakeDamageCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackRate);

            playerCurrentHealth -= currentEnemyDamage;
        }
    }

}
