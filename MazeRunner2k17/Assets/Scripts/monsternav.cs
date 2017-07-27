using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class monsternav : MonoBehaviour {

    public NavMeshAgent navigationAgent;
    public PlayerMovementScript player;
    public float enemySpeed = 1.5f;
    public float deathStareStart = 0;
    public float deathStareEnd = 0;
    public Transform playerAngle;
    public bool stare = false;
    float rotationTimer = 0;
    float timeToRotate = 1.5f;

    void Awake()
    {

    }
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<NavMeshAgent>().speed = enemySpeed;
        if (navigationAgent.enabled)
        {
            navigationAgent.destination = player.transform.position;
        }
        if (stare)
        {
            if (rotationTimer < timeToRotate)
            {
                transform.eulerAngles = new Vector3(0, Mathf.LerpAngle(deathStareStart, deathStareEnd, rotationTimer / timeToRotate), 0);
                rotationTimer += Time.deltaTime;
            }
        }
	}
    public void increaseSpeed()
    {if (player.lightRange == 10)
        {
            enemySpeed++;
        }
        else if (player.lightRange == 4)
        {
            enemySpeed = enemySpeed + 0.5f;
        }
    }
    public void deathStare()
    {
        deathStareStart = transform.eulerAngles.y;

        transform.LookAt(playerAngle);

        deathStareEnd = transform.eulerAngles.y;

        transform.eulerAngles = new Vector3(0, deathStareStart, 0);

        stare = true;
    }
}
