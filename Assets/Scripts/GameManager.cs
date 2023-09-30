using System;
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

    bool gamePause = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePause == false)
                GamePause();
            else
                UnpauseGame();
        }
    }

    void GamePause()
    {
        gamePause = true;
        ui.gamePausePanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        gamePause = false;
        ui.gamePausePanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1;
    }

    public void GameOver()
    {
        ui.enemyWinPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0;
    }

    public void PlayerWon()
    {
        ui.playerWinPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

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
