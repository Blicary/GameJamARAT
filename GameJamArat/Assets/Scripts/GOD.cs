using UnityEngine;
using System.Collections;

public class GOD : MonoBehaviour {

    public max_radius = 1.0;            // The total listen radius possible.
    private float listen_avail;         // The net amount of listen available.

    private NPC active_NPC;             // The NPC that is currently selected to recieve listen.
    private float command_scroll;       // The amount of listen to be imparted to the selected NPC.    
	
	// Update is called once per frame
	void Update () {
	    
	}

    // PUBLIC MODIFIERS
    public void Set_Active(NPC npc) {active_NPC=npc;}      // Set the NPC currently receiving commands.
    public void Clear_Active() {active_NPC=null;}          // No NPC is currently recieving commands.
}
