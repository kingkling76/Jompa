using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopkeeper : MonoBehaviour
{
    //for the text box
    public GameObject Shop;
    public Text ShopText;
    public string[] dialogue;
    public GameObject Manager;
    //
    // Start is called before the first frame update
    void Start()
    {
        dialogue = new string[] { "Hello, I'm Kling" };
    }

    public void Talk()
    {
        Shop.SetActive(true);
        StartCoroutine(Typing());
    }

    //enumerator for typing
    IEnumerator Typing()
    {
        foreach (char letter in dialogue[0].ToCharArray())
        {
            ShopText.text += letter;
            yield return new WaitForSeconds(0.06f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShopUI()
    {
        Manager.GetComponent<ShopManagerScript>().ToggleShop();
    }
}
