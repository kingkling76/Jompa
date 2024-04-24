using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed;

    private bool is_moving;

    private Vector2 input;

    public Animator animator;

    public Inventory inventory;

    private Vector2 lastFacingDirection;

    public static player instance;


    private void Awake()
    {
        inventory = new Inventory(10);

        //Singelton pattern
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DropItem(Item item)
    {
        Vector2 spawnLocation = transform.position;

        Vector2 spawnOffset = Random.insideUnitCircle + Vector2.one;

        Item droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);

        droppedItem.rb2d.AddForce(spawnOffset * .2f, ForceMode2D.Impulse);

    }

    public void ShootBook()
    {
        int bookIndex = FindBookIndexInInventory();

        if (bookIndex != -1)
        {
            Vector2 shootingDirection = input.normalized;

            // If the player is not moving, use the last facing direction
            if (shootingDirection == Vector2.zero)
            {
                shootingDirection = lastFacingDirection.normalized;
            }

            if (shootingDirection != Vector2.zero)
            {
                Vector2 spawnLocation = transform.position;
                Vector2 spawnOffset = shootingDirection * 1.5f;

                Item book_shot = GameManager.instance.itemManager.GetItemByType(CollectableType.BOOK);
                Item shootBook = Instantiate(book_shot, spawnLocation + spawnOffset, Quaternion.identity);

                //shootBook.GetComponent<Collider2D>().isTrigger = false;
                shootBook.tag = "ShotBook";

                shootBook.rb2d.AddForce(shootingDirection * 5, ForceMode2D.Impulse);

                inventory.Remove(bookIndex);
            }
        }
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBook();
        }
        if (!is_moving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            //Debug.Log(input.x);

            Vector3 direction = new Vector3(input.x, input.y);
            AnimateMovement(direction);

            if (input != Vector2.zero)
            {
                //animator.SetFloat("move_x", input.x);
                //animator.SetFloat("move_y", input.y);
                lastFacingDirection = input.normalized;

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

    private int FindBookIndexInInventory()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            if (inventory.slots[i].type == CollectableType.BOOK)
            {
                return i; // Return the index of the book in the inventory
            }
        }

        // Book not found in the inventory
        return -1;
    }

}