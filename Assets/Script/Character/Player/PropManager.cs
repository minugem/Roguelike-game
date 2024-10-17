using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropManager : MonoBehaviour
{
    public int coinCount;
    public int equipmentCount;
    public int keyCount;
    public int potionCount;

    public bool PickupItem(GameObject obj)
    {
        switch (obj.tag)
        {
            case Constants.TAG_COIN:
                PickUpCoin();
                return true;
            case Constants.TAG_EQUIPMENT:
                PickUpEquipment();
                return true;
            case Constants.TAG_KEY:
                PickUpKey();
                return true;
            case Constants.TAG_POTION:
                PickUpPotion();
                return true;
            default:
                Debug.Log("Can't pickup");
                return false;
        }
    }


    private void OnGUI()
    {
        GUI.skin.label.fontSize = 20;
        GUI.Label(new Rect(20, 20, 200, 30), "Coins: " + coinCount);
        GUI.Label(new Rect(20, 60, 200, 30), "Equipments: " + equipmentCount);
        GUI.Label(new Rect(20, 100, 200, 30), "Keys: " + keyCount);
        GUI.Label(new Rect(20, 140, 200, 30), "Potions: " + potionCount);
    }


    private void PickUpCoin()
    {
        coinCount++;
    }
    private void PickUpEquipment()
    {
        equipmentCount++;
    }
    private void PickUpKey()
    {
        keyCount++;
    }
    private void PickUpPotion()
    {
        potionCount++;
    }


}


