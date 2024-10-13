using UnityEngine;

public class PlayerLevelUp : MonoBehaviour
{
    public LevelUpUIManager levelUpUIManager;

    
    private int experience = 0;
    private int level = 1;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            KillEnemy(); 
        }
    }

    public void KillEnemy()
    {
        GainExperience(50); 
    }

    public void GainExperience(int amount)
    {
        experience += amount;

        if (experience >= 100 * level) 
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        experience = 0; 
        Debug.Log("level up£¡ level: " + level);

        
        levelUpUIManager.ShowUI();
    }
}