using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static bool gameIsOver;

    private void Start()
    {
        gameIsOver = false;
    }


    private void Update()
    {
        if (gameIsOver)
            return;

        if (Input.GetKeyDown("r"))
        {
            EndGame();
        }

        if (PlayerStats.playerHP <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameIsOver = true;

        gameOverUI.SetActive(true);
    }
}
