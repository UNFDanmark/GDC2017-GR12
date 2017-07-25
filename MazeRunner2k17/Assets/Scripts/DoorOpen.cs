using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {

    public PlayerMovementScript playerMovementScript;
    public bool doorOpen = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    if(playerMovementScript.objectCount == 3)
        {
            doorOpen = true;
            GetComponent<MeshRenderer>().material.color = new Color(255,0,255);
        }
	}
}
