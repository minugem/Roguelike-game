using UnityEngine;

public class AttackPowerUp : PowerUp
{
    public float AttackIncrease = 5;

    public AttackPowerUp()
    {
        Name = "Attack Boost";
        Description = "Increase your attack by " + AttackIncrease;
    }

    public override void ApplyEffect(Player player)
    {
        player.Attack += AttackIncrease;
    }
}