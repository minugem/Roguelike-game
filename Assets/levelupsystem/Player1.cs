using UnityEngine;

public class Player1 : MonoBehaviour
{
    
    private int attackPower;
    private int defense;
    private int health;
    private int critChance;

    public float Attack { get; internal set; }
    public float Defense { get; internal set; }
    public float Health { get; internal set; }
    public float CritChance { get; internal set; }

    private void Start()
    {
        attackPower = 10; 
        defense = 5;      
        health = 100;     
        critChance = 10;  
    }

    public void AttackIncrease(int amount)
    {
        attackPower += amount;
        Debug.Log("Attack Power increased by " + amount + ". New Attack Power: " + attackPower);
        
    }

    
    public void DefenseIncrease(int amount)
    {
        defense += amount;
        Debug.Log("Defense increased by " + amount + ". New Defense: " + defense);
        
    }

    
    public void HealthIncrease(int amount)
    {
        health += amount;
        Debug.Log("Health increased by " + amount + ". New Health: " + health);
       
    }

    
    public void CritChanceIncrease(int amount)
    {
        critChance += amount;
        Debug.Log("Crit Chance increased by " + amount + ". New Crit Chance: " + critChance);
        
    }

   
    public string GetStatus()
    {
        return $"Attack Power: {attackPower}, Defense: {defense}, Health: {health}, Crit Chance: {critChance}%";
    }
}