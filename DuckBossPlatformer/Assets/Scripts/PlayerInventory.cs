using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    public GameObject theDoors;
    public int playerCoins = 0;
    public int playerGems = 0;
    public bool hasKey;

    private void Start()
    {
        hasKey = false;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Collectables")
        {
            GameObject collectable = collision.gameObject;
            int collectableValue = collectable.GetComponent<ItemValue>().itemValue;
            playerCoins += collectableValue;
            Destroy(collectable);

        }

        if (collision.collider.tag == "GemCollectable")
        {
            GameObject collectable = collision.gameObject;
            int collectableValue = collectable.GetComponent<GemValue>().itemValue;
            playerGems += collectableValue;
            Destroy(collectable);
            if (playerGems == 5)
            {
                SceneManager.LoadScene("4_Level_Boss");
            }
        }

        if (collision.collider.tag == "Keys")
        {
            // open the door.
            // other.GetComponent<PlayerInventory>().hasKey = true;

            GameObject keyCollectable = collision.gameObject; // the key

            hasKey = true;
            theDoors.SetActive(true);
            Destroy(keyCollectable);
            
        }
    }
}
