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
        // set to false everytime
        // when restart or reload scene
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (Input.GetKeyDown("w"))
        {
            WinLevel();
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
