using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public GameObject enemyDrop;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fire Ball")
        {
            currentHealth--;
            if (currentHealth == 0)
            {
                GameObject g = Instantiate(enemyDrop, this.transform.position, Quaternion.identity);
                g.transform.position = this.transform.position;
                Destroy(this.gameObject);
            }
            Destroy(other.gameObject);
        }
    }
}
