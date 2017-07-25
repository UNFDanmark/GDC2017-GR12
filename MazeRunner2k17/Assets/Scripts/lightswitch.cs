using UnityEngine;
using System.Collections;

public class lightswitch : MonoBehaviour {

    public PlayerMovementScript playerMovementScript;
    public Behaviour halo;

    // Use this for initialization
    void Start () {
        halo = (Behaviour)GetComponent("Halo");
	}
	
	// Update is called once per frame
	void Update () {
	    if(playerMovementScript.objectCount == 3)
        {
            halo.enabled = true;
        }
	}
}
