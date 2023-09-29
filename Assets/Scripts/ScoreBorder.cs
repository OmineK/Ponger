using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBorder : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.position.x > transform.position.x)
            gameManager.enemyScore++;
        else
            gameManager.playerScore++;

        ResetBall(collision.gameObject.GetComponent<GameBall>());
    }

    void ResetBall(GameBall _ball)
    {
        _ball.canMove = false;
        _ball.newRoundStart();
        _ball.transform.position = Vector3.zero;
    }
}
