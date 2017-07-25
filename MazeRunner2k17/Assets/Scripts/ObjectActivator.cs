using UnityEngine;
using System.Collections;

public class ObjectActivator : MonoBehaviour {

    public int[] spawnDeciders = new int[3];


	// Use this for initialization
	void Start () {
        /*for (int i = 0; 3 > i; i++)
        {
            spawnDeciders[i] = Random.Range(7 * i, 7 * (i + 1));
            spawnObjective("Object_" + spawnDeciders[i]);
        }*/
	}
	
	// Update is called once per frame
	void Update () {

	}
}
