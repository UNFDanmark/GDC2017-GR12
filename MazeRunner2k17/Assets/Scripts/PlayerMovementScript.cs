using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {

    //Setting movement speed variables for going backwards and forwards
    public float movespeedFront = 10;
    public float movespeedBack = 5;
    public float movespeedStrafe = 10;
    //Making variable to work on physics
    public Rigidbody myRigidbody;

    void Awake()
    {
        //Connecting the variable to the physics of object
        myRigidbody = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetAxis("Vertical") > 0)
        {
            move(movespeedFront * Input.GetAxis("Vertical"), movespeedStrafe * Input.GetAxis("Horizontal"));
        }
        else if (Input.GetAxis("Vertical") < 0) 
        {
            move(movespeedBack * Input.GetAxis("Vertical"), movespeedStrafe * Input.GetAxis("Horizontal"));
        }
        else {
            move(0, movespeedStrafe * Input.GetAxis("Horizontal"));
        }
	}
    void move(float speedForward, float speedStrafe){
        myRigidbody.velocity = transform.forward * speedForward + transform.right * speedStrafe + Vector3.up * myRigidbody.velocity.y;
    }


}
