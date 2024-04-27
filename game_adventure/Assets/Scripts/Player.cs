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

    public Animator animator;

    public Inventory inventory;

    private Vector2 lastFacingDirection;

    public static player instance;

    public int MaxHealth = 100;

    public int health;

    public LayerMask s;


    private void Awake()
    {
        //inventory = new Inventory(10);
        health = MaxHealth;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    //need to install package input system, window -> package manager

    
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
            Vector2 shootingDirection = move.normalized;

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

    public void DrinkCoffee()
    {
        int coffeeIndex = FindCoffeeIndexInInventory();

        if (coffeeIndex != -1)
        {
            this.moveSpeed = this.moveSpeed * 1.25f;
            inventory.Remove(coffeeIndex);
        }
    }


    private bool talking;

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
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBook();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            DrinkCoffee();
        }
        
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
    
    void AnimateMovement(Vector3 direction)
    {
        if (animator != null)
        {
            if (direction.magnitude > 0)
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

    private int FindCoffeeIndexInInventory()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            if (inventory.slots[i].type == CollectableType.COFFEE)
            {
                return i; // Return the index of the book in the inventory
            }
        }

        // Book not found in the inventory
        return -1;
    }
    



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(10); // Adjust the amount of damage as needed
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        // Handle player death here, such as game over screen or respawn logic
    }

}
 
    