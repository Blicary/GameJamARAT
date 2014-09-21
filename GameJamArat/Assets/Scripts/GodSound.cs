using UnityEngine;
using System.Collections;

public class GodSound : MonoBehaviour 
{
    public GOD god;

    public AudioSource music_see_more; // when more dark
    public AudioSource music_see_less;  // when less dark


    public void Start()
    {
        music_see_more.Play();
        music_see_less.Play();
    }
    public void Update()
    {
        
        music_see_more.volume = 1.0f - god.listen_avail;
        music_see_less.volume = 1;

        Debug.Log(god.listen_avail);
    }
	
}
