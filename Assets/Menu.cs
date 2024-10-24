using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Menu : MonoBehaviour
{
    //When The StartNewGame function is called it loads the Main Scene
    public void StartNewGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    //When The QuitGame function is called it quits the game
    public void QuitGame()
    {
        Application.Quit();
    }

    //When The Options function is called it will display an options menu (to be added)
    public void Options()
    {
        Debug.Log("Options!");
    }

    //When The LoadGame function is called it loads the Main Scene
    public void LoadGame()
    {
        SceneManager.LoadScene("Level 1");
    }
}