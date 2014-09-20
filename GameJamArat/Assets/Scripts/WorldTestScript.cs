using UnityEngine;
using System.Collections;

public class WorldTestScript : MonoBehaviour 
{
    public WorldComponent obj;

	// Update is called once per frame
	void Update () 
    {
	    if (Input.GetButtonDown("TestBttn1"))
        {
            if (obj.IsOn()) obj.TurnOff();
            else obj.TurnOn();
        }
	}
}
