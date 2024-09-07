using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Game started!");
        // SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Game quit!");
        Application.Quit();
    }
}
