using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject Player;
    public float fireBallSpeed = 20f;
    private Rigidbody2D rb;
    public Vector3 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //direction = new Vector3(Player.transform.position.x,
        //                        Player.transform.position.y,
        //                        0f);

    }

    private void Update()
    {
        this.transform.position += direction * fireBallSpeed;

        //rb.velocity = this.transform.forward * bulletSpeed;

    }
}
