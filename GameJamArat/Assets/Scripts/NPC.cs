using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Time;
using mathf;

public class NPC : MonoBehaviour {

    private move_speed;
    private move_dest;

    public string ID_name;
    private List<string> tags = new List<string>;

    //public string aspiration;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool HasTag (string itag) {return tags.Contains(itag);}

    public void Move (Vector2 idest) 
    {
        Vector2.Distance(idest,transform.position);
    }
}
