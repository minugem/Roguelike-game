using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class HealthPowerUp : PowerUp
{
    public float HealthIncrease = 20;

    public HealthPowerUp()
    {
        Name = "Health Boost";
        Description = "Increase your health by " + HealthIncrease;
    }

    public override void ApplyEffect(Player player)
    {
        player.Health += HealthIncrease;
    }
}