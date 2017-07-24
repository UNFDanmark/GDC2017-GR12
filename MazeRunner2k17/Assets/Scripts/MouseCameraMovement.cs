using UnityEngine;
using System.Collections;

public class MouseCameraMovement : MonoBehaviour {

    public float MouseSensitivityHorizontal = 100.0f;
    public float MouseSensitivityVertical = 80.0f;
    public float yaw = 0.0f;
    public float pitch = 0.0f;
	// Use this for initialization
	void Start() {

    }
	
	// Update is called once per frame
	void Update () {
        yaw += MouseSensitivityHorizontal * Input.GetAxis("Mouse X") * Time.deltaTime;
        pitch -= MouseSensitivityVertical * Input.GetAxis("Mouse Y") * Time.deltaTime;

        if(pitch >= 80)
        {
            pitch = 80;
        }
        else if(pitch <= -80)
        {
            pitch = -80;
        }

        transform.eulerAngles = new Vector3(pitch, yaw, 0);
	}
}
