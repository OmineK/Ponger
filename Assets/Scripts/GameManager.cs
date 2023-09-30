using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] UI ui;
    [SerializeField] GameBall gameBall;
    [SerializeField] Enemy enemy;

    public int playerScore;
    public int enemyScore;

    public void GameOver()
    {
        if (enemyScore == 11)
        {
            ui.enemyWinPanel.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (playerScore == 11)
        {
            ui.playerWinPanel.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        Time.timeScale = 0;
    }

    public void ResetScore()
    {
        enemyScore = 0;
        playerScore = 0;
    }

    public void ResetBall() => gameBall.ResetBall();

    public void UpgradeEnemy() => enemy.enemySpeed += 0.1f;
}
