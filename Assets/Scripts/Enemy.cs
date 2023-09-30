using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameBall gameBall;

    public float enemySpeed;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        EnemyMoveAI();
    }

    void EnemyMoveAI()
    {
        if (gameBall == null) { return; }

        if (gameBall.canMove == false)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        //if ball going to the enemy
        if (gameBall.ballXDirection == 1)
        {
            if (gameBall.transform.position.y > transform.position.y)
                rb.velocity = new Vector3(0, enemySpeed, 0);
            else
                rb.velocity = new Vector3(0, -enemySpeed, 0);
        }

        //if ball going to the player
        if (gameBall.ballXDirection == -1)
        {
            if (transform.position.y < 0.1f && transform.position.y > -0.1f) 
            {
                rb.velocity = Vector3.zero;
                return; 
            }

            if (transform.position.y > 0)
                rb.velocity = new Vector3(0, -enemySpeed / 2, 0);
            else
                rb.velocity = new Vector3(0, enemySpeed / 2, 0);
        }    
    }
}
