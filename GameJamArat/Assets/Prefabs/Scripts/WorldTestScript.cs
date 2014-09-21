using UnityEngine;
using System.Collections;

public class WorldTestScript : MonoBehaviour 
{

	// Update is called once per frame
	void Update () 
    {
	    if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Debug.Log("mouse wheel increase");
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Debug.Log("mouse wheel decrease");
        }
	}
}
