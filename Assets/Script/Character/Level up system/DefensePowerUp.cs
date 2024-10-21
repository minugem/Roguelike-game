using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DefensePowerUp : PowerUp
{
    public float DefenseIncrease = 3;

    public DefensePowerUp()
    {
        Name = "Defense Boost";
        Description = "Increase your defense by " + DefenseIncrease;
    }

    public override void ApplyEffect(Player player)
    {
        player.Defense += DefenseIncrease;
    }
}