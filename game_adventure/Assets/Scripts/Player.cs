using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem; //need to install package input system, window -> package manager

public class player : MonoBehaviour
{

    // Start is called before the first frame update
    public float moveSpeed; 

    public bool is_moving;

    private Vector2 move;

    public Vector3 targetPos;

    public float targetTime;

    public InputAction MoveAction;

    Rigidbody2D rigidbody2d;

    


    //private Animator animator;

    public LayerMask s;

    //public LayerMask Interactable;

    //private void Awake()
    // {
    //      animator = GetComponent<Animator>();
    // }

    public static player instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

  //need to install package input system, window -> package manager


    private bool talking;


    //private Animator animator;

    //public LayerMask solidobjectslayer;
    //public LayerMask Interactable;

    //private void Awake()
    // {
    //      animator = GetComponent<Animator>();
    // }

    //actions for talking to npcs etc
    public InputAction talkAction;
    public InputAction continueDialogue;
    NPC npc;

    void Start()
    {
        //enable talkAction and call TalkNPC when it happens
        moveSpeed = 5;

        //enable all inputaction
        talkAction.Enable();
        continueDialogue.Enable();
        MoveAction.Enable();

        talkAction.performed += TalkNPC;
        rigidbody2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void FixedUpdate()
    {
        if (talking)
            Debug.Log("HELLO");
        else
        {
            move = MoveAction.ReadValue<Vector2>();
            Vector2 position = (Vector2)transform.position + move * 3.0f * Time.deltaTime;
            rigidbody2d.MovePosition(position);
        }
    }
    /*
     * Grej för interaction med NPC
    void interact()
    {
        var facingDir = new Vector3(animator.GetFloat("move_x"), animator.GetFloat("move_y"));
        var interactpos = transform.position + facingDir;
        var collider = Physics2D.OverlapCircle(interactpos, 0.2f, Interactable);
        if (collider != null)
        {

            collider.GetComponent<interface_>().Interact(); 
        }

    }
    */

    /* IEnumerator Move(Vector3 targetPos)
     {
         is_moving = true;
         while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
         {
             //transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
             rigidbody2d.MovePosition(targetPos);
             yield return null;



         }
         //transform.position = targetPos;
         is_moving = false;

     }*/
    //obs



    private bool isWalkable(Vector3 targetPos)
    {
        //if (Physics2D.OverlapCircle(targetPos, 0.2f, solidobjectslayer | Interactable) != null)
        //{
        //    return false;

        //}
        return true;

    }

    void TalkNPC(InputAction.CallbackContext context)
    {
        //use raycasting to see if we're close enough to the NPC
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, move, 1.5f, LayerMask.GetMask("NPC"));
        //if hit (close enough)
        if (hit.collider != null)
        {
            Debug.Log("TRÄFF");
            Debug.Log("Hit: " + hit.collider.name);
            if (hit.collider.name == "NPC")
            {
                NPC npc = hit.collider.GetComponent<NPC>();
                npc.Talk();
            }

            else if (hit.collider.name == "Shopkeeper")
            {
                Debug.Log("HEJEHEJHEJHEJHEJHEJ");
                Shopkeeper sk = hit.collider.GetComponent<Shopkeeper>();
                sk.Talk();
            }
        }
    }
}
    /*
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        MoveAction.Enable();

    }




    private void FixedUpdate()
    {

        move = MoveAction.ReadValue<Vector2>();
        Vector2 position = (Vector2)transform.position + move * 3.0f * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

        // Update is called once per frame
        /*
        public void Update()
        {
            Debug.Log(is_moving);
            if (!is_moving)
            {
                input.x = Input.GetAxisRaw("Horizontal");
                input.y = Input.GetAxisRaw("Vertical");
                //Debug.Log(input.x);

                if (input != Vector2.zero)
                {
                    //animator.SetFloat("move_x", input.x);
                    //animator.SetFloat("move_y", input.y);
                    targetPos = transform.position;
                    targetPos.x += input.x;
                    targetPos.y += input.y;



                    if (isWalkable(targetPos))
                    {
                        StartCoroutine(Move(targetPos));

                    }

                    //StartCoroutine(Move(targetPos));
                }

            }
            //animator.SetBool("is_moving", is_moving);
            //if (Input.GetKeyDown(KeyCode.Z)) { interact(); }
        }*/
        /*
         * Grej för interaction med NPC
        void interact()
        {
            var facingDir = new Vector3(animator.GetFloat("move_x"), animator.GetFloat("move_y"));
            var interactpos = transform.position + facingDir;
            var collider = Physics2D.OverlapCircle(interactpos, 0.2f, Interactable);
            if (collider != null)
            {

                collider.GetComponent<interface_>().Interact(); 
            }

        }
        */
        /*
        IEnumerator Move(Vector3 targetPos)
        {
            is_moving = true;
            //while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon && is_moving == true)

            int i = 1;
            for(; i < 2;)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

                Debug.Log("Fast move");
                yield return null;


                i++;
            }
            transform.position = targetPos;
            is_moving = false;

        }
     //obs*/


        /*
           private bool isWalkable(Vector3 targetPos)
           {
               if (Physics2D.OverlapCircle(targetPos, 0.2f, s) != null) //| Interactable) != null)
               {
                   Debug.Log("falskt");
                   return false;

               }
               Debug.Log("sant");
               return true;

           }
        */
    