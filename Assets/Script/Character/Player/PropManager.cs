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

        // Handle right-click to use item
        if (Input.GetMouseButtonDown(1) && items.Count > 0)
        {
            UseSelectedItem();
        }
    }

    private void UseSelectedItem()
    {
        if (selectedIndex >= 0 && selectedIndex < items.Count)
        {
            ItemInfo selectedItem = items[selectedIndex];
            int currentCount = selectedItem.GetCount();

            if (currentCount > 0)
            {
                // Decrease the count
                selectedItem.DecreaseCount();

                // Print the usage message
                Debug.Log($"Used: {selectedItem.name}");

                // Remove the item from the list if count reaches 0
                if (selectedItem.GetCount() == 0)
                {
                    items.RemoveAt(selectedIndex);
                    if (selectedIndex >= items.Count)
                    {
                        selectedIndex = items.Count - 1;
                    }
                }
            }
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
        int padding = 10;
        int upwardShift = 5; 

        GUI.skin.label.fontSize = 16;

        // Calculate total width of all items
        float totalWidth = (items.Count - 1) * (normalIconSize + spacing) + selectedIconSize;

        // Calculate starting X position to center the items
        float startX = (Screen.width - totalWidth) / 2;

        // Calculate Y position (moved up by upwardShift)
        float startY = Screen.height - normalIconSize - padding - upwardShift;

        for (int i = 0; i < items.Count; i++)
        {
            ItemInfo item = items[i];
            int count = item.GetCount();
            int iconSize = (i == selectedIndex) ? selectedIconSize : normalIconSize;

            float xPosition = startX + i * (normalIconSize + spacing);
            float yPosition = startY;

            // Adjust position for larger selected icon
            if (i == selectedIndex)
            {
                xPosition -= (selectedIconSize - normalIconSize) / 2;
                yPosition -= (selectedIconSize - normalIconSize);
            }

            DrawItemWithCount(item.icon, count, (int)xPosition, (int)yPosition, iconSize);
        }
    }
    private void DrawItemWithCount(Texture2D icon, int count, int x, int y, int size)
    {
        GUI.DrawTexture(new Rect(x, y, size, size), icon);
        int labelOffset = 10;
        GUI.Label(new Rect(x, y + size - labelOffset, size, 20), "x" + count);
    }

    private void PickUpCoin()
    {
        coinCount++;
        if (coinCount == 1)
            items.Add(new ItemInfo("Coin", coinIcon, () => coinCount, () => coinCount--));
    }

    private void PickUpEquipment()
    {
        equipmentCount++;
        if (equipmentCount == 1)
            items.Add(new ItemInfo("Equipment", equipmentIcon, () => equipmentCount, () => equipmentCount--));
    }

    private void PickUpKey()
    {
        keyCount++;
        if (keyCount == 1)
            items.Add(new ItemInfo("Key", keyIcon, () => keyCount, () => keyCount--));
    }

    private void PickUpPotion()
    {
        potionCount++;
        if (potionCount == 1)
            items.Add(new ItemInfo("Potion", potionIcon, () => potionCount, () => potionCount--));
    }

    private class ItemInfo
    {
        public string name;
        public Texture2D icon;
        public System.Func<int> GetCount;
        public System.Action DecreaseCount;

        public ItemInfo(string name, Texture2D icon, System.Func<int> getCount, System.Action decreaseCount)
        {
            this.name = name;
            this.icon = icon;
            this.GetCount = getCount;
            this.DecreaseCount = decreaseCount;
        }
    }
}