using UnityEngine;
using System.Collections;

public class DoorSpawner : MonoBehaviour {

    public GameObject door;
    public int doorDecider = 0;

	// Use this for initialization
	void Start () {
        doorDecider = Random.Range(0, 4);
	    for(int i = 0; 4 > i; i++)
        {
            if (i != doorDecider)
            {
                door = GameObject.Find("Door_" + i);
                door.SetActive(false);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
