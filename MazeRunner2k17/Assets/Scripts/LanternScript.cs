using UnityEngine;
using System.Collections;

public class LanternScript : MonoBehaviour {

    public Animator swing;
    public bool isMoving = false;
    public float crossfadeTime = 0.5f;

	// Use this for initialization
	void Start () {
        swing = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(isMoving = false && (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0))
        {
            swing.CrossFade("Swinging", crossfadeTime);
        }
        else if(isMoving = true && Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            swing.CrossFade("Still", crossfadeTime);
        }
	}
}
