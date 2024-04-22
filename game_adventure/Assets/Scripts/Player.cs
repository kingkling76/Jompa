using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //need to install package input system, window -> package manager

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;

    private bool is_moving;

    private Vector2 input;

    Rigidbody2D rigidbody2d;


    //private Animator animator;

    //public LayerMask solidobjectslayer;
    //public LayerMask Interactable;

    //private void Awake()
    // {
    //      animator = GetComponent<Animator>();
    // }

    public InputAction talkAction; //action for talking to npcs

    void Start()
    {
        //enable talkAction and call TalkNPC when it happens
        moveSpeed = 5;
        talkAction.Enable();
        talkAction.performed += TalkNPC;
        rigidbody2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    public void Update()
    {
        if (!is_moving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input != Vector2.zero)
            {
                //animator.SetFloat("move_x", input.x);
                //animator.SetFloat("move_y", input.y);
                var targetPos = transform.position;
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

    IEnumerator Move(Vector3 targetPos)
    {
        is_moving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;



        }
        transform.position = targetPos;
        is_moving = false;

    }
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
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, input, 1.5f, LayerMask.GetMask("NPC"));
        //if hit (close enough)
        if (hit.collider != null)
        {
            Debug.Log("Raycast has hit the object " + hit.collider.gameObject);

        }
    }
}
