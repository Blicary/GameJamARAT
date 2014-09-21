using UnityEngine;
using System.Collections;

public class DeactivateObject : Effect 
{
    public Transform obj;

    public override void Do()
    {
        obj.gameObject.SetActive(false);
    }
}
