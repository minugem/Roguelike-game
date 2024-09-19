using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Menu : MonoBehaviour
{
    public void StartNewGame()
    {
        Debug.Log("New Game started!");
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Debug.Log("Game quit!");
        Application.Quit();
    }

    public void Options()
    {
        Debug.Log("Options!");
    }

    public void LoadGame()
    {
        Debug.Log("Game loaded!");
        SceneManager.LoadScene("Main");
    }
}