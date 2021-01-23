using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "LevelSelect";

    public string nextLevel = "Level2";


    public void Continue()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void Retry()
    {
        // Reload level as reload scene
        // !! You need to insert scene into build settings!
        // RES: https://forum.unity.com/threads/solved-fully-reset-current-scene.608893/
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
