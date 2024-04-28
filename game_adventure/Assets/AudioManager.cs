
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public player player;
    public static AudioManager instance_a; //{ get; private set; }
    private void Awake()
    {


        //Singelton pattern
        if (instance_a == null)
        {
            instance_a = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }



     [Header("-----source------")]
    [SerializeField] AudioSource music;

    //[SerializeField] AudioSource sfx;

    [Header("-----clips------")]

    public AudioClip main_music;

    public AudioClip dungeon;

    public AudioClip boss;


    private void Start()
    {
        music.clip = main_music;
        music.Play();
    }

    public void change_music()
    {
        if(player.instance.is_in_dungeon==true)
        {
            music.Stop();
            music.clip = dungeon;
            music.Play();

        }
        if (player.instance.is_in_dungeon == false)
        {
            music.Stop();
            music.clip = main_music;
            music.Play();

        }
        if (player.instance.is_in_boss == true)
        {

            music.Stop();
            music.clip = boss;
            music.Play();
        }
    }
    

}
