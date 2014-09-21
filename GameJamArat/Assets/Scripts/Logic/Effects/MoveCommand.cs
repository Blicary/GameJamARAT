using UnityEngine;
using System.Collections;


public class MoveCommand : Effect 
{

    public NPC subject_NPC;             // The npc who will be moving.
    public Transform target_destination; // The place that the NPC will be moving.
    private bool go = true;

	// Use this for initialization
	public override void Do () 
    {
        if (go)
        {
            Debug.Log("Move Command");
            subject_NPC.Move(target_destination);
            go = false;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
