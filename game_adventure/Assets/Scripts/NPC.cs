using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Vector2 movement;
    public int time;
    // Start is called before the first frame update
    void Start()
    {
        movement.x = 0;
        movement.y = 0;
        time = 4; //make the NPC stand still for atleast 4 time units in the beginning
    }

    // Update is called once per frame
    void Update()
    {
        Wander();
    }

    void Wander()
    {
        Vector2 pos = transform.position;
        pos.x += movement.x * 3 * Time.deltaTime;
        pos.y += movement.y * 3 * Time.deltaTime;
        transform.position = pos;
        time--;
        if(time == 0) //The NPC should make a new decision
        {
            time = Random.Range(1, 5); //new moving time
            //choose new direction to move
            movement.x = Random.Range(-1, 1);
            movement.y = Random.Range(-1, 1);

        }
    }
}
