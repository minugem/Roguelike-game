using UnityEngine;

public class DefensePowerUp : PowerUp
{
    public float DefenseIncrease = 3;

    public DefensePowerUp()
    {
        Name = "Defense Boost";
        Description = "Increase your defense by " + DefenseIncrease;
    }

    public override void ApplyEffect(Player1 player)
    {
        player.Defense += DefenseIncrease;
    }
}