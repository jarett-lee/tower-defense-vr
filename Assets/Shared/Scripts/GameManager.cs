using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        if (GameIsOver)
            return;

        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        if (GameIsOver)
            return;

        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }

}
