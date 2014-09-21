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

    public float listen_percent;



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
        Debug.Log(listen_percent);
        listen_percent += amount;
        UpdateListenArea();
    }

    // PUBLIC ACCESSORS
    public bool HasTag(string tag) { return tags.Contains(tag); }
    public float GetListen() { return listen_percent; }

    //EVENTS
    public void OnMouseEnter()
    {
        god.Set_Active_NPC(this);
    }

    public void OnMouseExit()
    {
        god.Clear_Active_NPC();
    }

}
