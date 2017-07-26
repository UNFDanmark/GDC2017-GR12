using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {

    public PlayerMovementScript playerMovementScript;
    public bool doorOpen = false;
    public Material openDoor;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    if(playerMovementScript.objectCount == 3)
        {
            doorOpen = true;
            GetComponent<MeshRenderer>().material = openDoor;
        }
	}
}
