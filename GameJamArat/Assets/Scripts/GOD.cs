using UnityEngine;
using System.Collections;

public class GOD : MonoBehaviour 
{

    public float max_radius = 40f;            // The total listen radius possible.
    private float max_listen = 1.0f;
    private float listen_avail;        // The net amount of listen available.

    private NPC active_NPC;             // The NPC that is currently selected to recieve listen.
    private float command_scroll = 0.0f;      // The amount of listen to be imparted to the selected NPC.    
    private float tmp_listen;

    public void Start()
    {
        listen_avail = max_listen;
    }

	// Update is called once per frame
	public void Update () 
    {
	    if (active_NPC != null)
        {
            tmp_listen = active_NPC.GetListen();

            if (Input.GetKey("up"))
            { command_scroll += .01f; }
            else if (Input.GetKey("down"))
            { command_scroll -= .01f; }

            if ( tmp_listen + command_scroll < 0)       // don't let the player give an npc negative listen.
            { 
                command_scroll = -(tmp_listen);
            }
            
            if (command_scroll > listen_avail)          // Don't let the player spend moar listen than they have.
            {
                command_scroll = listen_avail;
            }

            Debug.Log(command_scroll);
            // Check for mouse click
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("Enter thing");
                if (active_NPC != null)
                {
                    active_NPC.ModifyListen(command_scroll);
                    listen_avail -= command_scroll;
                    command_scroll = 0f;
                   // Clear_Active_NPC();
                }
            }


            //Debug.Log(command_scroll);
        }
	}
    // EVENTS
    

    // PUBLIC MODIFIERS
    public void SetActiveNPC(NPC npc)// Set the NPC currently receiving commands.    
    {
        active_NPC = npc;
        command_scroll = 0f; 
    }      
    public void ClearActiveNPC() // No NPC is currently recieving commands.
    {
        gameObject.SendMessage("OnNPCDeselect");
        active_NPC = null; 
        command_scroll = 0f;
    }          
    
    // PUBLIC HELPERS
    public float GetHypotheticalPercent() // Obtain the hypothetical radius.
    {
        if (active_NPC == null)
        {
            return 0f;
        }
        else
        {
            return tmp_listen + command_scroll;
        }
    }

    public NPC GetActiveNPC()
    {
        if (active_NPC == null)
        {
            return null;
        }
        else
        {
            return active_NPC;
        }
    }
    
}
