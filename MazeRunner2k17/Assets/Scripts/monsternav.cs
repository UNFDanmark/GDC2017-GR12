﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class monsternav : MonoBehaviour {

    public NavMeshAgent navigationAgent;
    public PlayerMovementScript player;
    public float enemySpeed = 1.5f;

    void Awake()
    {

    }
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (navigationAgent.enabled)
        {
            navigationAgent.destination = player.transform.position;
        }
	}
    public void increaseSpeed()
    {
        enemySpeed++;
        GetComponent<NavMeshAgent>().speed = enemySpeed;
    }
}
