using UnityEngine;
using System.Collections.Generic;

public class PropManager : MonoBehaviour
{
    public int coinCount;
    public int equipmentCount;
    public int keyCount;
    public int potionCount;

    public Texture2D coinIcon;
    public Texture2D equipmentIcon;
    public Texture2D keyIcon;
    public Texture2D potionIcon;

    private int selectedIndex = 0;
    private List<ItemInfo> items = new List<ItemInfo>();

    private void Update()
    {
        // Handle scroll wheel input
        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
        if (scrollDelta != 0 && items.Count > 0)
        {
            selectedIndex -= Mathf.RoundToInt(scrollDelta * 10); // Adjust sensitivity as needed
            selectedIndex = Mathf.Clamp(selectedIndex, 0, items.Count - 1);
        }
    }

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
        int normalIconSize = 30;
        int selectedIconSize = 45;
        int spacing = 30;
        int yPosition = 20;

        GUI.skin.label.fontSize = 16;

        for (int i = 0; i < items.Count; i++)
        {
            ItemInfo item = items[i];
            int count = item.GetCount();
            int iconSize = (i == selectedIndex) ? selectedIconSize : normalIconSize;
            int xPosition = 20 + i * (normalIconSize + spacing);

            // Adjust position for larger selected icon
            if (i == selectedIndex)
            {
                xPosition -= (selectedIconSize - normalIconSize) / 2;
                yPosition -= (selectedIconSize - normalIconSize) / 2;
            }

            DrawItemWithCount(item.icon, count, xPosition, yPosition, iconSize);

            // Reset yPosition for next item
            if (i == selectedIndex)
            {
                yPosition += (selectedIconSize - normalIconSize) / 2;
            }
        }
    }

    private void DrawItemWithCount(Texture2D icon, int count, int x, int y, int size)
    {
        GUI.DrawTexture(new Rect(x, y, size, size), icon);
        GUI.Label(new Rect(x + size + 5, y + size / 2 - 10, 40, 20), "x" + count);
    }

    private void PickUpCoin()
    {
        coinCount++;
        if (coinCount == 1) // Add to items list only when first collected
            items.Add(new ItemInfo(coinIcon, () => coinCount));
    }

    private void PickUpEquipment()
    {
        equipmentCount++;
        if (equipmentCount == 1)
            items.Add(new ItemInfo(equipmentIcon, () => equipmentCount));
    }

    private void PickUpKey()
    {
        keyCount++;
        if (keyCount == 1)
            items.Add(new ItemInfo(keyIcon, () => keyCount));
    }

    private void PickUpPotion()
    {
        potionCount++;
        if (potionCount == 1)
            items.Add(new ItemInfo(potionIcon, () => potionCount));
    }

    private class ItemInfo
    {
        public Texture2D icon;
        public System.Func<int> GetCount;

        public ItemInfo(Texture2D icon, System.Func<int> getCount)
        {
            this.icon = icon;
            this.GetCount = getCount;
        }
    }
}