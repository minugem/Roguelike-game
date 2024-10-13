using UnityEngine;
using UnityEngine.UI;

public class LevelUpUIManager : MonoBehaviour
{
    public Button attackPowerUpButton;
    public Button defensePowerUpButton;
    public Button healthPowerUpButton;
    public Button critChancePowerUpButton;

    private Player1 player1;

    void Start()
    {
        player1 = FindObjectOfType<Player1>();


        attackPowerUpButton.onClick.AddListener(() => SelectAbility("AttackPower"));
        defensePowerUpButton.onClick.AddListener(() => SelectAbility("DefensePower"));
        healthPowerUpButton.onClick.AddListener(() => SelectAbility("HealthPower"));
        critChancePowerUpButton.onClick.AddListener(() => SelectAbility("CritChancePower"));
    }


    void SelectAbility(string ability)
    {
        switch (ability)
        {
            case "AttackPower":
                player1.AttackIncrease(5);
                break;
            case "DefensePower":
                player1.DefenseIncrease(3);
                break;
            case "HealthPower":
                player1.HealthIncrease(20);
                break;
            case "CritChancePower":
                player1.CritChanceIncrease(10);
                break;
        }


        gameObject.SetActive(false);
    }


    public void ShowUI()
    {
        gameObject.SetActive(true);
    }
}