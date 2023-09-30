using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI playerScore;
    [SerializeField] TextMeshProUGUI enemyScore;

    public GameObject playerWinPanel;
    public GameObject enemyWinPanel;

    void Start()
    {
        playerWinPanel.SetActive(false);
        enemyWinPanel.SetActive(false);

        UpdatePlayerScore();
        UpdateEnemyScore();
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
    }
}
