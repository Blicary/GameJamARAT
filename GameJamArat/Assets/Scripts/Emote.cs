using UnityEngine;
using System.Collections;

public class Emote : MonoBehaviour 
{
    private float timer_max = 3;
    private float timer;
    private Vector2 origin;


    public void Start()
    {
        origin = new Vector2(transform.position.x, transform.position.y);
        ResetLoop();
    }

    public void Update()
    {
        if (timer <= 0)
        {
            ResetLoop();
        }
        else
        {
            timer -= Time.deltaTime;

            // movement
            transform.position = new Vector2(origin.x + 0.4f * Mathf.Sin(timer * 2f), transform.position.y + 0.9f * Time.deltaTime);
        }
    }


    public void ResetLoop()
    {
        timer = timer_max;
        transform.position = origin;
        GetComponent<SpriteRenderer>().enabled = true;
    }
	
}
