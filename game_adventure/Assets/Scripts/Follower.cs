using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    //public player player;
    public float followDistance = 2f; // Adjust this value as needed


    private void Start()
    {
        transform.position = (Vector2)player.instance.transform.position + new Vector2(followDistance - 1, followDistance - 1);
    }
    void Update()
    {
        Vector2 targetPosition = player.instance.transform.position;

        Vector2 direction = targetPosition - (Vector2)transform.position;

        float distance = direction.magnitude;

        if (distance > followDistance)
        {
            if(distance > 10)
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, player.instance.moveSpeed * 100 * Time.deltaTime);
            else
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, player.instance.moveSpeed * Time.deltaTime);
        }
       else if (distance < 1.5)
        {
            // If the follower is too close, move away from the player
            Vector2 awayFromPlayer = (Vector2)transform.position - targetPosition;
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + awayFromPlayer, player.instance.moveSpeed * Time.deltaTime);
        }
    }
}

