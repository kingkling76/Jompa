using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public player player;
    public List<Slots_UI> slots = new List<Slots_UI>();
    

    void Start()
    {
        inventoryPanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Refresh();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }

    public void Refresh()
    {

        if (slots.Count == player.instance.inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if(player.instance.inventory.slots[i].type != CollectableType.NONE)
                {
                    slots[i].SetItem(player.instance.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

    public void Remove(int slotID)
    {
        Item itemToDrop = GameManager.instance.itemManager.GetItemByType(player.instance.inventory.slots[slotID].type);

        if(itemToDrop != null)
        {
            player.instance.DropItem(itemToDrop);
            player.instance.inventory.Remove(slotID);
            Refresh();
        }

    }
}
