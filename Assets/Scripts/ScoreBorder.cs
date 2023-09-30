using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBorder : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] UI ui;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameBall currentBall = collision.gameObject.GetComponent<GameBall>();

        if (collision.gameObject.transform.position.x > transform.position.x)
        {
            gameManager.enemyScore++;
            ui.UpdateEnemyScore();
        }
        else
        {
            gameManager.playerScore++;
            ui.UpdatePlayerScore();
        }

        currentBall.canMove = false;

        if (gameManager.playerScore == 11 || gameManager.enemyScore == 11)
        {
            gameManager.GameOver();
            return;
        }

        currentBall.ResetBall();
    }
}
