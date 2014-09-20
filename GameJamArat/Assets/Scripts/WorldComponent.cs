using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class WorldComponent : MonoBehaviour 
{
    public List<string> tags = new List<string>();

    private float live_time_max = 2;
    private float live_time;

    

    // PUBLIC MODIFIERS
    public void Start()
    {
        live_time = live_time_max;
    }

    public void Update()
    {
        // time before fizzles out
        if (live_time >= 0)
        {
            live_time -= Time.deltaTime;
        }
        else
        {
            TurnOff();
        }
    }

    public void TurnOn()
    {
        live_time = live_time_max;
        gameObject.renderer.enabled = true;
    }
    public void TurnOff()
    {
        live_time = 0;
        gameObject.renderer.enabled = false;
    }

    // PUBLIC ACCESSORS
    public bool IsOn() { return gameObject.activeInHierarchy; }
    public bool HasTag(string tag) { return tags.Contains(tag); }
}
