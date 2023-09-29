using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerScore;
    public int enemyScore;

    public void GameOver()
    {
        Time.timeScale = 0;

        if (enemyScore == 11)
        {
            Debug.Log("Game Over");
            //TODO: Display canvas GameOver and button "Try again"
        }

        if (playerScore == 11)
        {
            Debug.Log("Congratz!");
            //TODO: Display canvas Congratz and button "Load a better enemy!"
        }
    }
}
