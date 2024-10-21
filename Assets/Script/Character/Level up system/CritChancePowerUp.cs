using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CritChancePowerUp : PowerUp
{
    public float CritChanceIncrease = 0.05f;

    public CritChancePowerUp()
    {
        Name = "Critical Chance Boost";
        Description = "Increase your critical hit chance by " + (CritChanceIncrease * 100) + "%";
    }

    public override void ApplyEffect(Player player)
    {
        player.CritChance += CritChanceIncrease;
    }
}