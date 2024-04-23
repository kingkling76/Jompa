using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public Vector2 movement;
    public float time;
    public bool moved; 
    Rigidbody2D rigidbody2d;
    Vector2 move;

    //for the text box
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    int index;

    // Start is called before the first frame update
    void Start()
    {
        //make the NPC stand still for atleast 4 time units in the beginning
        movement.x = 0;
        movement.y = 0;
        moved = false;
        time = 4;

        //get the rigidbody component
        rigidbody2d = GetComponent<Rigidbody2D>();

        //index and options for the dialogue
        dialogue = new string[] { "Hej", "Barev", "Ni Hao", "Yassoo", "Namaste", "Salam", "Hola", "Merhaba", "Privet", "Zdravo" };
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    //don't want jittering, FixedUpdate has same freq as the physics system
    void FixedUpdate()
    {
        if (dialoguePanel.activeInHierarchy)
            ;
        else
            Wander();

    }

    void Wander()
    {
        //update position and count down the time
        Vector2 position = (Vector2)rigidbody2d.position + movement * 3.0f * Time.deltaTime;
        rigidbody2d.MovePosition(position);
        time -= Time.deltaTime;

        if(time <= 0) //The NPC should make a new decision
        {
            if (moved) //if the npc moved previously make him stationary for the next few units of time
            {
                moved = false;
                time = Random.Range(1, 3);
                movement.x = 0;
                movement.y = 0;
            }
            else
            {
                //set new moving time and direction, Random.Range(inclusive, exclusive)
                time = Random.Range(1, 3);
                movement.x = Random.Range(-1, 2);
                movement.y = Random.Range(-1, 2);

                if (movement.x != 0 || movement.y != 0)
                    moved = true;
            }

        }
    }

    public void Talk()
    {
        dialoguePanel.SetActive(true);
        index = Random.Range(0, 11);
        StartCoroutine(Typing());
    }

    public void ClearText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.06f);
        }
    }
}

/*TODO
 * Gör så man kan interagera med NPC
 * Dialogruta när man interagerar
 * Kanske: fixa kollisionen diagonalt med vägg, så NPCn inte "glider" längs med väggen
*/