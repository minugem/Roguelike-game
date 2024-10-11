using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    
    public List<PowerUp> powerUps;
    public Player player;

    void Start()
    {
        
        powerUps = new List<PowerUp>
        {
            new AttackPowerUp(),
            new DefensePowerUp(),
            new HealthPowerUp(),
            new CritChancePowerUp()
        };
    }

    
    public void LevelUp()
    {
        
        List<PowerUp> availablePowerUps = new List<PowerUp>();

       
        for (int i = 0; i < 3; i++)
        {
            PowerUp randomPowerUp = powerUps[Random.Range(0, powerUps.Count)];
            availablePowerUps.Add(randomPowerUp);
        }

        
        DisplayPowerUpChoices(availablePowerUps);
    }

    
    private void DisplayPowerUpChoices(List<PowerUp> choices)
    {
        Debug.Log("Choose one of the following power-ups:");

        
        foreach (var powerUp in choices)
        {
            Debug.Log("PowerUp: " + powerUp.Name + " - " + powerUp.Description);
        }

        
    }

    
    public void OnPowerUpSelected(PowerUp chosenPowerUp)
    {
        chosenPowerUp.ApplyEffect(player);
        Debug.Log(chosenPowerUp.Name + " has been applied!");
    }
}