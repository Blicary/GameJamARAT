using UnityEngine;
using System.Collections;

public class Distance : Condition
{
    public Transform object1;
    public Transform object2;
    public float distance;
	// Use this for initialization
    public override bool Met()
    { 
        return (object1.position - object2.position).magnitude < distance;
    }
}
