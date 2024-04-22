using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;

    private bool is_moving;

    private Vector2 input;

    public Animator animator;

    public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(21);
    }


    //public LayerMask solidobjectslayer;
    //public LayerMask Interactable;

    //private void Awake()
    // {
    //      animator = GetComponent<Animator>();
    // }

    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (!is_moving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            Debug.Log(input.x);

            Vector3 direction = new Vector3(input.x, input.y);
            AnimateMovement(direction);

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



    void AnimateMovement(Vector3 direction)
    {
        if(animator != null)
        {
            if(direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
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



    /*private bool isWalkable(Vector3 targetPos)
    {
        //if (Physics2D.OverlapCircle(targetPos, 0.2f, solidobjectslayer | Interactable) != null)
        //{
        //    return false;

        //}
        return true;

    }*/
    private bool isWalkable(Vector3 targetPos)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(targetPos, 0.2f);
        foreach (Collider2D collider in colliders)
        {
            // Check if the collider belongs to a solid object
            if (collider.CompareTag("Solid"))
            {
                return false;
            }
        }
        return true;
    }

}