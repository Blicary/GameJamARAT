using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Time;

public class NPC : MonoBehaviour 
{
    public float move_speed;
    private Vector2 target_pos;

    
    public string ID_name;
    private List<string> tags = new List<string>();

    //public string aspiration;


    // PUBLIC MODIFIERS
    public void Move(Vector2 dest)
    {
        Vector2.Distance(dest, transform.position);

    }
    
    // PUBLIC ACCESSORS
    public bool HasTag (string tag) { return tags.Contains(tag); }
}
