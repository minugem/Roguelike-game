using UnityEngine;
using UnityEngine.UI;

public class LevelUpTutorial : MonoBehaviour
{
    public LevelUpUIManager levelUpUIManager;  
    public Player player;  

    private bool tutorialStarted = false;

    void Start()
    {
        
        ShowTutorialMessage("Welcome to the Level Up tutorial! Defeat enemies to gain experience.");
    }

    void Update()
    {
        
        if (player.Experience >= 100 && !tutorialStarted)
        {
            tutorialStarted = true;
            StartLevelUpTutorial();
        }
    }

    void StartLevelUpTutorial()
    {
        ShowTutorialMessage("Congratulations! You leveled up! Choose an upgrade: Attack, Defense, Health, or Critical Chance.");

        
        levelUpUIManager.ShowUI();
    }

    void ShowTutorialMessage(string message)
    {
        
        Debug.Log(message);  
    }
}