using UnityEngine;
using System.Collections;

public class OnClickAt : Condition
{

    public Transform location;
    public float radius;
    public Camera cam;

	public override bool Met()
	{
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseget = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouseloc = new Vector2(mouseget.x, mouseget.y);

            Vector2 objloc = new Vector2(location.position.x,location.position.y);

            Debug.Log("Click");
            Debug.Log(Vector2.Distance(mouseloc, objloc));
            Debug.Log(mouseloc);
            Debug.Log(objloc);
            return Vector2.Distance(mouseloc, objloc) < radius;
        }
        else
        {
            return false;
        }
	}
}
