using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LevelUpUIManager : MonoBehaviour
{
    public GameObject levelUpPanel; 
    public Button attackButton;     
      
    public Button healthButton;     
   

    private Player player; 

    void Start()
    {
        
        levelUpPanel.SetActive(false);

        
        player = FindObjectOfType<Player>();

        
        attackButton.onClick.AddListener(() => ApplyAttackPowerUp());
       
        healthButton.onClick.AddListener(() => ApplyHealthPowerUp());
        
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

    
    

    
    private void ApplyHealthPowerUp()
    {
        player.IncreaseHealth(20); 
        HideUI();
    }

    
    
}