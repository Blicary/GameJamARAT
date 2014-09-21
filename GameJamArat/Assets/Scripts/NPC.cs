using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC : MonoBehaviour 
{
    public GOD god; // ref to the god

    public string ID_name;
    private List<string> tags = new List<string>();

    public float move_speed;
    private Vector2 target_pos;

    private float listen_percent = 0.5f;


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
    private void UpdateHypotheticalListenArea()
    {
        if (this != god.GetActiveNPC()) return;

        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, god.GetHypotheticalPercent() * god.max_radius);
        //Debug.Log(col.Length);
        for (int i = 0; i < col.Length; ++i)
        {
            WorldComponent wc = col[i].gameObject.GetComponent<WorldComponent>();
            if (wc != null)
            {
                wc.TurnOn();
                wc.SetColored(true);
            }

        }
    }


    // PUBLIC MODIFIERS
    public void LateUpdate()
    {
        UpdateListenArea();
        UpdateHypotheticalListenArea();
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
    public bool AwareOfObject(WorldComponent obj)
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, obj.transform.position);
        
        float dist = Vector2.Distance(transform.position, obj.transform.position);
        Debug.Log("hit dist " + hit.distance);
        Debug.Log("vision radius " + god.max_radius * listen_percent);

        if (hit != null)
        {
            float vision_radius = god.max_radius * listen_percent;
            if (vision_radius >= dist) return true;
        }
        return false;
    }


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
