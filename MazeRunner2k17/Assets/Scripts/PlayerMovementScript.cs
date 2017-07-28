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
    public Transform Enemy;
    public float deathLookStartYaw = 0;
    public float deathLookStartPitch = 0;
    public float deathLookEndYaw = 0;
    public float deathLookEndPitch = 0;
    public bool dead = false;
    public float rotationTimer = 0;
    public float rotationTimerUp = 0;
    public float timeToRotate = 0.5f;
    public float timeToRotateUp = 0.5f;
    public float lookTime = 1;
    public PDAnimatorScript enemyAnimator;
    public float lightRange = 10f;
    void Awake()
    {
        walking = GetComponent<AudioSource>();
        //Connecting the variable to the physics of object
        myRigidbody = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start () {
        Cursor.visible = false;
    }
	
	// Update is called once per frame, for camera movement
    void Update()
    {
        Destroy(GameObject.Find("SoundGuy"));
        if (!dead)
        {
            CameraMovement();

            WalkingCheck();
        }
        else
        {
            if (rotationTimer < timeToRotate)
            {
                transform.eulerAngles = new Vector3(Mathf.LerpAngle(deathLookStartPitch, deathLookEndPitch, rotationTimer / timeToRotate), Mathf.LerpAngle(deathLookStartYaw, deathLookEndYaw, rotationTimer / timeToRotate), 0);
                rotationTimer += Time.deltaTime;
            }
            else if (rotationTimerUp < timeToRotateUp)
            {
                enemyAnimator.deathLooky();
                transform.eulerAngles = new Vector3(Mathf.LerpAngle(deathLookEndPitch, deathLookEndPitch - 40, rotationTimerUp / timeToRotateUp), deathLookEndYaw, 0);
                rotationTimerUp += Time.deltaTime;
            }
            else
            {
                transform.eulerAngles = new Vector3(deathLookEndPitch - 40, deathLookEndYaw, 0);
                if(lookTime < Time.time)
                {
                    SceneManager.LoadScene("deathscreen");
                }
            }
            stopWalkSound();
        }
        lightswitch();
    }
    // Update called 50 times per second, for physics movement
	void FixedUpdate () {
        if (!dead)
        {
            Movement();
        }
	}
    void move(float speedForward, float speedStrafe){
        myRigidbody.velocity = transform.forward * speedForward + transform.right * speedStrafe + Vector3.up * myRigidbody.velocity.y;
    }
    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("Object"))
        {
            GameObject.Find("ObjectSpawner").GetComponent<AudioSource>().Play();
            Destroy(trigger.gameObject);
            objectCount++;
            enemyObject.increaseSpeed();
            print(trigger);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Door") && objectCount == 3)
        {
            SceneManager.LoadScene("victoryscreen");
        }
        else if (collision.collider.CompareTag("Enemy"))
        {
            enemyAnimator.stopWalking();
            Kill();
            enemyObject.deathStare();
            lookTime += Time.time + timeToRotate + timeToRotateUp;
            dead = true;
        }
    }
    void Kill()
    {
        deathLookStartYaw = transform.eulerAngles.y;
        deathLookStartPitch = transform.eulerAngles.x;

        transform.LookAt(Enemy);

        deathLookEndYaw = transform.eulerAngles.y;
        deathLookEndPitch = transform.eulerAngles.x;

        transform.eulerAngles = new Vector3(deathLookStartPitch, deathLookStartYaw, 0);

        enemyObject.GetComponent<NavMeshAgent>().enabled = false;
        myRigidbody.velocity = Vector3.zero;
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

        if (Input.GetKeyDown(KeyCode.Q) && lightRange == 10)
        {
            lightRange = transform.FindChild("LanternLightSource").GetComponent<Light>().range = 4;
            enemyObject.enemySpeed = enemyObject.enemySpeed / 2;

        }
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            lightRange = transform.FindChild("LanternLightSource").GetComponent<Light>().range = 10;
            enemyObject.enemySpeed = enemyObject.enemySpeed * 2;
        }
    }
    public void CameraMovement()
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
    }
    public void Movement(){
         if (Input.GetAxis("Vertical") > 0)
        {
            move(movespeedFront* Input.GetAxis("Vertical"), movespeedStrafe* Input.GetAxis("Horizontal"));
        }
        else if (Input.GetAxis("Vertical") < 0) 
        {
            move(movespeedBack* Input.GetAxis("Vertical"), movespeedStrafe* Input.GetAxis("Horizontal"));
        }
        else {
            move(0, movespeedStrafe* Input.GetAxis("Horizontal"));
        }
    }    
}