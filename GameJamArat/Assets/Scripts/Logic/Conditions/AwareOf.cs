using UnityEngine;
using System.Collections;

public class AwareOf : Condition 
{
    public NPC npc;
    public WorldComponent obj;

    public override bool Met()
    {
        return true;
    }
}
