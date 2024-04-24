using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;

    public bool is_moving;

    private Vector2 input;

    public Vector3 targetPos;

    public float targetTime;


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
    void Start()
    {

    }

    // Update is called once per frame
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
        //while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon && is_moving == true)

        int i = 10;
        for(; i < 100;)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

            Debug.Log("Fast move");
            yield return null;


            i++;
        }
        transform.position = targetPos;
        is_moving = false;

    }
 //obs


 
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
}