using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopkeeper : MonoBehaviour
{
    //for the text box
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Talk()
    {
        dialoguePanel.SetActive(true);
        index = Random.Range(0, 11);
        StartCoroutine(Typing());
    }

    //enumerator for typing
    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.06f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hello()
    {

    }
}
