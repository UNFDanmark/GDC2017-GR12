using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovementScript : MonoBehaviour {

    //Setting movement speed variables for going backwards and forwards
    public float movespeedFront = 10;
    public float movespeedBack = 5;
    public float movespeedStrafe = 10;
    //Making variable to work on physics
    public Rigidbody myRigidbody;
    //Making camera rotation movment
    public float MouseSensitivityHorizontal = 100.0f;
    public float MouseSensitivityVertical = 80.0f;
    public float yaw = 0.0f;
    public float pitch = 0.0f;
    //Making variable for object Pickup and point control
    public int objectCount = 0;
    //making variable for audio source
    public AudioSource walking;
    public float timeOfLastStep = 0f;
    public float LengthOfSound = 0f;
    public monsternav enemyObject;
    

    void Awake()
    {
        walking = GetComponent<AudioSource>();
        //Connecting the variable to the physics of object
        myRigidbody = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame, for camera movement
    void Update()
    {
        yaw += MouseSensitivityHorizontal * Input.GetAxis("Mouse X") * Time.deltaTime;
        pitch -= MouseSensitivityVertical * Input.GetAxis("Mouse Y") * Time.deltaTime;

        if (pitch >= 80)
        {
            pitch = 80;
        }
        else if (pitch <= -80)
        {
            pitch = -80;
        }

        transform.eulerAngles = new Vector3(pitch, yaw, 0);

        WalkingCheck();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            objectCount++;
        }
        lightswitch();
    }
    // Update called 50 times per second, for physics movement
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
    void OnTriggerEnter(Collider trigger)
    {
        {
            if (trigger.CompareTag("Object"))
            {
                Destroy(trigger.gameObject);
                objectCount++;
                enemyObject.increaseSpeed();
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Door") && objectCount == 3)
        {
            SceneManager.LoadScene("victoryscreen");
        }
    }
    public void WalkingCheck()
    {
        if ((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) && (Time.time - timeOfLastStep) >= LengthOfSound)
        {
            walkSound();
            timeOfLastStep = Time.time;
        }
        else if (!(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0))
        {
            stopWalkSound();
        }
    }
    public void walkSound()
    {
        walking.Play();
    }
    public void stopWalkSound()
    {
        walking.Stop();
        timeOfLastStep = Time.time - LengthOfSound;
    }
    public void lightswitch()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.FindChild("LanternLightSource").GetComponent<Light>().enabled = !transform.FindChild("LanternLightSource").GetComponent<Light>().enabled;
        }
    }    
}