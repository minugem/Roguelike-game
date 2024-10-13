using UnityEngine;

public class AttackPowerUp : PowerUp
{
    public float AttackIncrease = 5;

    public AttackPowerUp()
    {
        Name = "Attack Boost";
        Description = "Increase your attack by " + AttackIncrease;
    }

    public override void ApplyEffect(Player1 player)
    {
        player.Attack += AttackIncrease;
    }
}