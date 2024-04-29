
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
    [SerializeField] AudioSource sfx;


    //[SerializeField] AudioSource sfx;

    [Header("-----clips------")]

    public AudioClip main_music;

    public AudioClip dungeon;

    public AudioClip boss;

    public AudioClip penn;

    public AudioClip book;

    public AudioClip kaffe;

    public AudioClip door;


    private void Start()
    {
        music.clip = main_music;
        music.Play();
        sfx.volume = Mathf.Clamp01(0.1f);
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
    public void do_clip_penn()
    {
        sfx.PlayOneShot(penn);


    }
    public void do_clip_book()
    {
        sfx.PlayOneShot(book);


    }
    public void do_clip_coffee()
    {
        sfx.PlayOneShot(kaffe);


    }
    public void do_clip_door()
    {
        sfx.PlayOneShot(door);


    }

}
