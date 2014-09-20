using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC : MonoBehaviour 
{
    public string ID_name;
    private List<string> tags = new List<string>();

    public float move_speed;
    private Vector2 target_pos;

    public float listen_percent;



    // PRIVATE MODIFIERS
    private void UpdateListenArea()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, 10, 9);
        for (int i = 0; i < col.Length; ++i)
        {
            WorldComponent wc = col[i].gameObject.GetComponent<WorldComponent>();
            wc.TurnOn();
        }
    }


    // PUBLIC MODIFIERS
    public void Update()
    {
        UpdateListenArea();
    }

    public void Move(Vector2 dest)
    {
        //...
    }

    public void IncreaseListen(float amount)
    {
        listen_percent += amount;
        UpdateListenArea();
    }
    public void DecreaseListen(float amount)
    {
        listen_percent -= amount;
        UpdateListenArea();
    }

    // PUBLIC ACCESSORS
    public bool HasTag(string tag) { return tags.Contains(tag); }
    public float GetListen() { return listen_percent; }
}
