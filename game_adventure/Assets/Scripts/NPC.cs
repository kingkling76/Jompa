using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem; //need to install package input system, window -> package manager


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
    public string[] dialogue_2;
    public string[] dialogue_3;
    public string[] dialogue_4;
    public string[] dialogue_5;
    public string[] dialogue_6;
    public string[] dialogue_7;
    public string[] dialogue_8;
    public string[] dialogue_9;
    public string[] dialogue_10;
    public string[] dialogue_11;

    public static int SpecialNPC_index = 0;
    public static int CrossroadNPC_index = 0;
    public static int ProstNPC_index= 0;
    public static int MiddleNPC_index = 0;
    public static int PressisNPC_index = 0;
    public static int KungNPC_index = 0;
    public static int LongNPC_index = 0;
    public static int LinusNPC_index = 0;
    public static int DagNPC_index = 0;
    public static int AssistentNPC_index = 0;

    int index;

    //InputActions for button presses
    public InputAction continueTalking;

    //for different behavior
    [SerializeField]
    NPCType type = NPCType.MOVING;

    //animator
    private Animator animator;

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
        dialogue_2 = new string[] { "Hassan: Har du hört om den försvunna professorn?", "Skuggan: Han är ändå helt värdelös", "Hassan: Du ser trött ut ", "Skuggan: Lyssna inte på han"};
        dialogue_3 = new string[] { "Proseten: play it cool, gå till kyrkan och rena din själ", "Skuggan: Gå bara åt höger, strunta i det där" };
        dialogue_4 = new string[] { "Vilsen student: Har du varit på Pressis?", "Vilsen student: Gå bara uppåt" };
        dialogue_5 = new string[] { "Väpnaren Jöns: Dom behöver dig på Örebro Slott!", "Skuggan: Alla dessa distraktioner, gå bara tillbaka!", "Väpnare Jöns: Gå bara åt höger så kommer du dit" };
        dialogue_6 = new string[] { "Klas: Skumma grejjer pågår i T-husets källare", "Klas: Du råkar inte veta något om det?", "Skuggan: Riktig BS" };
        dialogue_7 = new string[] { "Linus: SLÄPP IN MIG!!!!", "Linus: Jag missar min tenta, HJÄLP MIG!", "Linus: Kan du ta sönder dörren?", "Skuggan: Det är nog bäst att du hjälper honom", "Linus: Tack!" };
        dialogue_8 = new string[] { "Dag: Jag har glömt koden till teknikmuseet", "Dag: Jag verkar vara ett instabilt system", "Dag: Någon student borde kanske komma ihåg koden" };
        dialogue_9 = new string[] { "Pär präst: Du städar upp din egna röra men tack", "Skuggan: Struntprat" };
        dialogue_10 = new string[] { "Kungen: Det är du ditt kräk! Försvinn!!", "Skuggan: Han vet inte vad han pratar om" };
        dialogue_11 = new string[] { "Välkommen tillbaka kungen", "Skuggan: Det är fullbordat..." };



        index = 0;

        //enable input actions
        continueTalking.Enable();

        //bind input actions to functions
        continueTalking.performed += StopTalking;

        //Animator
        animator = GetComponent<Animator>();
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
        {
            if (type == NPCType.MOVING)
            {
                Wander();
            }


        }
    }

    void Wander()
    {
        //update position and count down the time
        Vector2 position = (Vector2)rigidbody2d.position + movement * 3.0f * Time.deltaTime;
        rigidbody2d.MovePosition(position);
        time -= Time.deltaTime;

        if (time <= 0) //The NPC should make a new decision
        {
            if (moved) //if the npc moved previously make him stationary for the next few units of time
            {
                moved = false;
                time = Random.Range(1, 3);
                movement.x = 0;
                movement.y = 0;

                //set animation to false
                animator.SetBool("IsWalking", false);
            }
            else
            {
                //set new moving time and direction, Random.Range(inclusive, exclusive)
                time = Random.Range(1, 3);
                movement.x = Random.Range(-1, 2);
                movement.y = Random.Range(-1, 2);

                if (movement.x != 0 || movement.y != 0)
                {
                    moved = true;
                    animator.SetFloat("X", movement.x);
                    animator.SetFloat("Y", movement.y);
                    animator.SetBool("IsWalking", true);
                }
                else
                    animator.SetBool("IsWalking", false);
            }

        }
    }

    public void Talk()
    {
        Debug.Log("NPC TALK HAS BEEN CALLED\n");
        if (dialoguePanel.activeInHierarchy)
            return;
        dialoguePanel.SetActive(true);
        index = Random.Range(0, 10);
        if (tag == "Special_NPC")
        {
            //index = Random.Range(0, 2);
            index = SpecialNPC_index;
            SpecialNPC_index++;
            if(index == 3)
            {
                SpecialNPC_index = 0;
            }
        }
        if(tag == "Crossroads_NPC")
        {
            index = CrossroadNPC_index;
            CrossroadNPC_index++;
            if(index == 1) CrossroadNPC_index = 0;
        }
        if(tag == "Middle_NPC")
        {
            index = MiddleNPC_index;
            MiddleNPC_index++;
            if(index == 1) MiddleNPC_index = 0;

        }
        if (tag == "Pressis_NPC")
        {
            index = PressisNPC_index;
            PressisNPC_index++;
            if(index == 2) PressisNPC_index = 0;

        }
        if (tag == "Long_NPC")
        {
            index = LongNPC_index;
            LongNPC_index++;
            if(index ==2) LongNPC_index = 0;

        }
        if (tag == "Linus")
        {
            if (player.instance.HasHelpedLinus)
            {
                index = 4;
            }
            else
            {
                index = LinusNPC_index;
                LinusNPC_index++;
                if (index == 3) LinusNPC_index = 0;
            }

        }
        if (tag == "Dag")
        {
            index = DagNPC_index;
            DagNPC_index++;
            if(index == 2) DagNPC_index = 0;

        }
        if (tag == "prost")
        {
            index = ProstNPC_index;
            ProstNPC_index++;
            if(index == 1) ProstNPC_index = 0;

        }
        if (tag == "Kung")
        {
            index = KungNPC_index;
            KungNPC_index++;
            if(index == 1) KungNPC_index = 0;

        }
        if (tag == "assistent")
        {
            index = AssistentNPC_index;
            AssistentNPC_index++;
            if(index == 1) AssistentNPC_index = 0;

        }

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
        if (tag == "Special_NPC")
        {
            foreach (char letter in dialogue_2[index].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.03f);
            }
        }
        else if(tag == "Crossroads_NPC")
        {
            foreach (char letter in dialogue_3[index].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.03f);
            }
        }
        else if (tag == "Middle_NPC")
        {
            foreach (char letter in dialogue_4[index].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.03f);
            }
        }
        else if (tag == "Pressis_NPC")
        {
            foreach (char letter in dialogue_5[index].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.03f);
            }
        }
        else if (tag == "Long_NPC")
        {
            foreach (char letter in dialogue_6[index].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.03f);
            }
        }
        else if (tag == "Linus")
        {
            foreach (char letter in dialogue_7[index].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.03f);
            }
        }
        else if (tag == "Dag")
        {
            foreach (char letter in dialogue_8[index].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.03f);
            }
        }
        else if (tag == "prost")
        {
            foreach (char letter in dialogue_9[index].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.03f);
            }
        }
        else if (tag == "Kung")
        {
            foreach (char letter in dialogue_10[index].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.03f);
            }
        }
        else if (tag == "assistent")
        {
            foreach (char letter in dialogue_11[index].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.03f);
            }
        }
        else
        {
            foreach (char letter in dialogue[index].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.03f);
            }
        }
    }

    void StopTalking(InputAction.CallbackContext context)
    {
        //if the panel is open, close it and clear text 
        if (dialoguePanel.activeInHierarchy)
        {
            player.instance.talking = false;
            ClearText();
            index = 0;
        }
        else
            return;
    }
}

public enum NPCType
{
    MOVING, STATIC
}

/*TODO
 * G�r s� man kan interagera med NPC
 * Dialogruta n�r man interagerar
 * Kanske: fixa kollisionen diagonalt med v�gg, s� NPCn inte "glider" l�ngs med v�ggen
*/