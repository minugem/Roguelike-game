using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public string Name;
    public string Description;

    public abstract void ApplyEffect(Player1 player);
}