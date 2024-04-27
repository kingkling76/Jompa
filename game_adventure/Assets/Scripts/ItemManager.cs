using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ItemEnum;

public class ItemManager : MonoBehaviour
{
    public Item[] collectableItems;

    private Dictionary<CollectableType, Item> collectableItemsDict = new Dictionary<CollectableType, Item>();

    private void Awake()
    {
        foreach(Item item in collectableItems)
        {
            Debug.Log(item);
            AddItem(item);
        }
    }

    private void AddItem(Item item)
    {
        if (!collectableItemsDict.ContainsKey(item.type))
        {
            collectableItemsDict.Add(item.type, item);
        }
    }

    public Item GetItemByType(CollectableType type)
    {
        if (collectableItemsDict.ContainsKey(type))
        {
            return collectableItemsDict[type];
        }

        return null;
    }
}
