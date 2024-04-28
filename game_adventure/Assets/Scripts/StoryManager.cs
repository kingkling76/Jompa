using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager instance { get; private set; }
    public bool Quest1started;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
    }

    void Update()
    {
        
    }

    public void Quest1()
    {
        player.instance.animator.SetFloat("X", 0);
        player.instance.animator.SetFloat("Y", -1);

        player.instance.MoveAction.Disable();



    }

}
