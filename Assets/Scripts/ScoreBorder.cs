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

        // Check if player has won to 11
        if (gameManager.playerScore == 11 && gameManager.enemyScore <= 9)
        {
            gameManager.PlayerWon();
            return;
        }

        //check if enemy has won to 11
        if (gameManager.enemyScore == 11 && gameManager.playerScore <= 9)
        {
            gameManager.GameOver();
            return;
        }

        //checks the win by 2 point difference after player&enemy reach 10+ points
        if (gameManager.playerScore >= 10 && gameManager.enemyScore >= 10)
        {
            if (gameManager.playerScore - gameManager.enemyScore == 2)
            {
                gameManager.PlayerWon();
                return;
            }
            else if (gameManager.enemyScore - gameManager.playerScore == 2)
            {
                gameManager.GameOver();
                return;
            }
        }

        currentBall.ResetBall();
    }
}
