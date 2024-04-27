
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----source------")]
    [SerializeField] AudioSource music;

    //[SerializeField] AudioSource sfx;

    [Header("-----clips------")]

    public AudioClip main_music;

    public AudioClip dungeon;


    private void Start()
    {
        music.clip = main_music;
        music.Play();
    }
    public void Update()
    {
        
    }

}
