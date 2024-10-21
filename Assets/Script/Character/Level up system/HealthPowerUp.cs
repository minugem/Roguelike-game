using UnityEngine;

public class HealthPowerUp : PowerUp
{
    public int healthIncrease = 20;

    public HealthPowerUp()
    {
        Name = "Health Boost";
        Description = "Increase your max health by " + healthIncrease;
    }

    public override void ApplyEffect(Player player)
    {
        player.maxHealth += healthIncrease; 
        player.currentHealth = Mathf.Min(player.currentHealth + healthIncrease, player.maxHealth); 
    }
}