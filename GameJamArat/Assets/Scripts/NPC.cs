﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC : MonoBehaviour 
{
    public GOD god; // ref to the god

    public string ID_name;
    private List<string> tags = new List<string>();

    public float move_speed;
    private Vector2 target_pos;

    private float listen_percent = 0.0f;



    // PRIVATE MODIFIERS
    private void UpdateListenArea()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, god.max_radius * listen_percent);
        //Debug.Log(col.Length);
        for (int i = 0; i < col.Length; ++i)
        {
            WorldComponent wc = col[i].gameObject.GetComponent<WorldComponent>();
            if (wc != null)
            {
                wc.TurnOn();
            }

        }
    }


    // PUBLIC MODIFIERS
    public void LateUpdate()
    {
        UpdateListenArea();
    }

    public void Move(Vector2 dest)
    {
        //...
    }

    public void ModifyListen(float amount)
    {
        
        listen_percent += amount;
        UpdateListenArea();
        Debug.Log(listen_percent);
    }

    // PUBLIC ACCESSORS
    public bool HasTag(string tag) { return tags.Contains(tag); }
    public float GetListen() { return listen_percent; }

    //EVENTS
    public void OnMouseEnter()
    {
        god.SetActiveNPC(this);
    }

    public void OnMouseExit()
    {
        god.ClearActiveNPC();
    }

}
