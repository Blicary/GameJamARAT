using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC : MonoBehaviour 
{
    public GOD god; // ref to the god

    public string ID_name;
    private List<string> tags = new List<string>();

    private float move_speed = 10.0f;
    private Vector2 target_pos;
    private Vector2 start_pos;
    private float fraction_speed;
    private float start_time;
    private float travel_distance;
    private bool is_moving = false;

    private float listen_percent = 0.0f;
    private bool selected = false;

    private CursorController cursor_controller;


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
    public void Start()
    {
        // get cursor controller
        GameObject go = GameObject.Find("CursorController");
        if (go != null)
        {
            cursor_controller = go.GetComponent<CursorController>();
        }
    }

    public void Update()
    {
        if (is_moving)
        {
            UpdatePosition();
        }
    }

    public void LateUpdate()
    {
        UpdateListenArea();
        UpdateHypotheticalListenArea();
    }

    public void Move(Transform dest) // Call this during scripting to move the nPC to a location.
    {
        start_time = Time.time;
        target_pos = new Vector2(dest.position.x,dest.position.y);
        is_moving = true;
        start_pos = transform.position;
        travel_distance = Vector2.Distance(start_pos, target_pos);
    }

    private void UpdatePosition() // The NPC uses this to execute actual movement.
    {
        Debug.Log((Time.time-start_time)*move_speed);
        float dist_covered = (Time.time - start_time) * move_speed;
        float fracJourney = dist_covered / travel_distance;
        if (fracJourney < 1)
        {
            transform.position = Vector2.Lerp(start_pos, target_pos, fracJourney);
        }
        else
        {
            is_moving = false;
        }
    }

    public void ModifyListen(float amount)
    {
        
        listen_percent = amount;
        UpdateListenArea();
        //Debug.Log(listen_percent);
    }


    // PUBLIC ACCESSORS
    public bool HasTag(string tag) { return tags.Contains(tag); }
    public float GetListen() { return listen_percent; }
    public bool AwareOfObject(WorldComponent obj)
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, obj.transform.position);
        
        float dist = Vector2.Distance(transform.position, obj.transform.position);
        //Debug.Log("hit dist " + hit.distance);
        //Debug.Log("vision radius " + god.max_radius * listen_percent);

        if (hit != null)
        {
            float vision_radius = god.max_radius * listen_percent;
            if (vision_radius >= dist) return true;
        }
        return false;
    }
    public bool AwareOfNPC(NPC npc)
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, npc.transform.position);

        float dist = Vector2.Distance(transform.position, npc.transform.position);
        //Debug.Log("hit dist " + hit.distance);
        //Debug.Log("vision radius " + god.max_radius * listen_percent);

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
        god.SetHoveredNPC(this);
        cursor_controller.SetHover();
    }

    public void OnMouseExit()
    {
        god.ClearHoveredNPC();
        cursor_controller.SetNormal();
    }

}
