using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using ItemEnum;

public class ShopManagerScript : MonoBehaviour
{

    public int[,] shopItems = new int[5,5];
    //public float coins;
    public Text CoinsTxt;
    public GameObject shop;
    public Item CoffeeItem;
    public Item BookItem;
    // Start is called before the first frame update
    void Start()
    {
        CoinsTxt.text = "Coins: " + player.instance.coins.ToString(); 
        
        //Item IDs
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;

        //Prices
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 30;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Buy()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if (player.instance.coins >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().itemID])
        {
            player.instance.coins -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().itemID];
            CoinsTxt.text = "Coins: " + player.instance.coins.ToString();
            if (buttonRef.GetComponent<ButtonInfo>().itemID == 1)
            {
                player.instance.inventory.Add(CoffeeItem);
            }
            else if (buttonRef.GetComponent<ButtonInfo>().itemID == 2)
            {
                player.instance.inventory.Add(BookItem);
            }
        }
    }

    public void ToggleShop()
    {
        if (!shop.activeInHierarchy)
        {
            shop.SetActive(true);
            CoinsTxt.gameObject.SetActive(true);
        }

        else
        {
            shop.SetActive(false);
            CoinsTxt.gameObject.SetActive(false);
            player.instance.talking = false;
        }
    }
}
