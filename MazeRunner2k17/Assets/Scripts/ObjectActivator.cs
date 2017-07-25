using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ObjectActivator : MonoBehaviour {

    public GameObject[] spawnDeciders = new GameObject[3];

    // Use this for initialization
    void Start()
    {
        for (int i = 0; 3 > i; i++)
        {
            spawnDeciders[i] = GameObject.Find("Object_" + Random.Range(7 * i, 7 * (i + 1)));
        }

        for (int i = 0; 21 > i; i++)
        {
            GameObject.Find("Object_" + i).SetActive(false);
        }

        for (int i = 0; 3 > i; i++)
        {
            spawnDeciders[i].SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {

	}
}
