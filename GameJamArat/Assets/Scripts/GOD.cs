﻿using UnityEngine;
using System.Collections;

public class GOD : MonoBehaviour 
{

    public float max_radius = 1.0f;            // The total listen radius possible.
    private float listen_avail;        // The net amount of listen available.

    private NPC active_NPC;             // The NPC that is currently selected to recieve listen.
    private float command_scroll = 0.0f;      // The amount of listen to be imparted to the selected NPC.    

    public void Start()
    {
        listen_avail = max_radius;
    }

	// Update is called once per frame
	public void Update () 
    {
	    if (active_NPC != null)
        {
            command_scroll += Input.GetAxis("Mouse ScrollWheel"); // How much listen does the player want to spend?
            
            float tmp_listen = active_NPC.GetListen();
            if ( tmp_listen + command_scroll < 0)       // don't let the player give an npc negative listen.
            { 
                command_scroll = tmp_listen;
            }
            
            if (command_scroll > listen_avail)          // Don't let the player spend moar listen than they have.
            {
                command_scroll = listen_avail;
            }
        }
	}

    

    // PUBLIC MODIFIERS
    public void Set_Active_NPC(NPC npc) {active_NPC=npc;}      // Set the NPC currently receiving commands.
    public void Clear_Active_NPC() {active_NPC=null;}          // No NPC is currently recieving commands.
    
    // PUBLIC HELPERS
    
    public void OnMouseDown()                                       // The player confirm listen expendature.
    {
        if ( (command_scroll > 0) && (active_NPC != null) )
        {
            //if (Get_Listen(active_NPC) > )
        }
    }
}
