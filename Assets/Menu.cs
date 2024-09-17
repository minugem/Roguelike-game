using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void StartNewGame()
    {
        Debug.Log("New Game started!");
        // SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Game quit!");
        // Application.Quit();
    }

    public void Options()
    {
        Debug.Log("Options!");
    }

    public void LoadGame()
    {
        Debug.Log("Game loaded!");
        // SceneManager.LoadScene("Game");
    }
}
