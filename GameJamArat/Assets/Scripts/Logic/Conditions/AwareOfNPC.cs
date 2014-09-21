using UnityEngine;
using System.Collections;

public class AwareOfNPC : Condition 
{
    public NPC npc;
    public NPC npc2;

    public override bool Met()
    {
        return npc.AwareOfNPC(npc2);
    }
}
