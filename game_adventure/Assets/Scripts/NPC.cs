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
    [SerializeField]
    public string[] dialogue;

    int index_dialog = 0;

    //InputActions for button presses
    public InputAction continueTalking;

    //for different behavior
    [SerializeField]
    NPCType type;

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
            else if(type == NPCType.QUEST1 && index_dialog < dialogue.Length)
            {


                rigidbody2d.transform.position = Vector2.MoveTowards(transform.position, player.instance.transform.position - new Vector3(0,1,0), 2 * Time.deltaTime);
                animator.SetBool("IsWalking", true);

                if((rigidbody2d.transform.position - player.instance.transform.position).magnitude < 1.2)
                {
                    animator.SetBool("IsWalking", false);

                    Talk();

                }
            }
            else if (type == NPCType.QUEST1 && index_dialog == dialogue.Length)
            {
                type = NPCType.MOVING;
                player.instance.MoveAction.Enable();
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
        Debug.Log(index_dialog);
        if (dialoguePanel.activeInHierarchy)
            return;
        dialoguePanel.SetActive(true);
        StartCoroutine(Typing());
        index_dialog = index_dialog + 1;
    }

    public void ClearText()
    {
        dialogueText.text = "";
    }

    IEnumerator Typing()
    {
        if (index_dialog == dialogue.Length) index_dialog = 0;
        else
        {
            foreach (char letter in dialogue[index_dialog].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.06f);

            }
        }

    }

    void StopTalking(InputAction.CallbackContext context)
    {
        //if the panel is open, close it and clear text 
        if (dialoguePanel.activeInHierarchy)
        {
            if(index_dialog < dialogue.Length)
            {
                ClearText();
                Typing();
                //index_dialog++;
                Debug.Log(index_dialog);
            }
            else
            {
                Debug.Log("jshs");
                player.instance.talking = false;
                ClearText();
                dialoguePanel.SetActive(false);
            }
        }
        else
        {
            return;
        }
    }
}

public enum NPCType
{
    MOVING, STATIC, QUEST1
}

/*TODO
 * G�r s� man kan interagera med NPC
 * Dialogruta n�r man interagerar
 * Kanske: fixa kollisionen diagonalt med v�gg, s� NPCn inte "glider" l�ngs med v�ggen
*/