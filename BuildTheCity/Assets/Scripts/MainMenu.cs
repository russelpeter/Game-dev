using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Pressed");
        SceneManager.LoadSceneAsync("BuildingMechanicPrototype"); // Load the "start" scene by its name
    }

    public void RestartGame()
    {
        Debug.Log("Restarting");
        SceneManager.LoadSceneAsync("Menu"); // Load the "start" scene by its name
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}


