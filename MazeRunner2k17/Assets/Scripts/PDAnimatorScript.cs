using UnityEngine;
using System.Collections;

public class PDAnimatorScript : MonoBehaviour {

    public Animator animator;
    public float crossfadeTimer = 0.5f;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    public void stopWalking()
    {
        animator.CrossFade("Still out", crossfadeTimer);
    }
    public void deathLooky()
    {
        animator.CrossFade("Deathlooky", crossfadeTimer);
    }
}
