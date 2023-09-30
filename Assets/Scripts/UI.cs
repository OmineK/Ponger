using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI playerPoints;
    [SerializeField] TextMeshProUGUI enemyPoints;

    void Start()
    {
        UpdatePlayerScore();
        UpdateEnemyScore();
    }

    public void UpdatePlayerScore()
    {
        playerPoints.text = gameManager.playerScore.ToString();
    }

    public void UpdateEnemyScore()
    {
        enemyPoints.text = gameManager.enemyScore.ToString();
    }
}
