using UnityEngine;
using System.Collections;

public class OnClickAt : Condition
{

    public Transform location;
    public float radius;

	public override bool Met()
	{
        Debug.Log("EnterIf");
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse");
            Vector3 mouseget = Input.mousePosition;
            Vector2 mouseloc = new Vector2(mouseget.x, mouseget.y);

            Vector2 objloc = new Vector2(location.position.x,location.position.y);
            return Vector2.Distance(mouseloc, objloc) < radius;
        }
        else
        {
            return false;
        }
	}
}
