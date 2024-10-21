using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public abstract class PowerUp : MonoBehaviour
{
    public string Name;
    public string Description;

    public abstract void ApplyEffect(Player player);
}