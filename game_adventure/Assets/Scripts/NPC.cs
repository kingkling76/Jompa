using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Vector2 movement;
    public float time;
    public bool moved; 
    Rigidbody2D rigidbody2d;
    Vector2 move;
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
    }

    // Update is called once per frame
    void Update()
    {
    }

    //don't want jittering, FixedUpdate has same freq as the physics system
    void FixedUpdate()
    {
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
}

/*TODO
 * Gör så man kan interagera med NPC
 * Dialogruta när man interagerar
 * Kanske: fixa kollisionen diagonalt med vägg, så NPCn inte "glider" längs med väggen
*/