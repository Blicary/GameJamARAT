using UnityEngine;
using System.Collections;

public class OnClickAt : Condition
{

    public Transform target;
    public float radius;

    public override bool Met()
    {

        if (target.collider.bounds.Contains(Input.mousePosition) && Input.GetMouseButtonDown(0))
        {
            Debug.Log("click at");
            return true;
        }
        else
        {
            return false;
        }
    }
}
