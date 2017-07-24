using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class monsternav : MonoBehaviour {

    public NavMeshAgent navigationAgent;
    public PlayerMovementScript player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        navigationAgent.destination = player.transform.position;
	}
}
