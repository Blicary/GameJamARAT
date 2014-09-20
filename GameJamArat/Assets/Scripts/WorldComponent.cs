using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class WorldComponent : MonoBehaviour 
{
    public List<string> tags = new List<string>();


    // PUBLIC MODIFIERS
    public void TurnOn()
    {
        gameObject.SetActive(true);
    }
    public void TurnOff()
    {
        gameObject.SetActive(false);
    }

    // PUBLIC ACCESSORS
    public bool IsOn() { return gameObject.activeInHierarchy; }
    public bool HasTag(string tag) { return tags.Contains(tag); }
}
