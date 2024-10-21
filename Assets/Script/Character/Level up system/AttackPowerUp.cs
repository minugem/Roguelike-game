using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

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