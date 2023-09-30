using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI playerScore;
    [SerializeField] TextMeshProUGUI enemyScore;

    public GameObject playerWinPanel;
    public GameObject enemyWinPanel;
    public GameObject gamePausePanel;

    void Start()
    {
        playerWinPanel.SetActive(false);
        enemyWinPanel.SetActive(false);
        gamePausePanel.SetActive(false);

        UpdatePlayerScore();
        UpdateEnemyScore();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UpdatePlayerScore()
    {
        playerScore.text = gameManager.playerScore.ToString();
    }

    public void UpdateEnemyScore()
    {
        enemyScore.text = gameManager.enemyScore.ToString();
    }

    public void PlayAgainButton()
    {
        enemyWinPanel.SetActive(false);
        SetupNewRound();
    }

    public void LoadBetterEnemyButton()
    {
        gameManager.UpgradeEnemy();

        playerWinPanel.SetActive(false);
        SetupNewRound();
    }

    void SetupNewRound()
    {
        Time.timeScale = 1;

        gameManager.ResetScore();

        UpdatePlayerScore();
        UpdateEnemyScore();

        gameManager.ResetBall();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnpauseGameUI() => gameManager.UnpauseGame();

    public void GoBackToMenuButton()
    {
        SceneManager.LoadScene("Menu");

        Time.timeScale = 1;
    }
}
