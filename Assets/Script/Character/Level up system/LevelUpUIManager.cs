using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LevelUpUIManager : MonoBehaviour
{
    public GameObject levelUpPanel; 
    public Button attackButton;     
    public Button defenseButton;    
    public Button healthButton;     
    public Button critChanceButton; 

    private Player player; 

    void Start()
    {
        
        levelUpPanel.SetActive(false);

        
        player = FindObjectOfType<Player>();

        
        attackButton.onClick.AddListener(() => ApplyAttackPowerUp());
        defenseButton.onClick.AddListener(() => ApplyDefensePowerUp());
        healthButton.onClick.AddListener(() => ApplyHealthPowerUp());
        critChanceButton.onClick.AddListener(() => ApplyCritChancePowerUp());
    }

    
    public void ShowUI()
    {
        levelUpPanel.SetActive(true);
    }

    
    public void HideUI()
    {
        levelUpPanel.SetActive(false);
    }

    
    private void ApplyAttackPowerUp()
    {
        player.IncreaseAttackPower(5); 
        HideUI(); 
    }

    
    private void ApplyDefensePowerUp()
    {
        player.IncreaseDefense(3); 
        HideUI();
    }

    
    private void ApplyHealthPowerUp()
    {
        player.IncreaseHealth(20); 
        HideUI();
    }

    
    private void ApplyCritChancePowerUp()
    {
        player.IncreaseCritChance(5); 
        HideUI();
    }
}