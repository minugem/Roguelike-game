using UnityEngine;

public class HealthPowerUp : PowerUp
{
    public float HealthIncrease = 20;

    public HealthPowerUp()
    {
        Name = "Health Boost";
        Description = "Increase your health by " + HealthIncrease;
    }

    public override void ApplyEffect(Player1 player)
    {
        player.Health += HealthIncrease;
    }
}