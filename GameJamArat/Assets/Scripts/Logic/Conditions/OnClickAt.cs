using UnityEngine;
using System.Collections;

public class OnClickAt : Condition
{
    public Transform target;

    public override bool Met()
    {
        if (target.collider2D.bounds.Contains((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition)) && Input.GetMouseButtonDown(0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
