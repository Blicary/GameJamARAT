using UnityEngine;
using System.Collections;

public class GOD : MonoBehaviour 
{

    public float max_radius = 40f;            // The total listen radius possible.
    public float max_listen = 1.0f;
    public float listen_avail;        // The net amount of listen available.

    private NPC mouse_over_NPC;         // The NPC that the mouse is currently over.

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

            Vector3 tmp_position3d = active_NPC.transform.position;
            tmp_position3d -= new Vector3(0, 0, 10);

            command_scroll = ((tmp_position3d - Camera.main.ScreenToWorldPoint(Input.mousePosition)).magnitude / max_radius);
            //if (command_scroll < .1)
            //{
            //    command_scroll = 0;
            //}

            if (command_scroll - tmp_listen > listen_avail)          // Don't let the player spend moar listen than they have.
            {
                command_scroll = listen_avail;
            }
            // Check for mouse click

            if (Input.GetMouseButtonDown(1))
            {
                command_scroll = 0f;
                ClearActiveNPC();
            }




            //Debug.Log(command_scroll);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Down");
            Debug.Log(mouse_over_NPC);
            if ((active_NPC == null) && (mouse_over_NPC != null) )
            {
                
                SetActiveNPC(mouse_over_NPC);
            }
            else if (active_NPC != null)
            {
                active_NPC.ModifyListen(command_scroll);
                listen_avail -= command_scroll - tmp_listen;
                command_scroll = 0f;
                //Debug.Log("Enter Clear");
                ClearActiveNPC();
            }
        }
	}
    // EVENTS
    

    // PUBLIC MODIFIERS
    public void SetHoveredNPC(NPC npc)
    {
        Debug.Log(npc);
        mouse_over_NPC = npc;
    }

    public void ClearHoveredNPC()
    {
        //Debug.Log("clear");
        mouse_over_NPC = null;
    }



    public void SetActiveNPC(NPC npc)// Set the NPC currently receiving commands.    
    {
        active_NPC = npc;
        command_scroll = 0f; 
    }      
    public void ClearActiveNPC() // No NPC is currently recieving commands.
    {
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
            return command_scroll;
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
