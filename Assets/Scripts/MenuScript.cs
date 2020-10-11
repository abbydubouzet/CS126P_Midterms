using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script to handle all menu scenes
public class MenuScript : MonoBehaviour
{
    // Load Game
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    // Quit Program
    public void QuitGame()
    {
        Debug.Log("ApplicationQuit");
        Application.Quit();
    }

    // Go back to main menu from score screen
    public void BackToMainMenu()
    {
        print("out");
        SceneManager.LoadScene(0);
    }
}
